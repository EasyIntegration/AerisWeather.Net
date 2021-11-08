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
    public interface IForecasts :
        IWeatherHourly<ForecastsResponse>
        , IWeatherToday<ForecastsResponse>
        ,IWeatherDaily<ForecastsResponse>
    {

    }

    public class Forecasts : IForecasts
    {
        private const string ENDPOINT = "forecasts";
        private IAerisClient aerisClient;

        public Forecasts(IAerisClient aerisClient)
        {
            this.aerisClient = aerisClient;
        }

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

            string endPoint = $"{ENDPOINT}/{location}";

            try
            {
                var result = await aerisClient.Request<List<ForecastsResponse>>(endPoint, queryParams);

                return result == null ? throw new NullReferenceException() : result.FirstOrDefault();
            }
            catch(NullReferenceException)
            {
                throw;
            }
            catch (LocationNotFoundException)
            {
                throw;
            }
            catch (Exception e) 
            {
                var x = e;

                throw;
            }
        }

        public async Task<ForecastsResponse> HourlyAsync(int zip, int hours)
        {
            var result = await GetForecast($"{zip}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.OneHour,
                Limit = hours
            });

            return result;
        }

        public async Task<ForecastsResponse> HourlyAsync(string city, string state, int hours)
        {
            var result = await GetForecast($"{city},{state}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.OneHour,
                Limit = hours
            });

            return result;
        }

        public async Task<ForecastsResponse> HourlyAsync(double lat, double lon, int hours)
        {
            var result = await GetForecast($"{lat},{lon}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.OneHour,
                Limit = hours
            });

            return result;
        }

        public async Task<ForecastsResponse> HourlyAsync(string location, int hours)
        {
            var result = await GetForecast($"{location}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.OneHour,
                Limit = hours
            });

            return result;
        }

        public async Task<ForecastsResponse> HourlyAsync(int zip, int hours, DateTime startDate)
        {
            var result = await GetForecast($"{zip}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.OneHour,
                Limit = hours,
                From = startDate
            });

            return result;
        }

        public async Task<ForecastsResponse> HourlyAsync(string city, string state, int hours, DateTime startDate)
        {
            var result = await GetForecast($"{city},{state}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.OneHour,
                Limit = hours,
                From = startDate
            });

            return result;
        }

        public async Task<ForecastsResponse> HourlyAsync(string location, int hours, DateTime startDate)
        {
            var result = await GetForecast($"{location}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.OneHour,
                Limit = hours,
                From = startDate
            });

            return result;
        }

        public async Task<ForecastsResponse> HourlyAsync(double lat, double lon, int hours, DateTime startDate)
        {
            var result = await GetForecast($"{lat},{lon}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.OneHour,
                Limit = hours,
                From = startDate
            });

            return result;
        }

        public async Task<ForecastsResponse> TodayAsync(int zip)
        {
            var result = await GetForecast($"{zip}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = 1,

            });

            return result;
        }

        public async Task<ForecastsResponse> TodayAsync(string city, string state)
        {
            var result = await GetForecast($"{city},{state}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = 1,
            });

            return result;
        }

        public async Task<ForecastsResponse> TodayAsync(double lat, double lon)
        {
            var result = await GetForecast($"{lat},{lon}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = 1,
            });

            return result;
        }

        public async Task<ForecastsResponse> TodayAsync(string location)
        {
            var result = await GetForecast(location, new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = 1,
            });

            return result;
        }

        public async Task<ForecastsResponse> DailyAsync(int zip, int days)
        {
            var result = await GetForecast($"{zip}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = days,
            });

            return result;
        }

        public async Task<ForecastsResponse> DailyAsync(string city, string state, int days)
        {
            var result = await GetForecast($"{city},{state}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = days,
            });

            return result;
        }

        public async Task<ForecastsResponse> DailyAsync(string location, int days)
        {
            var result = await GetForecast(location, new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = days,
            });

            return result;
        }

        public async Task<ForecastsResponse> DailyAsync(double lat, double lon, int days)
        {
            var result = await GetForecast($"{lat},{lon}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = days,
            });

            return result;
        }

        public async Task<ForecastsResponse> DailyAsync(int zip, int days, DateTime startDate)
        {
            var result = await GetForecast($"{zip}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = days,
                From = startDate
            });

            return result;
        }

        public async Task<ForecastsResponse> DailyAsync(string city, string state, int days, DateTime startDate)
        {
            var result = await GetForecast($"{city},{state}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = days,
                From = startDate
            });

            return result;
        }

        public async Task<ForecastsResponse> DailyAsync(string location, int days, DateTime startDate)
        {
            var result = await GetForecast(location, new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = days,
                From = startDate
            });

            return result;
        }

        public async Task<ForecastsResponse> DailyAsync(double lat, double lon, int days, DateTime startDate)
        {
            var result = await GetForecast($"{lat},{lon}", new GetForecastParameters()
            {
                Filter = ForecastFilterTypes.Day,
                Limit = days,
                From = startDate
            });

            return result;
        }
    }

}
