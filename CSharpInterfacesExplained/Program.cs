using System;
using System.Text;

namespace CSharpInterfacesExplained
{
    class Program
    {
        static void Main(string[] args)
        {
            var WeatherService1 = new WeatherService1();
            var WeatherService2 = new WeatherService2();

            var City = "Tbilisi";
            var Result1 = GetTemperatureFormatted(City, WeatherService1);
            var Result2 = GetTemperatureFormatted(City, WeatherService2);


            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Result from WeatherService1 - {Result1}");
            Console.WriteLine($"Result from WeatherService2 - {Result2}");
            Console.WriteLine(Environment.NewLine);
        }

        static string GetTemperatureFormatted(string City, IWeatherService WeatherService)
        {
            var Temperature = WeatherService.GetCityTemperatureCelsius(City);
            var Result = $"Today is {Temperature}°C in {City}";
            return Result;
        }
    }
}
