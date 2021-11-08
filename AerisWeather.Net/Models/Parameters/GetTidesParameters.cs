using System;
namespace AerisWeather.Net.Models.Parameters
{
    public class GetTidesParameters
    {
        public int Limit { get; set; }

        public string From { get; set; }
        public string To { get; set; }

        public void SetToDate(DateTime to)
        {
            To = to.ToString("yyyy-MM-dd HH:mm");
        }

        public void SetFromDate(DateTime from)
        {
            From = from.ToString("yyyy-MM-dd HH:mm");
        }
    }
}
