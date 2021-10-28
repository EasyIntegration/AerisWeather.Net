using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Microsoft.Extensions.Configuration;

namespace AerisWeather.Net.Clients
{
    public abstract class BaseAerisClient//<T>
    {
        protected IConfiguration config;
        //protected ILogger<T> logger;
        protected readonly string baseUrl;
        protected internal readonly string clientId;
        protected internal readonly string clientSecret;

        public BaseAerisClient()//, ILoggerFactory loggerFactory)
        {
            this.config = ServiceRegistration.Configuration;

            
            //this.logger = loggerFactory.CreateLogger<T>();
            this.baseUrl = this.config["AerisBaseUrl"];
            clientId = this.config["AerisClientId"];
            clientSecret = this.config["AerisClientSecret"];

            if(string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new Exception("Base Url not configured. Please add AerisBaseUrl to configuration");
            }

            if(string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new Exception("Client ID and or Secret are not configured. Please add AerisClientId and AerisClientSecret to configuration file");
            }
        }

        protected async Task<T> Request<T>(string endPoint, Dictionary<string, string> param)
        {
            var resultList = await baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .GetAerisResponse<T>(clientId, clientSecret);

            return resultList;
        }

    }
}
