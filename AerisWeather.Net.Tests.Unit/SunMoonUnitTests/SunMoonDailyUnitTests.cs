using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Responses;
using Xunit;

namespace AerisWeather.Net.Tests.Unit.SunMoonUnitTests
{
    public class SunMoonDailyUnitTests : BaseSunMoonUnitTests
    {



        [Fact]
        public async Task SunMoonDaily_Zip_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.sunMoon.DailyAsync("90210", 2));

        }

        [Fact]
        public async Task SunMoonDaily_Lat_and_Long_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.sunMoon.DailyAsync(11.11,77.77, 2));

        }

        [Fact]
        public async Task SunMoonDaily_City_and_State_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.sunMoon.DailyAsync("atlanta", "ga", 2));

        }


        [Fact]
        public async Task SunMoonDaily_Zip_Exception()
        {

            this.MockExceptionThrow<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.sunMoon.DailyAsync("90210", 2));

        }



        [Fact]
        public async Task SunMoonDaily_Lat_and_Long_Exception()
        {

            this.MockExceptionThrow<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.sunMoon.DailyAsync(34.52, -77.43, 2));

        }


        [Fact]
        public async Task SunMoonDaily_City_And_State_Exception()
        {

            this.MockExceptionThrow<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.sunMoon.DailyAsync("new york", "new york", 2));

        }


        [Fact]
        public async Task SunMoonDaily_Zip_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.sunMoon.DailyAsync("90210", 2);

            Assert.Null(response);

        }

        [Fact]
        public async Task SunMoonDaily_lat_and_long_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.sunMoon.DailyAsync(34.52, -77.43, 2);

            Assert.Null(response);

        }

        [Fact]
        public async Task SunMoonDaily_city_and_state_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.sunMoon.DailyAsync("new york", "new york", 2);

            Assert.Null(response);

        }


        [Fact]
        public async Task SunMoonDaily_Zip_EmptyResult_RETURNS_Emptylist()
        {

            this.MockResponseIsEmptyList();

            var response = await this.sunMoon.DailyAsync("90210", 2);

            Assert.Empty(response);

        }

        [Fact]
        public async Task SunMoonDaily_lat_and_long_EmptyResult_RETURNS_Empty()
        {

            this.MockResponseIsEmptyList();

            var response = await this.sunMoon.DailyAsync(34.52, -77.43, 2);

            Assert.Empty(response);

        }

        [Fact]
        public async Task SunMoonDaily_city_and_state_EmptyResult_RETURNS_Empty()
        {

            this.MockResponseIsEmptyList();

            var response = await this.sunMoon.DailyAsync("new york", "new york", 2);

            Assert.Empty(response);

        }

    }
}
