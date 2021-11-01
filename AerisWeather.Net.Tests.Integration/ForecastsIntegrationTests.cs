using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AerisWeather.Net.Clients;
using AerisWeather.Net.Models;
using AerisWeather.Net.Models.Exceptions;
using Xunit;

namespace K23.Aeris.NetCore.Tests.Integration
{
   
    public class ForecastsIntegrationTests : BaseAerisIntegrationTests
    {
        private const int NUMBEROFHOURLYFORCASTSEGMENTS = 120;
        private const int NUMBEROFDAILYFORECASTSEGMENTS = 10;

        protected IForecasts forecastsClient;

        public ForecastsIntegrationTests()
        {
            this.forecastsClient = new Forecasts(new AerisClient());
        }

        #region valid

        [Theory]
        [InlineData("35040")]
        [InlineData("35143")]
        public async Task GetHourlyForecast_WHEN_zip_is_Valid_THEN_true(string param1)
        {
            var response = await GetHourlyForecast(param1);

            Assert.Equal(NUMBEROFHOURLYFORCASTSEGMENTS, response.Count);
        }


        [Theory]
        [InlineData(42.25, -95.25)]      
        public async Task GetHourlyForecast_WHEN_lat_and_lon_are_Valid_THEN_true(double param1, double param2)
        {
            var response = await GetHourlyForecast(param1, param2);

            Assert.Equal(NUMBEROFHOURLYFORCASTSEGMENTS, response.Count);
        }



        [Theory]
        [InlineData("35040")]
        public async Task GetHourlyForecast_WHEN_periods_are_returned_VALIDATE_all_properties_have_value(string param1)
        {
            var response = await GetHourlyForecast(param1);

            Assert.Equal(NUMBEROFHOURLYFORCASTSEGMENTS, response.Count);

            foreach (var period in response)
            {
                TestHelpers.ValidateAllPropertiesHaveValue(period, param1);
            }
        }


        [Theory]
        [InlineData("35040")]
        [InlineData("35143")]
        public async Task GetDailyForecast_WHEN_zip_Is_Valid_THEN_return(string param1)
        {
            var x = await GetDailyForecast(param1);

            Assert.Equal(NUMBEROFDAILYFORECASTSEGMENTS, x.Count);
        }


        [Theory]
        [InlineData("35040")]
        [InlineData("35143")]
        public async Task GetTodaysForecast_WHEN_zip_Is_Valid_THEN_return(string param1)
        {
            var response = await GetTodaysForecast(param1);

            Assert.Equal(1, response.Count);
        }



        #endregion




        #region invalid


        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1")]
        [InlineData("---")]
        public async Task GetHourlyForecast_WHEN_zip_Is_NotFound_THEN_throw_locationNotFoundException(string param1)
        {
            await Assert.ThrowsAsync<LocationNotFoundException>(() => GetHourlyForecast(param1));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1")]
        [InlineData("---")]
        public async Task GetDailyForecast_WHEN_zip_Is_NotFound_THEN_throw_locationNotFoundException(string param1)
        {
            await Assert.ThrowsAsync<LocationNotFoundException>(() => GetDailyForecast(param1));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1")]
        [InlineData("---")]
        public async Task GetTodaysForecast_WHEN_zip_Is_NotFound_THEN_throw_locationNotFoundException(string param1)
        {
            await Assert.ThrowsAsync<LocationNotFoundException>(() => GetTodaysForecast(param1));
        }


        #endregion

        private async Task<List<Period>> GetTodaysForecast(string location)
        {
            var response = await this.forecastsClient.TodayAsync(location);

            return response.Periods;
        }

        private async Task<List<Period>> GetHourlyForecast(string location)
        {
            var response = await this.forecastsClient.HourlyAsync(location, NUMBEROFHOURLYFORCASTSEGMENTS);

            return response.Periods;
        }

        private async Task<List<Period>> GetHourlyForecast(double lat, double lon)
        {
            var response = await this.forecastsClient.HourlyAsync(lat, lon, NUMBEROFHOURLYFORCASTSEGMENTS);

            return response.Periods;
        }

        private async Task<List<Period>> GetDailyForecast(string location)
        {
            var response = await this.forecastsClient.DailyAsync(location, NUMBEROFDAILYFORECASTSEGMENTS);

            return response.Periods;
        }

    }
}
