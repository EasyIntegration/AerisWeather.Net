using System;
namespace AerisWeather.Net.Models.Exceptions
{
    public class LocationNotFoundException : ApplicationException
    {
        public LocationNotFoundException(string message, Exception e) : base(message, e)
        {}

        public LocationNotFoundException(string message) : base(message)
        {}
    }
}
