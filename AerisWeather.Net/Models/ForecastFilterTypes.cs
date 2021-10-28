using System;
namespace AerisWeather.Net.Models
{
    public enum ForecastFilterTypes
    {
        NotSet,
        OneHour,
        TwoHour,
        ThreeHour,
        FourHour,
        SixHour,
        TwelveHour,
        TwentyFourHour,
        SeventyTwoHour,
        Day,
        DayNight
    }

    public static class ForecastFilterTypesExt
    {

        public static string ToStringExt(this ForecastFilterTypes filter)
        {

            switch (filter)
            {
                case ForecastFilterTypes.OneHour:
                    return "1hr";
                case ForecastFilterTypes.TwelveHour:
                    return "2hr";
                case ForecastFilterTypes.Day:
                    return "day";
                case ForecastFilterTypes.DayNight:
                    return "daynight";
                default:
                    return null;

            }


        }

    }
}
