using System;
using System.Threading.Tasks;
using AerisWeather.Net.Clients;
using K23.Aeris.NetCore.Tests.Integration;
using Xunit;

namespace AerisWeather.Net.Tests.Integration.AirQualityIntegrationTests
{
    public class BaseAirQualityIntegrationTest : BaseAerisIntegrationTests
    {
        public IAirQuality airQuality;

        public BaseAirQualityIntegrationTest()
        {
            this.airQuality = new AirQuality(new AerisClient());
        }

        
    }
}
