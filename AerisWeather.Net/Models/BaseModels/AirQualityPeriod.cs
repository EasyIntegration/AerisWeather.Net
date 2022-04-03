using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.BaseModels
{
    public class AirQualityPeriod
    {
        public long? Timestamp { get; set; }

        [JsonProperty("dateTimeISO")]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("aqi")]
        public int? AirQuailityIndex { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("pollutants")]
        public List<Pollutant> Pollutants { get; set; }
    }

    public class Pollutant
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("valuePPB")]
        public float? ValuePPB { get; set; }

        [JsonProperty("valueUGM3")]
        public float? ValueUGM3 { get; set; }

        [JsonProperty("aqi")]
        public float? AirQuailityIndex { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
