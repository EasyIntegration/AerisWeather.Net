using System;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models
{
    public class Location
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("long")]
        public double Longitude { get; set; }
    }
}
