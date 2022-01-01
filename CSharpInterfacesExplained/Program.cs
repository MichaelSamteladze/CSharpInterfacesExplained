using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterfacesExplained
{
    class Program
    {
        static void Main(string[] args)
        {
            var WeatherService1 = new WeatherService1();
            var WeatherService2 = new WeatherService2();

            var City = "Tbilisi";
            var T1 = GetTemperature(City, WeatherService1);
            var T2 = GetTemperature(City, WeatherService2);


            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Result from WeatherService1 - {City}: {T1}°C");            
            Console.WriteLine($"Result from WeatherService2 - {City}: {T2}°C");
            Console.WriteLine(Environment.NewLine);
        }

        static decimal? GetTemperature(string City, IWeatherService WeatherService)
        {
            var Result = WeatherService.GetCityTemperatureCelsius(City);
            return Result;
        }
    }
}
