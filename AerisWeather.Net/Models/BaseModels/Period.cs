using System;
using Newtonsoft.Json;

namespace AerisWeather.Net.Models
{
    public class Period
    {
        public long? Timestamp { get; set; }

        [JsonProperty("dateTimeISO")]
        public DateTime? Date { get; set; }

        [JsonProperty("tempF")]
        public double? TemperatureFahrenheit { get; set; }

        [JsonProperty("tempC")]
        public double? TemperatureCelsius { get; set; }

        [JsonProperty("feelslikeC")]
        public double? FeelsLikeCelsius { get; set; }

        [JsonProperty("feelsLikeF")]
        public double? FeelsLikeFahrenheit { get; set; }

        [JsonProperty("dewpointC")]
        public double? DewPointCelsius { get; set; }

        [JsonProperty("dewpointF")]
        public double? DewPointFahrenheit { get; set; }

        public double? Humidity { get; set; }

        [JsonProperty("pressureMB")]
        public double? PressureMilibar { get; set; }

        [JsonProperty("pressureIN")]
        public double? PressureInches { get; set; }

        [JsonProperty("winDir")]
        public string WindDirection { get; set; }

        [JsonProperty("winDirDEG")]
        public double? WindDirectionDegrees { get; set; }

        [JsonProperty("windSpeedKTS")]
        public double? WindSpeedKnots { get; set; }

        [JsonProperty("windSpeedKPH")]
        public double? WindSpeedKilometers { get; set; }

        [JsonProperty("windSpeedMPH")]
        public double? WindSpeedMiles { get; set; }

        [JsonProperty("windGustsKTS")]
        public double? WindGustsKnots { get; set; }

        [JsonProperty("windGustsKPH")]
        public double? WindGustsKilometers { get; set; }

        [JsonProperty("windGustsMPH")]
        public double? WindGustsMiles { get; set; }

        [JsonProperty("pop")]
        public double? ProbabilityOfPrecipitation { get; set; }

        [JsonProperty("precipMM")]
        public double? PrecipitationMilimeters { get; set; }

        [JsonProperty("precipIN")]
        public double? PrecipitationInches { get; set; }

        [JsonProperty("snowCM")]
        public double? SnowCentimeters { get; set; }

        [JsonProperty("snowIN")]
        public double? SnowInches { get; set; }

        [JsonProperty("visibilityKM")]
        public double? VisibilityKilometers { get; set; }

        [JsonProperty("visibilityMI")]
        public double? VisibilityMiles { get; set; }

        [JsonProperty("sky")]
        public double? CloudCoveragePercentage { get; set; }

        [JsonProperty("cloudsCoded")]
        public string CloudCode { get; set; }

        [JsonProperty("weather")]
        public string WeatherPhrase { get; set; }

        //commented out 09/28/2021 - json deserialization kept breaking, because it is unclear what this type is. looks like a list of objects
        //[JsonProperty("weatherCoded")]
        //public List<string> WeatherCode { get; set; }

        [JsonProperty("weatherPrimary")]
        public string WeatherPrimaryPhrase { get; set; }

        [JsonProperty("weatherPrimaryCoded")]
        public string WeatherPrimaryCode { get; set; }

        public string Icon { get; set; }

        [JsonProperty("solradWM2")]
        public double? SolarRadiation { get; set; }

        [JsonProperty("uvi")]
        public double? UltravioletIndex { get; set; }

        [JsonProperty("isDay")]
        public bool IsDay { get; set; }
    }
}
