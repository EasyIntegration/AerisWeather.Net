using System;
using System.Threading.Tasks;

namespace AerisWeather.Net.Clients
{
    public interface IWeather<T>
    {
        Task<T> Today(string location);
        Task<T> Today(double lat, double lon);

        Task<T> Hourly(string location, int hours);
        Task<T> Hourly(double lat, double lon, int hours);
        Task<T> Hourly(string location, int hours, DateTime startDate);
        Task<T> Hourly(double lat, double lon, int hours, DateTime startDate);

        Task<T> Daily(string location, int days);
        Task<T> Daily(double lat, double lon, int days);
        Task<T> Daily(string location, int days, DateTime startDate);
        Task<T> Daily(double lat, double lon, int days, DateTime startDate);
    }
}
