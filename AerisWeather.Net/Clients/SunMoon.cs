using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Parameters;
using AerisWeather.Net.Models.Responses;

namespace AerisWeather.Net.Clients
{
    public interface ISunMoon :
        IWeatherToday<List<SunMoonResponse>>
        , IWeatherDaily<List<SunMoonResponse>>
    {

    }


    public class SunMoon : BaseWeather, ISunMoon
    {
        
        public SunMoon(IAerisClient aerisClient) : base(aerisClient)
        {
            this.EndPoint = "sunmoon";
        }

        public async Task<List<SunMoonResponse>> TodayAsync(string location)
        {
            return await GetSunMoonAsync(location, new GetSunMoonParameters()
            {
                Limit = 1
            });
        }

        public async Task<List<SunMoonResponse>> TodayAsync(double lat, double lon)
        {
            return await GetSunMoonAsync($"{lat},{lon}", new GetSunMoonParameters()
            {
                Limit = 1
            });
        }

        public async Task<List<SunMoonResponse>> TodayAsync(int zip)
        {
            return await GetSunMoonAsync(zip.ToString(), new GetSunMoonParameters()
            {
                Limit = 1
            });
        }

        public async Task<List<SunMoonResponse>> TodayAsync(string city, string state)
        {
            return await GetSunMoonAsync($"{city},{state}", new GetSunMoonParameters()
            {
                Limit = 1
            });
        }

        public async Task<List<SunMoonResponse>> DailyAsync(int zip, int days)
        {
            return await GetSunMoonAsync(zip.ToString(), new GetSunMoonParameters()
            {
                Limit = days
            });
        }

        public async Task<List<SunMoonResponse>> DailyAsync(string city, string state, int days)
        {
            return await GetSunMoonAsync($"{city},{state}", new GetSunMoonParameters()
            {
                Limit = days
            });
        }

        public async Task<List<SunMoonResponse>> DailyAsync(int zip, int days, DateTime startDate)
        {
            return await GetSunMoonAsync($"{zip}", new GetSunMoonParameters()
            {
                Limit = days,
                From = startDate
            });
        }

        public async Task<List<SunMoonResponse>> DailyAsync(string city, string state, int days, DateTime startDate)
        {
            return await GetSunMoonAsync($"{city},{state}", new GetSunMoonParameters()
            {
                Limit = days,
                From = startDate
            });
        }

        public async Task<List<SunMoonResponse>> DailyAsync(string location, int days)
        {
            return await GetSunMoonAsync(location, new GetSunMoonParameters()
            {
                Limit = days
            });
        }

        public async Task<List<SunMoonResponse>> DailyAsync(double lat, double lon, int days)
        {
            return await GetSunMoonAsync($"{lat},{lon}", new GetSunMoonParameters()
            {
                Limit = days
            });
        }

        public async Task<List<SunMoonResponse>> DailyAsync(string location, int days, DateTime startDate)
        {
            return await GetSunMoonAsync(location, new GetSunMoonParameters()
            {
                Limit = days
                ,From = startDate
            });
        }

        public async Task<List<SunMoonResponse>> DailyAsync(double lat, double lon, int days, DateTime startDate)
        {
            return await GetSunMoonAsync($"{lat},{lon}", new GetSunMoonParameters()
            {
                Limit = days,
                From = startDate
            });
        }

        private async Task<List<SunMoonResponse>> GetSunMoonAsync(string location, GetSunMoonParameters parameters)
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
                var result = await aerisClient.Request<List<SunMoonResponse>>(endPoint, queryParams);

                return result;
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
