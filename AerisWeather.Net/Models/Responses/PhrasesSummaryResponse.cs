using System;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models.Responses.PhraseSummary
{
    public class PhrasesSummaryResponse
    {
        public Phrase Phrases { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }

    public class Profile
    {
        [JsonProperty("tz")]
        public string TimeZone { get; set; }
    }
}
