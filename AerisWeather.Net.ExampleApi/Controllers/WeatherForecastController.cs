using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AerisWeather.Net.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AerisWeather.Net.ExampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IForecasts _forecasts;
        private readonly IPhrasesSummary _phraseSummary;
        private readonly ITides _tides;
        private readonly ISunMoon _sunMoon;

        public WeatherForecastController(ILogger<WeatherForecastController> logger
            , IForecasts forecasts
            , IPhrasesSummary phrasesSummary
            , ITides tides
            , ISunMoon sunMoon)
        {
            _logger = logger;
            _forecasts = forecasts;
            _phraseSummary = phrasesSummary;
            _tides = tides;
            _sunMoon = sunMoon;
        }

        public async Task<IActionResult> Get()
        {

            var list = new List<string>();

            list.Add("weatherForecast/Today/90210");
            list.Add("weatherForecast/Hourly/90210");
            list.Add("weatherForecast/Daily/90210");
            list.Add("weatherForecast/PhraseToday/90210");
            list.Add("weatherForecast/PhraseTomorrow/90210");
            list.Add("weatherForecast/TidesToday/90210");
            list.Add("weatherForecast/TidesDaily/90210");


            return Ok(list);

        }

        
        [HttpGet]
        [Route("Today/{location}", Name = "Today")]
        public async Task<IActionResult> Today(string location)
        {
            var forecasts = await _forecasts.TodayAsync(location);

            return Ok(forecasts.Periods.FirstOrDefault());
        }

        [HttpGet]
        [Route("Hourly/{location}", Name = "Hourly")]
        public async Task<IActionResult> Hourly(string location)
        {
            var forecasts = await _forecasts.HourlyAsync(location, 13);

            return Ok(forecasts.Periods);
        }

        [HttpGet]
        [Route("Daily/{location}", Name = "Daily")]
        public async Task<IActionResult> Daily(string location)
        {
            var forecasts = await _forecasts.DailyAsync(location,3);

            return Ok(forecasts.Periods);
        }

        [HttpGet]
        [Route("PhraseToday/{location}", Name = "PhraseToday")]
        public async Task<IActionResult> PhraseToday(string location)
        {
            var forecasts = await _phraseSummary.TodayAsync(location);

            return Ok(forecasts);
        }

        [HttpGet]
        [Route("PhraseTomorrow/{location}", Name = "PhraseTomorrow")]
        public async Task<IActionResult> PhraseTomorrow(string location)
        {
            var forecasts = await _phraseSummary.NextNHours(location,48);

            return Ok(forecasts);
        }

        [HttpGet]
        [Route("TidesToday/{location}", Name = "TidesToday")]
        public async Task<IActionResult> TidesToday(string location)
        {
            var forecasts = await _tides.TodayAsync(location);

            return Ok(forecasts);
        }

        [HttpGet]
        [Route("TidesDaily/{location}", Name = "TidesDaily")]
        public async Task<IActionResult> TidesDaily(string location)
        {
            var forecasts = await _tides.DailyAsync(location,7);

            return Ok(forecasts);
        }

        [HttpGet]
        [Route("SunMoonDaily/{location}", Name = "SunMoonDaily")]
        public async Task<IActionResult> SunMoonDaily(string location)
        {
            var forecasts = await _sunMoon.DailyAsync(location, 7);

            return Ok(forecasts);
        }


        [HttpGet]
        [Route("SunMoonToday/{location}", Name = "SunMoonToday")]
        public async Task<IActionResult> SunMoonToday(string location)
        {
            var forecasts = await _sunMoon.TodayAsync(location);

            return Ok(forecasts);
        }
    }
}
