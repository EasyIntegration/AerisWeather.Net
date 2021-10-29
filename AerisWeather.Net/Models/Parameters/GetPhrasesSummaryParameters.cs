using System;
namespace AerisWeather.Net.Models
{
    public class GetPhrasesSummaryParameters
    {
        private int _limit = 1;

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
                if (value > 0 && value <= 250)
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
