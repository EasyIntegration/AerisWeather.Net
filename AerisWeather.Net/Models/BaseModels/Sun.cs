using System;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.BaseModels
{
    public class Sun
    {
        [JsonProperty("rise")]
        public long RiseTicks { get; set; }

        [JsonProperty("riseISO")]
        public DateTime RiseOn { get; set; }

        [JsonProperty("set")]
        public long SetTicks { get; set; }

        [JsonProperty("setISO")]
        public DateTime SetOn{ get; set; }

        [JsonProperty("transit")]
        public long TransitTicks { get; set; }

        [JsonProperty("transitISO")]
        public DateTime TransitOn { get; set; }

        [JsonProperty("midnightSun")]
        public bool IsMidnightSun { get; set; }

        [JsonProperty("polarNight")]
        public bool IsPolarNight { get; set; }
           

    }
}
