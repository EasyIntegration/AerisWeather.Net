using System;
using System.Collections.Generic;

namespace AerisWeather.Net.Models
{
    public class AerisResponse<T>
    {
        public bool success { get; set; }
        public AerisError error { get; set; }
        public T response { get; set; }
    }

    public class AerisError
    {
        public string Code { get; set; }

        public string Description { get; set; }
    }
}
