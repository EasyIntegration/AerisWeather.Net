using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.Responses
{
    public class TidesResponse : BaseAerisResponse
    {
        [JsonProperty("periods")]
        public List<Tide> Tides { get; set; }
    }
}
