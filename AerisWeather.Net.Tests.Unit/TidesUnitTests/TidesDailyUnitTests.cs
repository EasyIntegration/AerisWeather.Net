using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Responses;
using Xunit;

namespace AerisWeather.Net.Tests.Unit.TidesUnitTests
{
    public class TidesDailyTests : BaseTidesUnitTests
    {

        [Fact]
        public async Task TidesDaily_Zip_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<TidesResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.tides.DailyAsync("90210",2));

        }



        [Fact]
        public async Task TidesDaily_Lat_and_Long_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<TidesResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.tides.DailyAsync(34.52, -77.43,2));

        }


        [Fact]
        public async Task TidesDaily_City_And_State_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<TidesResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.tides.DailyAsync("new york", "new york",2));

        }


        [Fact]
        public async Task TidesDaily_Zip_Exception()
        {

            this.MockExceptionThrow<List<TidesResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.tides.DailyAsync("90210",2));

        }



        [Fact]
        public async Task TidesDaily_Lat_and_Long_Exception()
        {

            this.MockExceptionThrow<List<TidesResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.tides.DailyAsync(34.52, -77.43,2));

        }


        [Fact]
        public async Task TidesDaily_City_And_State_Exception()
        {

            this.MockExceptionThrow<List<TidesResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.tides.DailyAsync("new york", "new york",2));

        }

        [Fact]
        public async Task TidesDaily_Zip_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.tides.DailyAsync("90210",2);

            Assert.Null(response);

        }

        [Fact]
        public async Task TidesDaily_lat_and_long_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.tides.DailyAsync(34.52, -77.43,2);

            Assert.Null(response);

        }

        [Fact]
        public async Task TidesDaily_city_and_state_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.tides.DailyAsync("new york", "new york",2);

            Assert.Null(response);

        }


        [Fact]
        public async Task TidesDaily_Zip_EmptyResult_RETURNS_NULL()
        {

            this.MockResponseIsEmptyList();

            var response = await this.tides.DailyAsync("90210",2);

            Assert.Null(response);

        }

        [Fact]
        public async Task TidesDaily_lat_and_long_EmptyResult_RETURNS_NULL()
        {

            this.MockResponseIsEmptyList();

            var response = await this.tides.DailyAsync(34.52, -77.43,2);

            Assert.Null(response);

        }

        [Fact]
        public async Task TidesDaily_city_and_state_EmptyResult_RETURNS_NULL()
        {

            this.MockResponseIsEmptyList();

            var response = await this.tides.DailyAsync("new york", "new york",2);

            Assert.Null(response);

        }

    }
}
