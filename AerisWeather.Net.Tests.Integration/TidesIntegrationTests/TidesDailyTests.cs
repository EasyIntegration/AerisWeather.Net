using System;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using Xunit;

namespace AerisWeather.Net.Tests.Integration.TidesIntegrationTests
{
    
    public class TidesDailyTests : BaseTidesIntegrationTest
    {
        [Fact]
        public async Task TidesDailyZip_NoCoast()
        {
            var response = await this.client.DailyAsync("35143", 1);
            Assert.Null(response);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public async Task TidesDailyZip_NoCoast_Theory(int days)
        {
            var response = await this.client.DailyAsync("35143", days);
            Assert.Null(response);
        }



        [Fact]
        public async Task TidesDailyZip_HasCoast()
        {
            var response = await this.client.DailyAsync("36561",1);
            Assert.NotNull(response);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task TidesDailyZip_HasCoast_Theory_RETURN_NotEmptyList(int days)
        {
            var response = await this.client.DailyAsync("36561", days);
            Assert.NotEmpty(response.Tides);
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task TidesDailyZip_HasCoast_Theory_RETURN_EmptyList(int days)
        {
            var response = await this.client.DailyAsync("36561", days);
            Assert.Null(response);
        }

        [Fact]
        public async Task TidesDailyZip_NoLocation()
        {
            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.client.DailyAsync("123",1));
        }


        [Fact]
        public async Task TidesDailyCityState_HasCoast()
        {
            var response = await this.client.DailyAsync("Laguna Beach", "CA",1);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task TidesDailyCityState_NoCoast()
        {
            var response = await this.client.DailyAsync("Rolette", "ND",1);
            Assert.Null(response);
        }


        [Fact]
        public async Task TidesDailyLatLon_HasCoast()
        {

            var response = await this.client.DailyAsync(34.52, -77.43,1);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task TidesDailyLatLon_NoCoast()
        {
            var response = await this.client.DailyAsync(42.2, -97.5,1);
            Assert.Null(response);
        }
    }
}
