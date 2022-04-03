using System;
using System.Collections.Generic;
using AerisWeather.Net.Models.BaseModels;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.Responses
{
    public class AirQualityResponse : BaseAerisResponse
    {
        [JsonProperty("periods")]
        public List<AirQualityPeriod> Periods { get; set; }
    }
}
