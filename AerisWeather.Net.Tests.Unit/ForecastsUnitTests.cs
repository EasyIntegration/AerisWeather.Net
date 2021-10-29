using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AerisWeather.Net.Clients;
using AerisWeather.Net.Models;
using AerisWeather.Net.Models.Exceptions;
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

            var toReturn = new List<ForecastsResponse>()
            {
                new ForecastsResponse()
                {
                    Periods = new List<Period>()
                    {
                        new Period()
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

            var response = await GetHourlyForecast("12345", 1);

            Assert.Equal(1, response.Count);
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



        private async Task<List<Period>> GetTodaysForecast(string location)
        {
            var response = await this.forecastsClient.GetTodaysForecast(location);

            return response.Periods;
        }

        private async Task<List<Period>> GetHourlyForecast(string location, int numberOfSegments)
        {
            var response = await this.forecastsClient.GetHourlyForecast(location, numberOfSegments);

            return response.Periods;
        }

        private async Task<List<Period>> GetHourlyForecast(double lat, double lon)
        {
            var response = await this.forecastsClient.GetHourlyForecast(lat, lon, NUMBEROFHOURLYFORCASTSEGMENTS);

            return response.Periods;
        }

        private async Task<List<Period>> GetDailyForecast(string location)
        {
            var response = await this.forecastsClient.GetDailyForecast(location, NUMBEROFDAILYFORECASTSEGMENTS);

            return response.Periods;
        }
    }
}
