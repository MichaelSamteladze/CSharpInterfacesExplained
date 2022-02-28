using System;
using System.Text;

namespace CSharpInterfacesExplained
{
    class Program
    {
        static void Main(string[] args)
        {
            var WeatherServiceProvider = new AwesomeWeatherService();
            //var WeatherServiceProvider = new WonderfulWeatherService();
            var City = "Tbilisi";

            var WP = new WeatherReport(WeatherServiceProvider);
            var Result = WP.GetCityCurrentTemperature(City);

            Console.WriteLine(Result);
        }
    }
}
