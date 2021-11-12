using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerisWeather.Net.Models;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Responses.PhraseSummary;

namespace AerisWeather.Net.Clients
{
    public interface IPhrasesSummary : IWeatherToday<PhrasesSummaryResponse>
    { 
        Task<PhrasesSummaryResponse> NextNHours(string location, int numberOfHours);
        Task<PhrasesSummaryResponse> NextNHours(double lat, double lon, int numberOfHours);
    }

    public class PhrasesSummary : BaseWeather, IPhrasesSummary
    {
        
        public PhrasesSummary(IAerisClient aerisClient) : base(aerisClient)
        {
            this.EndPoint = "phrases/summary";
        }

        #region Today

        public async Task<PhrasesSummaryResponse> TodayAsync(int zip)
        {
            var result = await GetPhraseSummaryAsync($"{zip}", new GetPhrasesSummaryParameters()
            {
                Limit = 24
            });

            return result;
        }

        public async Task<PhrasesSummaryResponse> TodayAsync(string city, string state)
        {
            var result = await GetPhraseSummaryAsync($"{city},{state}", new GetPhrasesSummaryParameters()
            {
                Limit = 24
            });

            return result;
        }

        public async Task<PhrasesSummaryResponse> TodayAsync(double lat, double lon)
        {
            var result = await GetPhraseSummaryAsync($"{lat},{lon}", new GetPhrasesSummaryParameters()
            {
                Limit = 24
            });

            return result;
        }

        public async Task<PhrasesSummaryResponse> TodayAsync(string location)
        {
            var result = await GetPhraseSummaryAsync(location, new GetPhrasesSummaryParameters()
            {
                Limit = 24
            });

            return result;
        }

        #endregion


        #region Today

        public async Task<PhrasesSummaryResponse> NextNHours(string location, int numberOfHours)
        {
            var result = await GetPhraseSummaryAsync(location, new GetPhrasesSummaryParameters()
            {
                Limit = numberOfHours
            });

            return result;
        }

        public async Task<PhrasesSummaryResponse> NextNHours(double lat, double lon, int numberOfHours)
        {
            var result = await GetPhraseSummaryAsync($"{lat},{lon}", new GetPhrasesSummaryParameters()
            {
                Limit = numberOfHours
            });

            return result;
        }

        #endregion


        private async Task<PhrasesSummaryResponse> GetPhraseSummaryAsync(string location, GetPhrasesSummaryParameters parameters)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("limit", $"{parameters.Limit}");
            queryParams.Add("format", "json");


            if (parameters.From.HasValue)
            {
                queryParams.Add("from", parameters.From.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            string endPoint = $"{EndPoint}/{location}";

            try
            {
                var result = await aerisClient.Request<List<PhrasesSummaryResponse>>(endPoint, queryParams);

                return result?.FirstOrDefault();
            }
            catch (LocationNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
