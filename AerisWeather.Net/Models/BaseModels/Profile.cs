using System;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models
{
    public class Profile
    {
        [JsonProperty("tz")]
        public string TimeZone { get; set; }

        [JsonProperty("tzname")]
        public string TimeZoneCode { get; set; }

        [JsonProperty("tzoffset")]
        public double? TimeZoneOffset { get; set; }

        [JsonProperty("isDST")]
        public bool? IsDaylightSavings { get; set; }

        [JsonProperty("elevFT")]
        public double? ElevationFeet { get; set; }

        [JsonProperty("elevM")]
        public double? ElevationMeters { get; set; }
    }
}
