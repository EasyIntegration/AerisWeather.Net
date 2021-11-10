using System;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.BaseModels
{
    public class Sun
    {
        [JsonProperty("rise")]
        public long RiseTicks { get; set; }

        [JsonProperty("riseISO")]
        public DateTimeOffset RiseOn { get; set; }

        [JsonProperty("set")]
        public long SetTicks { get; set; }

        [JsonProperty("setISO")]
        public DateTimeOffset SetOn{ get; set; }

        [JsonProperty("transit")]
        public long TransitTicks { get; set; }

        [JsonProperty("transitISO")]
        public DateTimeOffset TransitOn { get; set; }

        [JsonProperty("midnightSun")]
        public bool IsMidnightSun { get; set; }

        [JsonProperty("polarNight")]
        public bool IsPolarNight { get; set; }
           

    }
}
