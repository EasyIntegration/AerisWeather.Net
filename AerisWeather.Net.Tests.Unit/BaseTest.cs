using System;
using System.Collections.Generic;
using AerisWeather.Net.Clients;
using AerisWeather.Net.Models.Exceptions;
using Moq;

namespace AerisWeather.Net.Tests.Unit
{
    public class BaseTest
    {
        protected Mock<IAerisClient> mockAerisClient;

        public BaseTest()
        {
            mockAerisClient = new Mock<IAerisClient>();
        }


        public void MockExceptionThrow<T>()
        {
            this.mockAerisClient.Setup(moq => moq.Request<T>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
            .Throws(new Exception("MockException"));
        }


        public void MockLocationNotFoundException<T>()
        {
            this.mockAerisClient.Setup(moq => moq.Request<T>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
            .Throws(new LocationNotFoundException("MockException"));
        }

        public virtual void MockResponseIsNull() 
        {
            throw new NotImplementedException();
        }

        public virtual void MockResponseIsEmptyList()
        {
            throw new NotImplementedException();
        }

    }
}
