using System;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.BaseModels
{
    public class Moon
    {
        [JsonProperty("riseISO")]
        public DateTimeOffset RiseOn { get; set; }

        [JsonProperty("rise")]
        public long Rise { get; set; }

        [JsonProperty("set")]
        public long Set { get; set; }

        [JsonProperty("setISO")]
        public DateTimeOffset SetOn { get; set; }

        [JsonProperty("transit")]
        public long TransitTicks { get; set; }

        [JsonProperty("transitISO")]
        public DateTimeOffset TransitOn { get; set; }

        [JsonProperty("underfoot")]
        public long UnderFootTicks { get; set; }

        [JsonProperty("underfootISO")]
        public DateTimeOffset UnderFootOn { get; set; }

    }
}
