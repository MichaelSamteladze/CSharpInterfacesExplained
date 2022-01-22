using System;
using System.Text;

namespace CSharpInterfacesExplained
{
    class Program
    {
        static void Main(string[] args)
        {
            var AwesomeService = new AwesomeWeatherService();
            var WonderfulService = new WonderfulWeatherService();

            var City = "Tbilisi";
            var Result1 = GetTemperatureFormatted(City, AwesomeService);
            var Result2 = GetTemperatureFormatted(City, WonderfulService);


            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"AwesomeService - {Result1}");
            Console.WriteLine($"WonderfulService - {Result2}");
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
