using System;
using AerisWeather.Net.Clients;
using K23.Aeris.NetCore.Tests.Integration;

namespace AerisWeather.Net.Tests.Integration.SunMoonIntegrationTests
{
    public class BaseSunMoonIntegrationTests : BaseAerisIntegrationTests

    {
        public ISunMoon sunMoon;

        public BaseSunMoonIntegrationTests() : base()
        {
            this.sunMoon = new SunMoon(new AerisClient());
        }
    }
}
