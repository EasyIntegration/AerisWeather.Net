using System.Collections.Generic;
using AerisWeather.Net.Models.BaseModels;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.Responses.Forecasts
{
    public class ForecastsResponse : BaseAerisResponse
    {
       
        [JsonProperty("periods")]
        public List<ForecastsPeriod> Periods { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }
}
