using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Parameters;
using AerisWeather.Net.Models.Responses;

namespace AerisWeather.Net.Clients
{
    public interface ITides :
        IWeatherToday<TidesResponse>
        , IWeatherDaily<TidesResponse>
    {

    }

    public class Tides : BaseWeather, ITides
    {

        public Tides(IAerisClient aerisClient) : base(aerisClient)
        {
            this.EndPoint = "tides";
        }

        public async Task<TidesResponse> DailyAsync(string city, string state, int days)
        {
            return await GetTidesAsync($"{city},{state}", new GetTidesParameters()
            {
                From = "today",
                To = $"+{days}days"
            });
        }

        public async Task<TidesResponse> DailyAsync(string zip, int days)
        {
            return await GetTidesAsync(zip, new GetTidesParameters()
            {
                From = "today",
                To = $"+{days}days"
            });
        }

        public async Task<TidesResponse> DailyAsync(double lat, double lon, int days)
        {
            return await GetTidesAsync($"{lat},{lon}", new GetTidesParameters()
            {
                From = "today",
                To = $"+{days}days"
            });
        }

        public async Task<TidesResponse> DailyAsync(string city, string state, int days, DateTime startDate)
        {
            var param = new GetTidesParameters();

            param.SetFromDate(startDate);
            param.To = $"+{days}days";
            
            return await GetTidesAsync($"{city},{state}", param);
        }

        public async Task<TidesResponse> DailyAsync(string zip, int days, DateTime startDate)
        {
            var param = new GetTidesParameters();

            param.SetFromDate(startDate);
            param.To = $"+{days}days";

            return await GetTidesAsync(zip, param);
        }

        public async Task<TidesResponse> DailyAsync(double lat, double lon, int days, DateTime startDate)
        {
            var param = new GetTidesParameters();

            param.SetFromDate(startDate);
            param.To = $"+{days}days";

            return await GetTidesAsync($"{lat},{lon}", param); ;
        }

        
        public async Task<TidesResponse> TodayAsync(string city, string state)
        {
            return await GetTidesAsync($"{city},{state}", new GetTidesParameters()
            {
                From = "today",
                To = $"+{1}days"
            });
        }

        public async Task<TidesResponse> TodayAsync(double lat, double lon)
        {
            return await GetTidesAsync($"{lat},{lon}", new GetTidesParameters()
            {
                From = "today",
                To = $"+{1}days"
            });
        }

        public async Task<TidesResponse> TodayAsync(string zip)
        {
            return await GetTidesAsync(zip, new GetTidesParameters()
            {
                From = "today",
                To = $"+{1}days"
            });
        }

        private async Task<TidesResponse> GetTidesAsync(string location, GetTidesParameters parameters)
        {
            var queryParams = new Dictionary<string, string>();
            
            queryParams.Add("format", "json");


            if (parameters.Limit > 0)
            {
                queryParams.Add("limit", $"{parameters.Limit}");
            }

            if (!string.IsNullOrEmpty(parameters.From))
            {
                queryParams.Add("from", parameters.From);
            }

            if (!string.IsNullOrEmpty(parameters.To))
            {
                queryParams.Add("to", parameters.To);
            }

            string endPoint = $"{EndPoint}/{location}";

            try
            {
                var result = await aerisClient.Request<List<TidesResponse>>(endPoint, queryParams);

                return result.FirstOrDefault();
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
