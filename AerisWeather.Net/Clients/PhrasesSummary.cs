using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerisWeather.Net.Models;
using AerisWeather.Net.Models.Exceptions;

namespace AerisWeather.Net.Clients
{
    public interface IPhrasesSummary
    {
        Task<PhrasesSummaryResponse> GetTodaysPhrasesSummary(string location);
        Task<PhrasesSummaryResponse> GetTodaysPhrasesSummary(double lat, double lon);
        Task<PhrasesSummaryResponse> GetNextNHoursPhrasesSummary(string location, int numberOfHours);
        Task<PhrasesSummaryResponse> GetNextNHoursPhrasesSummary(double lat, double lon, int numberOfHours);
    }

    public class PhrasesSummary : BaseAerisClient, IPhrasesSummary
    {
        private const string ENDPOINT = "phrases/summary";
        private IAerisClient aerisClient;

        public PhrasesSummary(IAerisClient aerisClient)
        {
            this.aerisClient = aerisClient;
        }

        #region Today

        public async Task<PhrasesSummaryResponse> GetTodaysPhrasesSummary(string location)
        {
            var result = await GetPhraseSummaryAsync(location, new GetPhrasesSummaryParameters()
            {
                Limit = 24
            }) ;

            return result;
        }

        public async Task<PhrasesSummaryResponse> GetTodaysPhrasesSummary(double lat, double lon)
        {
            var result = await GetPhraseSummaryAsync($"{lat},{lon}", new GetPhrasesSummaryParameters()
            {
                Limit = 24
            });

            return result;
        }

        #endregion


        #region Today

        public async Task<PhrasesSummaryResponse> GetNextNHoursPhrasesSummary(string location, int numberOfHours)
        {
            var result = await GetPhraseSummaryAsync(location, new GetPhrasesSummaryParameters()
            {
                Limit = numberOfHours
            });

            return result;
        }

        public async Task<PhrasesSummaryResponse> GetNextNHoursPhrasesSummary(double lat, double lon, int numberOfHours)
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

            if (parameters.To.HasValue)
            {
                queryParams.Add("to", parameters.To.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            string endPoint = $"{ENDPOINT}/{location}";

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
