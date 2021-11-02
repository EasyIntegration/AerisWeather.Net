using System;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.Responses
{
    public class Tide
    {
        [JsonProperty("timestamp")]
        public long Ticks { get; set; }

        [JsonProperty("dateTimeISO")]
        public DateTime DateTime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("heightFT")]
        public double HeightFeet { get; set; }

        [JsonProperty("heightM")]
        public double HeightMeter { get; set; }
    }
}