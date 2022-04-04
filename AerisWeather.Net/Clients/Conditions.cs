using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Parameters;
using AerisWeather.Net.Models.Responses;

namespace AerisWeather.Net.Clients
{
    public interface IConditions
    {
        Task<ConditionsResponse> DailyAsync(string city, string state, DateTime startDate, DateTime endDate);
        Task<ConditionsResponse> DailyAsync(string zip,  DateTime startDate, DateTime endDate);
        Task<ConditionsResponse> DailyAsync(double lat, double lon,  DateTime startDate, DateTime endDate);

    }


    public class Conditions : BaseWeather, IConditions
    {
            

        public Conditions(IAerisClient aerisClient) : base(aerisClient)
        {
            this.EndPoint = "conditions";
        }

        private async Task<ConditionsResponse> GetConditions(string location, GetConditionsParameters parameters)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("format", "json");
            queryParams.Add("from", parameters.From.Value.ToString("yyyy-MM-dd HH:mm"));
            queryParams.Add("to", parameters.To.Value.ToString("yyyy-MM-dd HH:mm"));

            string endPoint = $"{this.EndPoint}/{location}";

            try
            {
                var result = await aerisClient.Request<List<ConditionsResponse>>(endPoint, queryParams);

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


        public async Task<ConditionsResponse> DailyAsync(string city, string state, DateTime startDate, DateTime endDate)
        {
            return await GetConditions($"{city.Trim()},{state.Trim()}", new GetConditionsParameters()
            {
                From = startDate,
                To = endDate
            });
        }

        public async Task<ConditionsResponse> DailyAsync(string zip, DateTime startDate, DateTime endDate)
        {
            return await GetConditions($"{zip.Trim()}", new GetConditionsParameters()
            {
                From = startDate,
                To = endDate
            });
        }

        public async Task<ConditionsResponse> DailyAsync(double lat, double lon, DateTime startDate, DateTime endDate)
        {
            return await GetConditions($"{lat},{lon}", new GetConditionsParameters()
            {
                From = startDate,
                To = endDate
            });
        }
    }
}
