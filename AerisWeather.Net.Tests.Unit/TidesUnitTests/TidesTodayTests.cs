using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Responses;
using AerisWeather.Net.Models.Responses.Tides;
using Xunit;

namespace AerisWeather.Net.Tests.Unit.TidesUnitTests
{
    public class TidesTodayTests : BaseTidesUnitTests
    {

        [Fact]
        public async Task TidesToday_Zip_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<TidesResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.tides.TodayAsync("90210"));

        }



        [Fact]
        public async Task TidesToday_Lat_and_Long_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<TidesResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.tides.TodayAsync(34.52, -77.43));

        }


        [Fact]
        public async Task TidesToday_City_And_State_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<TidesResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.tides.TodayAsync("new york", "new york"));

        }


        [Fact]
        public async Task TidesToday_Zip_Exception()
        {

            this.MockExceptionThrow<List<TidesResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.tides.TodayAsync("90210"));

        }



        [Fact]
        public async Task TidesToday_Lat_and_Long_Exception()
        {

            this.MockExceptionThrow<List<TidesResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.tides.TodayAsync(34.52, -77.43));

        }


        [Fact]
        public async Task TidesToday_City_And_State_Exception()
        {

            this.MockExceptionThrow<List<TidesResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.tides.TodayAsync("new york", "new york"));

        }

        [Fact]
        public async Task TidesToday_Zip_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.tides.TodayAsync("90210");

            Assert.Null(response);

        }

        [Fact]
        public async Task TidesToday_lat_and_long_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.tides.TodayAsync(34.52, -77.43);

            Assert.Null(response);

        }

        [Fact]
        public async Task TidesToday_city_and_state_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.tides.TodayAsync("new york", "new york");

            Assert.Null(response);

        }


        [Fact]
        public async Task TidesToday_Zip_EmptyResult_RETURNS_NULL()
        {

            this.MockResponseIsEmptyList();

            var response = await this.tides.TodayAsync("90210");

            Assert.Null(response);

        }

        [Fact]
        public async Task TidesToday_lat_and_long_EmptyResult_RETURNS_NULL()
        {

            this.MockResponseIsEmptyList();

            var response = await this.tides.TodayAsync(34.52, -77.43);

            Assert.Null(response);

        }

        [Fact]
        public async Task TidesToday_city_and_state_EmptyResult_RETURNS_NULL()
        {

            this.MockResponseIsEmptyList();

            var response = await this.tides.TodayAsync("new york", "new york");

            Assert.Null(response);

        }

    }
}
