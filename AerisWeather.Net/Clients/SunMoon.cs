using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Parameters;
using AerisWeather.Net.Models.Responses;

namespace AerisWeather.Net.Clients
{
    public interface ISunMoon : IWeather<List<SunMoonResponse>>
    {

    }


    public class SunMoon : ISunMoon
    {
        private IAerisClient aerisClient;
        private const string ENDPOINT = "sunmoon";

        public SunMoon(IAerisClient aerisClient)
        {
            this.aerisClient = aerisClient;
        }

        public async Task<List<SunMoonResponse>> Today(string location)
        {
            return await GetSunMoonAsync(location, new GetSunMoonParameters()
            {
                Limit = 1
            });
        }

        public Task<List<SunMoonResponse>> Today(double lat, double lon)
        {
            throw new NotImplementedException();
        }

        public Task<List<SunMoonResponse>> Hourly(string location, int hours)
        {
            throw new NotImplementedException();
        }

        public Task<List<SunMoonResponse>> Hourly(double lat, double lon, int hours)
        {
            throw new NotImplementedException();
        }

        public Task<List<SunMoonResponse>> Hourly(string location, int hours, DateTime startDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<SunMoonResponse>> Hourly(double lat, double lon, int hours, DateTime startDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<SunMoonResponse>> Daily(string location, int days)
        {
            throw new NotImplementedException();
        }

        public Task<List<SunMoonResponse>> Daily(double lat, double lon, int days)
        {
            throw new NotImplementedException();
        }

        public Task<List<SunMoonResponse>> Daily(string location, int days, DateTime startDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<SunMoonResponse>> Daily(double lat, double lon, int days, DateTime startDate)
        {
            throw new NotImplementedException();
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

            if (parameters.To.HasValue)
            {
                queryParams.Add("to", parameters.To.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            string endPoint = $"{ENDPOINT}/{location}";

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
