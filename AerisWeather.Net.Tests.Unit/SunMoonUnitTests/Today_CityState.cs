using System;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using Xunit;

namespace AerisWeather.Net.Tests.Unit.SunMoonUnitTests
{
    public class Today_CityState : BaseSunMoonUnitTests
    {
        [Fact]
        public async Task Today_CityState_Happy_Path()
        {
            HappySetUp();

            var result = await this.sunMoon.TodayAsync("birmingham", "al");

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Today_CityState_WHEN_client_returns_EMPTY_LIST()
        {
            EmptyListSetUp();

            var result = await this.sunMoon.TodayAsync("birmingham", "al");

            Assert.Empty(result);
        }

        [Fact]
        public async Task Today_CityState_WHEN_client_returns_NULL()
        {
            NullSetUp();

            var result = await this.sunMoon.TodayAsync("birmingham", "al");

            Assert.Null(result);

        }

        [Fact]
        public async Task Today_CityState_WHEN_client_throws_LocationNotFound()
        {
            LocationNotFoundSetUp();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.sunMoon.TodayAsync("birmingham", "al"));
        }
    }
}
