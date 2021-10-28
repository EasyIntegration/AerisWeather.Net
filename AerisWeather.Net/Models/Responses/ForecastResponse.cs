using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models
{
    public class ForecastsResponse : BaseAerisResponse
    {
       

        [JsonProperty("periods")]
        public List<Period> Periods { get; set; }

        
    }
}
