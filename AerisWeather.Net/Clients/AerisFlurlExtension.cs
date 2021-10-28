using System;
using System.Threading.Tasks;
using AerisWeather.Net.Models;
using AerisWeather.Net.Models.Exceptions;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace AerisWeather.Net.Clients
{
    public static class MMFlurlExtensions
    {
        public static Task<T> GetAerisResponse<T>(this Url url, string clientId, string clientSecret) => new FlurlRequest(url).GetAerisResponse<T>(clientId, clientSecret);
        public static Task<T> GetAerisResponse<T>(this Uri uri, string clientId, string clientSecret) => new FlurlRequest(uri).GetAerisResponse<T>(clientId, clientSecret);
        public static Task<T> GetAerisResponse<T>(this string url, string clientId, string clientSecret) => new FlurlRequest(url).GetAerisResponse<T>(clientId, clientSecret);


        public async static Task<T> GetAerisResponse<T>(this IFlurlRequest req, string clientId, string clientSecret)
        {
            AerisResponse<T> result = null;

            try
            {
                req.SetQueryParams(new
                {
                    client_id = clientId,
                    client_secret = clientSecret
                });

                result = await req.GetJsonAsync<AerisResponse<T>>();
            }
            catch (Exception e)
            {
                throw new Exception("Error attempting to query Aeris", e);
            }

            if (result.success && result.response != null)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result.response));
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }

            }
            else
            {

                var errorMessage = $"{result.error.Code} - {result.error.Description}";

                switch (result.error.Code)
                {
                    //USER ERROR
                    case "invalid_location": //The location used in the request is invalid or not found in the database.
                    case "invalid_coordinate": //The coordinate or series of coordinates provided with the request are invalid. 
                    case "invalid_query": //The query provided with the request is invalid.
                        throw new LocationNotFoundException(errorMessage);

                    //AERIS ACCOUNT ISSUE
                    case "maxhits_daily": //You have reached your maximum daily access limit for your account. Further API accesses will receive this error, until the daily count resets at 00 UTC (midnight UTC).
                    case "insufficient_scope": //Valid OAuth credentials were provided, but the user is not allowed access to the data due to privacy restrictions or account level.
                    case "deprecated": //The request is using deprecated functionality, or the response has changed..
                    case "unauthorized_namespace": //Valid OAuth credentials were provided, the request originated from a domain or application outside of the allowed scope the client was registered with.
                    case "invalid_client": //Either no OAuth credentials were provided, or the provided client_id and/or client_secret are invalid.
                    case "invalid_id": //The id provided with the request is invalid.
                    case "invalid_request": //The requested endpoint or action is invalid and not supported.
                    case "internal_error": //An internal error occurred during the request, but don't worry, our development team has been notified of the error.
                    default:
                        throw new Exception($"{errorMessage}");

                }
            }

        }
    }
}
