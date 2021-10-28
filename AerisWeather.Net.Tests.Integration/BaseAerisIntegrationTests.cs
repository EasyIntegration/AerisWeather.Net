

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

            ServiceRegistration.RegisterAerisWeather(serviceCollection, Configuration);
        }



        public static IConfiguration InitConfig()
        {
            var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder().AddJsonFile("appsettings.dev_test.json").Build();
            return config;
        }

    }
}
