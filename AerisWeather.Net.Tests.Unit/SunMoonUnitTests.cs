using System;
using AerisWeather.Net.Clients;
using Moq;
using Xunit;

namespace AerisWeather.Net.Tests.Unit
{
    public class SunMoonUnitTests
    {
        public ISunMoon sunMoon;
        public Mock<IAerisClient> mockAerisClient;

        public SunMoonUnitTests()
        {
            this.mockAerisClient = new Mock<IAerisClient>();
            this.sunMoon = new SunMoon(this.mockAerisClient.Object);
        }


        [Fact]
        public void SunMoon_Today_WHEN_zip()
        {
            var result = this.sunMoon.Today("35143");

            var x = result;
        }

    }
}
