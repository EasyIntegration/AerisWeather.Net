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
        public int AirQuailityIndex { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        public List<Pollutant> Pollutants { get; set; }
    }

    public class Pollutant
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public int ValuePPB { get; set; }

        public float ValueUGM3 { get; set; }

        public int AQI { get; set; }

        public string Category { get; set; }
    }
}
