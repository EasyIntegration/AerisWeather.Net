using System;
using System.Threading.Tasks;

namespace AerisWeather.Net.Clients
{

    public interface IWeatherNow<T>
    {

        Task<T> NowAsync(string city, string state);
        Task<T> NowAsync(double lat, double lon);
        Task<T> NowAsync(string zip);
    }


    public interface IWeatherToday<T>
    {
        
        Task<T> TodayAsync(string city, string state);
        Task<T> TodayAsync(double lat, double lon);
        Task<T> TodayAsync(string zip);
    }

    public interface IWeatherHourly<T>
    {
        
        Task<T> HourlyAsync(string city, string state, int hours);
        Task<T> HourlyAsync(double lat, double lon, int hours);
        Task<T> HourlyAsync(string zip, int hours);


        
        Task<T> HourlyAsync(string city, string state, int hours, DateTime startDate);
        Task<T> HourlyAsync(string zip, int hours, DateTime startDate);
        Task<T> HourlyAsync(double lat, double lon, int hours, DateTime startDate);
    }

    public interface IWeatherDaily<T>
    {
       
        Task<T> DailyAsync(string city, string state, int days);
        Task<T> DailyAsync(string zip, int days);
        Task<T> DailyAsync(double lat, double lon, int days);


        Task<T> DailyAsync(string city, string state, int days, DateTime startDate);
        Task<T> DailyAsync(string zip, int days, DateTime startDate);
        Task<T> DailyAsync(double lat, double lon, int days, DateTime startDate);
    }
}
