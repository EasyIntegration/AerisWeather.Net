using System;
using System.Threading.Tasks;
using AerisWeather.Net.Clients;
using K23.Aeris.NetCore.Tests.Integration;
using Xunit;

namespace AerisWeather.Net.Tests.Integration
{
    public class SunMoonIntegrationTests : BaseAerisIntegrationTests
    {
        public ISunMoon sunMoon;

        public SunMoonIntegrationTests()
        {
            this.sunMoon = new SunMoon(new BaseAerisClient());
        }


        [Fact]
        public async Task SunMoon_Today_WHEN_zip()
        {
            var result = await this.sunMoon.Today("35143");

            var x = result;
        }
    }
}
