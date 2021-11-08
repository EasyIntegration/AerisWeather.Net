using System;
using AerisWeather.Net.Clients;
using K23.Aeris.NetCore.Tests.Integration;

namespace AerisWeather.Net.Tests.Integration.TidesIntegrationTests
{
    public abstract class BaseTidesIntegrationTest : BaseAerisIntegrationTests
    {
        public ITides client;

        public BaseTidesIntegrationTest() : base()
        {
            this.client = new Tides(new AerisClient());
        }
    }
}
