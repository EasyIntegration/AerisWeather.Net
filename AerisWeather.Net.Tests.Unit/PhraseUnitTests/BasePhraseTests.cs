using System;
using System.Collections.Generic;
using AerisWeather.Net.Clients;
using AerisWeather.Net.Models;
using Moq;

namespace AerisWeather.Net.Tests.Unit.PhraseUnitTests
{
    public class BasePhraseTests : BaseTest
    {
        protected IPhrasesSummary phraseSummary;

        public BasePhraseTests() : base()
        {
            this.phraseSummary = new PhrasesSummary(this.mockAerisClient.Object);
        }


        public override void MockResponseIsNull()
        {
            PhrasesSummaryResponse x = null;

            this.mockAerisClient.Setup(moq => moq.Request<PhrasesSummaryResponse>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(x);
        }
    }
}
