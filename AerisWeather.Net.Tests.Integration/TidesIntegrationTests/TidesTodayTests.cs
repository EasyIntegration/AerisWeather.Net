using System;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using Xunit;

namespace AerisWeather.Net.Tests.Integration.TidesIntegrationTests
{
    public class TidesTodayTests : BaseTidesIntegrationTest
    {

        [Fact]
        public async Task TidesTodayZip_NoCoast()
        {
            var response = await this.client.TodayAsync("35143");
            Assert.Null(response);
        }

        [Fact]
        public async Task TidesTodayZip_HasCoast()
        {
            var response = await this.client.TodayAsync("36561");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task TidesTodayZip_NoLocation()
        {
            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.client.TodayAsync("123"));
        }


        [Fact]
        public async Task TidesTodayCityState_HasCoast()
        {
            var response = await this.client.TodayAsync("Laguna Beach","CA");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task TidesTodayCityState_NoCoast()
        {
            var response = await this.client.TodayAsync("Rolette","ND");
            Assert.Null(response);
        }


        [Fact]
        public async Task TidesTodayLatLon_HasCoast()
        {
           
            var response = await this.client.TodayAsync(34.52, -77.43);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task TidesTodayLatLon_NoCoast()
        {
            var response = await this.client.TodayAsync(42.2, -97.5);
            Assert.Null(response);
        }
    }
}
