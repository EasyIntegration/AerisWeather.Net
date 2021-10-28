using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerisWeather.Net.Models;
using AerisWeather.Net.Models.Exceptions;
using Flurl;
using Microsoft.Extensions.Configuration;

namespace AerisWeather.Net.Clients
{
    public interface IForecastsClient
    {

        Task<ForecastsResponse> GetHourlyForecast(double lat, double lon, int numberOfDays, DateTime? from = null, DateTime? to = null);

        Task<ForecastsResponse> GetHourlyForecast(string location, int numberOfDays, DateTime? from = null, DateTime? to = null);

        Task<ForecastsResponse> GetHourlyForecast(double lat, double lon, int numberOfDays, ForecastFilterTypes interval, DateTime? from = null, DateTime? to = null);

        Task<ForecastsResponse> GetHourlyForecast(string location, int numberOfDays,ForecastFilterTypes interval, DateTime? from = null, DateTime? to = null);


        Task<ForecastsResponse> GetDailyForecast(string lat, string lon, int numberOfDays, DateTime? from = null, DateTime? to = null);

        Task<ForecastsResponse> GetDailyForecast(string location, int numberOfDays, DateTime? from = null, DateTime? to = null);


        Task<ForecastsResponse> GetTodaysForecast(string location);

        Task<ForecastsResponse> GetTodaysForecast(string lat, string lon);

    }

    


    public class ForecastsClient : BaseAerisClient, IForecastsClient
    {
        private const string ENDPOINT = "forecasts";


        #region Todays
        public async Task<ForecastsResponse> GetTodaysForecast(string lat, string lon)
        {
            var result = await GetForecast($"{lat},{lon}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = 1
            });

            return result;
        }

        public async Task<ForecastsResponse> GetTodaysForecast(string location)
        {
            var result = await GetForecast(location, new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = 1
            });

            

            return result;
        }

        #endregion

        #region Hourly

        public async Task<ForecastsResponse> GetHourlyForecast(double lat, double lon, int numberOfHours, DateTime? from = null, DateTime? to = null)
        {
            var result = await GetForecast($"{lat},{lon}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.OneHour,
                Limit = numberOfHours,
                From = from,
                To = to
            });

            return result;
        }

        public async Task<ForecastsResponse> GetHourlyForecast(string location, int numberOfHours, DateTime? from = null, DateTime? to = null)
        {
            var result = await GetForecast(location, new GetForecastParameters()
            {
                Limit = numberOfHours,
                Filter = ForecastFilterTypes.OneHour,
                From = from,
                To = to
            }) ;

            return result;
        }

        public async Task<ForecastsResponse> GetHourlyForecast(double lat, double lon, int numberOfHours, ForecastFilterTypes interval, DateTime? from = null, DateTime? to = null)
        {
            var result = await GetForecast($"{lat},{lon}", new GetForecastParameters()
            {
                Filter = interval,
                Limit = numberOfHours,
                From = from,
                To = to
            });

            return result;
        }

        public async Task<ForecastsResponse> GetHourlyForecast(string location, int numberOfHours, ForecastFilterTypes interval, DateTime? from = null, DateTime? to = null)
        {

            var result = await GetForecast(location, new GetForecastParameters()
            {
                Limit = numberOfHours,
                Filter = interval,
                From = from,
                To = to
            });

            return result;

        }

        #endregion

        #region Daily

        public async Task<ForecastsResponse> GetDailyForecast(string lat, string lon, int numberOfDays, DateTime? from = null, DateTime? to = null)
        {
            var result = await GetForecast($"{lat},{lon}", new GetForecastParameters()
            {
                Limit = numberOfDays,
                Filter = ForecastFilterTypes.Day,
                From = from,
                To = to
            });

            return result;
        }

        public async Task<ForecastsResponse> GetDailyForecast(string location, int numberOfDays, DateTime? from = null, DateTime? to = null)
        {
            var result = await GetForecast(location, new GetForecastParameters()
            {
                Limit = numberOfDays,
                Filter = ForecastFilterTypes.Day,
                From = from,
                To = to
            });

            return result;
        }

        #endregion

        private async Task<ForecastsResponse> GetForecast(string location, GetForecastParameters parameters)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("limit", $"{parameters.Limit}");
            queryParams.Add("format", "json");


            if(parameters.Filter != ForecastFilterTypes.NotSet)
            {
                queryParams.Add("filter", parameters.Filter.ToStringExt());

            }

            if(parameters.From.HasValue)
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
                var result = await Request<List<ForecastsResponse>>(endPoint, queryParams);

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
