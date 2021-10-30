using System;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.BaseModels
{
    public class Moon
    {
        [JsonProperty("riseISO")]
        public DateTime RiseOn { get; set; }

        [JsonProperty("rise")]
        public long Rise { get; set; }

        [JsonProperty("set")]
        public long Set { get; set; }

        [JsonProperty("setISO")]
        public DateTime SetOn { get; set; }

        [JsonProperty("transit")]
        public long TransitTicks { get; set; }

        [JsonProperty("transitISO")]
        public DateTime TransitOn { get; set; }

        [JsonProperty("underfoot")]
        public long UnderFootTicks { get; set; }

        [JsonProperty("underfootISO")]
        public DateTime UnderFootOn { get; set; }

    }
}
