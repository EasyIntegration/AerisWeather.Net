using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Flurl.Http;
using AerisWeather.Net.Clients;

namespace AerisWeather.Net
{
    public static class ServiceRegistration
    {

        internal static IConfiguration Configuration;


        public static IServiceCollection RegisterAerisWeather(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            Configuration = configuration;

            var baseUrl = configuration["AerisBaseUrl"];

            if(string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new Exception("aeris url not provided");
            }


            FlurlHttp.ConfigureClient(baseUrl, cli => cli
                .Configure(settings =>
                {

                })
                .WithHeaders(new
                {
                    Accept = "application/json",
                }));


            serviceCollection.AddScoped<IAerisClient, AerisClient>();
            serviceCollection.AddScoped<IForecasts, Forecasts>();
            serviceCollection.AddScoped<IPhrasesSummary, PhrasesSummary>();
            serviceCollection.AddScoped<IConditions, Conditions>();

            return serviceCollection;
        }
    }
}
