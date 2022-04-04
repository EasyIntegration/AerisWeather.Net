using System;
namespace AerisWeather.Net.Models.Parameters
{
    public class GetConditionsParameters
    {
        private int _limit = 24;

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public int Limit
        {
            get
            {
                return _limit;
            }
            set
            {
                if (value > 0 && value <= 24)
                {
                    _limit = value;
                }
                else
                {
                    _limit = 10;
                }
            }
        }

    }
}
