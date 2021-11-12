using Newtonsoft.Json;

namespace AerisWeather.Net.Models
{
    public abstract class BaseAerisResponse
    {
        [JsonProperty("loc")]
        public Location Location { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        
    }
}
