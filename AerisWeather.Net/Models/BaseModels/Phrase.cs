using System;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models
{ 
    public class Phrase
    {
        [JsonProperty("short")]
        public string ShortImperial { get; set; }

        [JsonProperty("shortMET")]
        public string ShortMetric { get; set; }

        [JsonProperty("long")]
        public string LongImperial { get; set; }

        [JsonProperty("longMET")]
        public string LongMetric { get; set; }

    }
}
