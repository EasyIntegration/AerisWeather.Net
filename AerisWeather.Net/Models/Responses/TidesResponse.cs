using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.Responses.Tides
{
    public class TidesResponse : BaseAerisResponse
    {
        [JsonProperty("periods")]
        public List<Tide> Tides { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }

    public class Profile
    {
        [JsonProperty("tz")]
        public string TimeZone { get; set; }
    }
}
