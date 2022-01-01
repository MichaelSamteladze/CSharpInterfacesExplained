using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSharpInterfacesExplained
{
    public class WeatherService1 : IWeatherService
    {
        public decimal? GetCityTemperatureCelsius(string City)
        {            
            var Result = default(decimal?);
            try
            {
                var Endpoint = $"http://api.weatherapi.com/v1/current.json?key=95b6a93e20294aa2be7210523220101&q={City}";
                using (var WC = new WebClient())
                {
                    var ResponseString = WC.DownloadString(Endpoint);
                    var Response = JsonSerializer.Deserialize<WeatherResponse>(ResponseString);
                    if (Response != null && Response.Current !=null)
                    {
                        Result = Response.Current.TemperatureCelsius;
                    }
                }
            }
            catch
            {

            }
            return Result;
        }  

        public class WeatherResponse
        {
            [JsonPropertyName("current")]
            public CurrentItem Current { get; set; }

            public class CurrentItem
            {
                [JsonPropertyName("temp_c")]
                public decimal TemperatureCelsius { get; set; }
                [JsonPropertyName("temp_f")]
                public decimal TemperatureFahrenheit { get; set; }
            }
        }
    }

    public class WeatherService2 : IWeatherService
    {
        public decimal? GetCityTemperatureCelsius(string City)
        {
            var Result = default(decimal?);
            try
            {
                var Endpoint = $"http://api.weatherstack.com/current?access_key=99fc7e405ab9a2a2c34583da9c31bd37&query={City}";
                using (var WC = new WebClient())
                {
                    var ResponseString = WC.DownloadString(Endpoint);
                    var Response = JsonSerializer.Deserialize<WeatherResponse>(ResponseString);
                    if (Response != null && Response.Current != null)
                    {
                        Result = Response.Current.TemperatureCelsius;
                    }
                }
            }
            catch
            {

            }
            return Result;
        }

        public class WeatherResponse
        {
            [JsonPropertyName("current")]
            public CurrentItem Current { get; set; }

            public class CurrentItem
            {
                [JsonPropertyName("temperature")]
                public decimal TemperatureCelsius { get; set; }                
            }
        }
    }
}
