using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AerisWeather.Net.Clients;
using AerisWeather.Net.Models;
using AerisWeather.Net.Models.BaseModels;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Responses.Forecasts;
using Moq;
using Xunit;

namespace AerisWeather.Net.Tests.Unit
{
    public class ForecastsUnitTests
    { 
        private const int NUMBEROFHOURLYFORCASTSEGMENTS = 120;
        private const int NUMBEROFDAILYFORECASTSEGMENTS = 10;

        protected IForecasts forecastsClient;

        public Mock<IAerisClient> mockAerisClient;

        public ForecastsUnitTests()
        {
            this.mockAerisClient = new Mock<IAerisClient>();
            this.forecastsClient = new Forecasts(this.mockAerisClient.Object);
        }


        [Fact]
        public async Task GetHourlyForecast_WHEN_zip_is_Valid_THEN_true()
        {

            SetUp1();

            var response = await GetHourlyForecast("12345", 1);

            
            Assert.True(response.Count == 1);
        }


        [Fact]
        public async Task GetHourlyForecast_WHEN_AerisClient_Throws_LocationNotFound()
        {
            this.mockAerisClient
                .Setup(x => x.Request<List<ForecastsResponse>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .Throws(new LocationNotFoundException("test"));


            await Assert.ThrowsAsync<LocationNotFoundException>(() => GetHourlyForecast("12345", 1));
        }

        [Fact]
        public async Task GetHourlyForecast_WHEN_AerisClient_returns_NULL_THROW_nullReferenceException()
        {
            this.mockAerisClient
                .Setup(x => x.Request<List<ForecastsResponse>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .Returns<List<ForecastsResponse>>(null);

            await Assert.ThrowsAsync<NullReferenceException>(() => GetHourlyForecast("12345", 1));
        }


        #region LatLonHourly

        [Fact]
        public async Task GetHourlyForecast_WHEN_lat_and_lon_is_Valid_RETURN()
        {
            SetUp1();

            //await Assert.ThrowsAsync<NullReferenceException>(() => GetHourlyForecast(33.33, 33.33, 1));

            var response = await GetHourlyForecast(33.33, 33.33, 1);

            Assert.True(response.Count == 1);
        }

        [Fact]
        public async Task GetHourlyForecast_WHEN_AerisClient_lat_and_lon_Throws_LocationNotFound()
        {
            this.mockAerisClient
                .Setup(x => x.Request<List<ForecastsResponse>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .Throws(new LocationNotFoundException("test"));


            await Assert.ThrowsAsync<LocationNotFoundException>(() => GetHourlyForecast(33.33,33.33, 1));
        }

        [Fact]
        public async Task GetHourlyForecast_WHEN_AerisClient_lat_and_lon_returns_NULL_THROW_nullReferenceException()
        {
            this.mockAerisClient
                .Setup(x => x.Request<List<ForecastsResponse>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .Returns<List<ForecastsResponse>>(null);

            await Assert.ThrowsAsync<NullReferenceException>(() => GetHourlyForecast(33.33,33.33, 1));
        }


        #endregion

        private async Task<List<ForecastsPeriod>> GetTodaysForecast(string location)
        {
            var response = await this.forecastsClient.TodayAsync(location);

            return response.Periods;
        }

        private async Task<List<ForecastsPeriod>> GetHourlyForecast(string location, int numberOfSegments)
        {
            var response = await this.forecastsClient.HourlyAsync(location, numberOfSegments);

            return response.Periods;
        }

        private async Task<List<ForecastsPeriod>> GetHourlyForecast(double lat, double lon, int numberOfSegments)
        {
            var response = await this.forecastsClient.HourlyAsync(lat, lon, numberOfSegments);

            return response.Periods;
        }

        private async Task<List<ForecastsPeriod>> GetDailyForecast(string location)
        {
            var response = await this.forecastsClient.DailyAsync(location, NUMBEROFDAILYFORECASTSEGMENTS);

            return response.Periods;
        }

        private void SetUp1()
        {
            var toReturn = new List<ForecastsResponse>()
            {
                new ForecastsResponse()
                {
                    Periods = new List<ForecastsPeriod>()
                    {
                        new ForecastsPeriod()
                        {
                            Icon = "sunny.png",
                            Date = DateTime.Now,
                            Humidity = 99,
                            SolarRadiation  = 1
                        }
                    }
                }
            };

            this.mockAerisClient
                .Setup(x => x.Request<List<ForecastsResponse>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(toReturn);
        }
    }

}
