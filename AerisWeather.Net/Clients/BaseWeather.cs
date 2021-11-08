using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;

namespace AerisWeather.Net.Clients
{
    public abstract class BaseWeather
    {

        protected IAerisClient aerisClient;

        public BaseWeather(IAerisClient aerisClient)
        {
            this.aerisClient = aerisClient;
        }

        protected string EndPoint { get; set; }

        
    }
}
