using System;
using System.Linq;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using Xunit;

namespace AerisWeather.Net.Tests.Integration.SunMoonIntegrationTests
{
    public class Today_LatAndLon : BaseSunMoonIntegrationTests
    {
        [Fact]
        public async Task Today_CityState_Happy_Path()
        {
            var result = await this.sunMoon.TodayAsync(33.33, 33.33);
            Assert.NotEmpty(result);
        }


        [Theory]
        [InlineData(31.34, 85.15)]
        public async Task Today_CityState_Theory(double param1, double param2)
        {
            var result = await this.sunMoon.TodayAsync(param1, param2);

            Assert.NotEmpty(result);
            Assert.NotNull(result.FirstOrDefault().Sun);
            Assert.NotNull(result.FirstOrDefault().Moon);

            Assert.NotNull(result.FirstOrDefault().Sun?.RiseOn);
            Assert.NotNull(result.FirstOrDefault().Moon?.RiseOn);
        }
    }
}
