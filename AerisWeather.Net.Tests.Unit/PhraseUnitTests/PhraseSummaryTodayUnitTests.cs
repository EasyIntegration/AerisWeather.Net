using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AerisWeather.Net.Models;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Responses.PhraseSummary;
using Xunit;

namespace AerisWeather.Net.Tests.Unit.PhraseUnitTests
{
    public class PhraseSummaryTodayUnitTests : BasePhraseTests
    {
        [Fact]
        public async Task PhraseToday_Zip_LocationNotFound()
        {

            this.MockLocationNotFoundException<List<PhrasesSummaryResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.phraseSummary.TodayAsync("90210"));

        }

        [Fact]
        public async Task PhraseToday_Lat_and_Long_LocationNotFound()
        {

            this.MockLocationNotFoundException< List<PhrasesSummaryResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.phraseSummary.TodayAsync(111.11, 11.2));

        }

        [Fact]
        public async Task PhraseToday_City_and_State_LocationNotFound()
        {

            this.MockLocationNotFoundException< List<PhrasesSummaryResponse>>();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.phraseSummary.TodayAsync("atlanta", "ga"));

        }

        [Fact]
        public async Task PhraseToday_Zip_Exception()
        {

            this.MockExceptionThrow<List<PhrasesSummaryResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.phraseSummary.TodayAsync("90210"));

        }



        [Fact]
        public async Task PhraseToday_Lat_and_Long_Exception()
        {

            this.MockExceptionThrow< List<PhrasesSummaryResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.phraseSummary.TodayAsync(34.52, -77.43));

        }


        [Fact]
        public async Task PhraseToday_City_And_State_Exception()
        {

            this.MockExceptionThrow< List<PhrasesSummaryResponse>>();

            await Assert.ThrowsAsync<Exception>(() => this.phraseSummary.TodayAsync("new york", "new york"));

        }


        [Fact]
        public async Task PhraseToday_Zip_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.phraseSummary.TodayAsync("90210");

            Assert.Null(response);

        }

        [Fact]
        public async Task PhraseToday_lat_and_long_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.phraseSummary.TodayAsync(34.52, -77.43);

            Assert.Null(response);

        }

        [Fact]
        public async Task PhraseToday_city_and_state_NullResponse_RETURNS_NULL()
        {

            this.MockResponseIsNull();

            var response = await this.phraseSummary.TodayAsync("new york", "new york");

            Assert.Null(response);

        }

    }
}
