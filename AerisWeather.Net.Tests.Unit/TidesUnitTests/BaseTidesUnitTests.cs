using System;
using System.Collections.Generic;
using AerisWeather.Net.Clients;
using AerisWeather.Net.Models.Responses;
using AerisWeather.Net.Models.Responses.Tides;
using Moq;

namespace AerisWeather.Net.Tests.Unit.TidesUnitTests
{
    public abstract class BaseTidesUnitTests : BaseTest
    {
        
        protected Tides tides;

        public BaseTidesUnitTests() : base()
        {
            tides = new Tides(mockAerisClient.Object);
        }

        public override void MockResponseIsNull()
        {
            List<TidesResponse> x = null;

            this.mockAerisClient.Setup(moq => moq.Request<List<TidesResponse>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(x);
        }

        public override void MockResponseIsEmptyList()
        {
            List<TidesResponse> x = new List<TidesResponse>();

            this.mockAerisClient.Setup(moq => moq.Request<List<TidesResponse>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(x);
        }
    }
}
