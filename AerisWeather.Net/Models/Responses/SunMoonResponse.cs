using System;
using AerisWeather.Net.Models.BaseModels;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.Responses
{
    public class SunMoonResponse : BaseAerisResponse
    {
        [JsonProperty("sun")]
        public Sun Sun { get; set; }

        [JsonProperty("moon")]
        public Moon Moon { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }
}
