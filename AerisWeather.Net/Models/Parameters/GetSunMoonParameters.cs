using System;
namespace AerisWeather.Net.Models.Parameters
{
    public class GetSunMoonParameters
    {
        public DateTime? From { get; set; }

        public int Limit { get; set; }
    }
}
