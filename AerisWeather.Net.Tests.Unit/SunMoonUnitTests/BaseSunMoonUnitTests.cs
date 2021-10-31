using System;
using System.Collections.Generic;
using AerisWeather.Net.Clients;
using AerisWeather.Net.Models.Exceptions;
using AerisWeather.Net.Models.Responses;
using Moq;

namespace AerisWeather.Net.Tests.Unit.SunMoonUnitTests
{
    public class BaseSunMoonUnitTests
    {
        public ISunMoon sunMoon;
        public Mock<IAerisClient> mockAerisClient;

        public BaseSunMoonUnitTests()
        {
            this.mockAerisClient = new Mock<IAerisClient>();
            this.sunMoon = new SunMoon(this.mockAerisClient.Object);
        }

        public void HappySetUp()
        {
            var x = new List<SunMoonResponse>();

            x.Add(new SunMoonResponse()
            {
                Sun = new Models.BaseModels.Sun() { },
                Moon = new Models.BaseModels.Moon() { }
            });


            this.mockAerisClient.Setup(moq => moq.Request<List<SunMoonResponse>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(x);
        }

        public void EmptyListSetUp()
        {
            var x = new List<SunMoonResponse>();

            this.mockAerisClient.Setup(moq => moq.Request<List<SunMoonResponse>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(x);
        }

        public void NullSetUp()
        {
            List<SunMoonResponse> x = null;

            this.mockAerisClient.Setup(moq => moq.Request<List<SunMoonResponse>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(x);
        }

        public void LocationNotFoundSetUp()
        {

            this.mockAerisClient.Setup(moq => moq.Request<List<SunMoonResponse>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ThrowsAsync(new LocationNotFoundException("test"));
        }
    }
}
