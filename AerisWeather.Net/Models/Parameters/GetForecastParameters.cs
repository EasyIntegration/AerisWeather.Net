using System;
using System.Collections.Generic;
using System.Linq;

namespace AerisWeather.Net.Models
{
    public class GetForecastParameters
    {
        private int _limit = 10;

        public DateTime? To { get; set; }
        public DateTime? From { get; set; }

        public int Limit
        {
            get
            {
                return _limit;
            }
            set
            {
                if (value > 0 && value < 360)
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
