using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterfacesExplained
{
    public class WeatherReport
    {
        private IWeatherService WeatherServiceProvider;

        public WeatherReport(IWeatherService WeatherServiceProvider)
        {
            this.WeatherServiceProvider = WeatherServiceProvider;
        }

        public string GetCityCurrentTemperature(string City)
        {
            var TemperatureValue = default(decimal?);

            TemperatureValue = WeatherServiceProvider.GetCityTemperatureCelsius(City);

            var TemperatureStringFormatted = $"Today is {TemperatureValue}°C in {City}";
            return TemperatureStringFormatted;
        }
    }
}