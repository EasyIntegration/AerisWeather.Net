using System;
using System.Threading.Tasks;
using AerisWeather.Net.Clients;
using AerisWeather.Net.Models;
using Xunit;

namespace K23.Aeris.NetCore.Tests.Integration.Tests
{
    public class PhrasesSummaryIntegrationTests : BaseAerisIntegrationTests
    {


        private readonly IPhrasesSummary phrasesSummary;

        public PhrasesSummaryIntegrationTests()
        {
            phrasesSummary = new PhrasesSummary(new BaseAerisClient());
        }

        #region GetTodaysPhase

        [Theory]
        [InlineData("35040")]
        [InlineData("35143")]
        public async Task GetTodaysPhrase_ZIP_WHEN_location_is_valid_RETURN_phrase(string param1)
        {
            var response = await this.GetTodaysPhrasesSummary(param1);

            Assert.NotNull(response);

            TestHelpers.ValidateAllPropertiesHaveValue(response, param1);
        }


        [Theory]
        [InlineData(42.25, -95.25)]
        public async Task GetTodaysPhrase_Lat_Long_WHEN_location_is_valid_RETURN_phrase(double param1, double param2)
        {
            var response = await this.GetTodaysPhrasesSummary(param1, param2);

            Assert.NotNull(response);

            TestHelpers.ValidateAllPropertiesHaveValue(response, $"{param1}, {param2}");
        }


        #endregion



        #region GetNextNHoursPhrasesSummary

        [Theory]
        [InlineData("35040")]
        [InlineData("35143")]
        public async Task GetNextNHoursPhrasesSummary_WHEN_location_is_valid_RETURN_phrase(string param1)
        {
            var response = await this.GetNextNHoursPhrasesSummary(param1);

            Assert.NotNull(response);

            TestHelpers.ValidateAllPropertiesHaveValue(response, param1);
        }


        [Theory]
        [InlineData(42.25, -95.25)]
        public async Task GetNextNHoursPhrasesSummarye_Lat_Long_WHEN_location_is_valid_RETURN_phrase(double param1, double param2)
        {
            var response = await this.GetNextNHoursPhrasesSummary(param1, param2);

            Assert.NotNull(response);

            TestHelpers.ValidateAllPropertiesHaveValue(response, $"{param1}, {param2}");
        }


        #endregion



        private async Task<Phrase> GetTodaysPhrasesSummary(string location)
        {
            var response = await this.phrasesSummary.GetTodaysPhrasesSummary(location);

            return response.Phrases;
        }

        private async Task<Phrase> GetTodaysPhrasesSummary(double lat, double lon)
        {
            var response = await this.phrasesSummary.GetTodaysPhrasesSummary(lat, lon);

            return response.Phrases;
        }

        private async Task<Phrase> GetNextNHoursPhrasesSummary(string location)
        {
            var response = await this.phrasesSummary.GetNextNHoursPhrasesSummary(location,80);

            return response.Phrases;
        }

        private async Task<Phrase> GetNextNHoursPhrasesSummary(double lat, double lon)
        {
            var response = await this.phrasesSummary.GetNextNHoursPhrasesSummary(lat, lon, 80);

            return response.Phrases;
        }
    }
}
