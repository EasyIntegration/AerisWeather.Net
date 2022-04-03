using System;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using Xunit;

namespace AerisWeather.Net.Tests.Integration.AirQualityIntegrationTests
{
    public class AirQualityNowIntegrationTests : BaseAirQualityIntegrationTest
    {



        [Fact]
        public async Task  Now_CityState_LocationNotFound()
        {
            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.airQuality.NowAsync("birmingham2", "12"));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("123", "12")]
        [InlineData("notfound", "az")]
        public async Task Now_CityState_LocationNotFound_Theory(string param1, string param2)
        {
            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.airQuality.NowAsync(param1, param2));
        }

        [Theory]
        [InlineData("birmingham", "al")]
        [InlineData("atlanta", "ga")]
        [InlineData("nashville", "tn")]
        [InlineData("austin", "tx")]
        [InlineData("alamogordo", "nm")]
        [InlineData("mesa", "az")]
        [InlineData("renton", "wa")]
        [InlineData("Prudhoe Bay","AK")]
        public async Task Now_CityState_Theory(string param1, string param2)
        {
            var result = await this.airQuality.NowAsync(param1, param2);

            Assert.NotNull(result);
        }


        [Fact]
        public async Task Now_ZIP_LocationNotFound()
        {
            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.airQuality.NowAsync("zzzzzz"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("123")]
        [InlineData("notfound")]
        public async Task Now_ZIP_LocationNotFound_Theory(string param1)
        {
            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.airQuality.NowAsync(param1));
        }

        [Theory]
        [InlineData("35040")]
        [InlineData("99734")]
        [InlineData("S7M 0Z9")]
        [InlineData("33142")]
        public async Task Now_ZIP_Theory(string param1)
        {
            var result = await this.airQuality.NowAsync(param1);

            Assert.NotNull(result);
        }
    }
}
