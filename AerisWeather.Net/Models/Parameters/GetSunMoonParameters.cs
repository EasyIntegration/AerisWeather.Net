using System;
namespace AerisWeather.Net.Models.Parameters
{
    public class GetSunMoonParameters
    {
        public DateTime? To { get; set; }
        public DateTime? From { get; set; }

        public int Limit { get; set; }
    }
}
