using System;
using System.Linq;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using Xunit;

namespace AerisWeather.Net.Tests.Integration.SunMoonIntegrationTests
{
    public class Today_CityState : BaseSunMoonIntegrationTests
    {
        [Fact]
        public async Task Today_CityState_Happy_Path()
        {
            var result = await this.sunMoon.TodayAsync("birmingham", "al");
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Today_CityState_LocationNotFound()
        {
            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.sunMoon.TodayAsync("birmingham2", "12"));
        }

        [Theory]
        [InlineData("birmingham","al")]
        [InlineData("atlanta", "ga")]
        [InlineData("nashville", "tn")]
        [InlineData("austin", "tx")]
        [InlineData("alamogordo", "nm")]
        [InlineData("mesa", "az")]
        [InlineData("renton", "wa")]
        public async Task Today_CityState_Theory(string param1, string param2)
        {
            var result = await this.sunMoon.TodayAsync(param1, param2);

            Assert.NotEmpty(result);
            Assert.NotNull(result.FirstOrDefault().Sun);
            Assert.NotNull(result.FirstOrDefault().Moon);

            Assert.NotNull(result.FirstOrDefault().Sun?.RiseOn);
            Assert.NotNull(result.FirstOrDefault().Moon?.RiseOn);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("123", "12")]
        [InlineData("notfound", "az")]
        public async Task Today_CityState_LocationNotFound_Theory(string param1, string param2)
        {
            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.sunMoon.TodayAsync(param1, param2));
        }
    }
}
