using System;
using System.Threading.Tasks;

namespace AerisWeather.Net.Clients
{
    
    public interface IWeatherToday<T>
    {
        Task<T> TodayAsync(int zip);
        Task<T> TodayAsync(string city, string state);
        Task<T> TodayAsync(double lat, double lon);
        Task<T> TodayAsync(string location);
    }

    public interface IWeatherHourly<T>
    {
        Task<T> HourlyAsync(int zip, int hours);
        Task<T> HourlyAsync(string city, string state, int hours);
        Task<T> HourlyAsync(double lat, double lon, int hours);
        Task<T> HourlyAsync(string location, int hours);


        Task<T> HourlyAsync(int zip, int hours, DateTime startDate);
        Task<T> HourlyAsync(string city, string state, int hours, DateTime startDate);
        Task<T> HourlyAsync(string location, int hours, DateTime startDate);
        Task<T> HourlyAsync(double lat, double lon, int hours, DateTime startDate);
    }

    public interface IWeatherDaily<T>
    {
        Task<T> DailyAsync(int zip, int days);
        Task<T> DailyAsync(string city, string state, int days);
        Task<T> DailyAsync(string location, int days);
        Task<T> DailyAsync(double lat, double lon, int days);


        Task<T> DailyAsync(int zip, int days, DateTime startDate);
        Task<T> DailyAsync(string city, string state, int days, DateTime startDate);
        Task<T> DailyAsync(string location, int days, DateTime startDate);
        Task<T> DailyAsync(double lat, double lon, int days, DateTime startDate);
    }
}
