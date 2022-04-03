using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerisWeather.Net.Models;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Parameters;
using AerisWeather.Net.Models.Responses;

namespace AerisWeather.Net.Clients
{

    public interface IAirQuality : IWeatherNow<AirQualityResponse>
    {
    }


    public class AirQuality : BaseWeather, IAirQuality
    {
        public AirQuality(IAerisClient aerisClient) : base(aerisClient)
        {
            this.EndPoint = "airquality";
        }

        public async Task<AirQualityResponse> NowAsync(string city, string state)
        {
            return await GetAirQuality($"{city.Trim()},{state.Trim()}");
        }

        public async Task<AirQualityResponse> NowAsync(double lat, double lon)
        {
            return await GetAirQuality($"{lat},{lon}");
        }

        public async Task<AirQualityResponse> NowAsync(string zip)
        {
            return await GetAirQuality($"{zip.Trim()}");
        }



        private async Task<AirQualityResponse> GetAirQuality(string location)
        {
            var queryParams = new Dictionary<string, string>();
            
            queryParams.Add("format", "json");



            string endPoint = $"{this.EndPoint}/{location}";


            try
            {
                var result = await aerisClient.Request<List<AirQualityResponse>>(endPoint, queryParams);

                return result == null ? throw new NullReferenceException() : result.FirstOrDefault();
            }
            catch (NullReferenceException)
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


        
    }
}
