using System;
namespace AerisWeather.Net.Clients
{
    public interface IConditions
    {

    }


    public class Conditions : AerisClient, IConditions
    {
        private const string ENDPOINT = "conditions";

        
    }
}
