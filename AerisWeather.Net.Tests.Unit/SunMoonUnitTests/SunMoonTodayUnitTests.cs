using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Responses;
using Xunit;

namespace AerisWeather.Net.Tests.Unit.SunMoonUnitTests
{
    public class SunMoonTodayUnitTests : BaseSunMoonUnitTests
    {
        [Fact]
        public async Task SunMoonToday_Zip_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.sunMoon.TodayAsync("90210"));

        }

        [Fact]
        public async Task SunMoonToday_Lat_and_Long_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.sunMoon.TodayAsync(11.11, 77.77));

        }

        [Fact]
        public async Task SunMoonToday_City_and_State_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.sunMoon.TodayAsync("atlanta", "ga"));

        }


        [Fact]
        public async Task SunMoonToday_Zip_Exception()
        {

            this.MockExceptionThrow<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.sunMoon.TodayAsync("90210"));

        }



        [Fact]
        public async Task SunMoonToday_Lat_and_Long_Exception()
        {

            this.MockExceptionThrow<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.sunMoon.TodayAsync(34.52, -77.43));

        }


        [Fact]
        public async Task SunMoonToday_City_And_State_Exception()
        {

            this.MockExceptionThrow<List<SunMoonResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.sunMoon.TodayAsync("new york", "new york"));

        }


        [Fact]
        public async Task SunMoonToday_Zip_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.sunMoon.TodayAsync("90210");

            Assert.Null(response);

        }

        [Fact]
        public async Task SunMoonToday_lat_and_long_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.sunMoon.TodayAsync(34.52, -77.43);

            Assert.Null(response);

        }

        [Fact]
        public async Task SunMoonToday_city_and_state_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.sunMoon.TodayAsync("new york", "new york");

            Assert.Null(response);

        }


        [Fact]
        public async Task SunMoonToday_Zip_EmptyResult_RETURNS_Emptylist()
        {

            this.MockResponseIsEmptyList();

            var response = await this.sunMoon.TodayAsync("90210");

            Assert.Empty(response);

        }

        [Fact]
        public async Task SunMoonToday_lat_and_long_EmptyResult_RETURNS_Empty()
        {

            this.MockResponseIsEmptyList();

            var response = await this.sunMoon.TodayAsync(34.52, -77.43);

            Assert.Empty(response);

        }

        [Fact]
        public async Task SunMoonToday_city_and_state_EmptyResult_RETURNS_Empty()
        {

            this.MockResponseIsEmptyList();

            var response = await this.sunMoon.TodayAsync("new york", "new york");

            Assert.Empty(response);

        }
    }
}
