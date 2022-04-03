

using AerisWeather.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace K23.Aeris.NetCore.Tests.Integration
{
    
    public class BaseAerisIntegrationTests
    {
        protected IConfiguration Configuration = InitConfig();


        public BaseAerisIntegrationTests()
        {
            var serviceCollection = new ServiceCollection();

            ServiceRegistration.RegisterAerisWeatherDotNet(serviceCollection, Configuration);
        }



        public static IConfiguration InitConfig()
        {
            try
            {
                var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder().AddJsonFile("appsettings.dev_test.json").Build();
                return config;
            }
            catch
            {
                var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                return config;
            }
            
        }

    }
}
