using System;
namespace AerisWeather.Net.Models.Parameters
{
    public class GetAirQualityParameters
    {
        private int _limit = 10;

        public DateTime? From { get; set; }

        public int Limit
        {
            get
            {
                return _limit;
            }
            set
            {
                if (value > 0 && value < 251)
                {
                    _limit = value;
                }
                else
                {
                    _limit = 10;
                }
            }
        }

        public ForecastFilterTypes Filter { get; set; } = ForecastFilterTypes.NotSet;


    }
}
