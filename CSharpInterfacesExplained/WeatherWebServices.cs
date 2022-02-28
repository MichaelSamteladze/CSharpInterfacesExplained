using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpInterfacesExplained
{
    public class AwesomeWeatherService : IWeatherService
    {
        const string Key = "95b6a93e20294aa2be7210523220101";

        public decimal? GetCityTemperatureCelsius(string City)
        {            
            var Result = default(decimal?);
            try
            {
                var Endpoint = $"http://api.weatherapi.com/v1/current.json?key={Key}&q={City}";
                using (var WC = new WebClient())
                {
                    var ResponseString = WC.DownloadString(Endpoint);
                    var Response = JsonSerializer.Deserialize<CurrentTemperatureResponse>(ResponseString);
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

        public class CurrentTemperatureResponse
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

    public class WonderfulWeatherService : IWeatherService
    {
        const string AccessKey = "99fc7e405ab9a2a2c34583da9c31bd37";

        public decimal? GetCityTemperatureCelsius(string City)
        {
            var TemperatureCelsius = default(decimal?);
            try
            {
                var Endpoint = $"http://api.weatherstack.com/current?access_key={AccessKey}&query={City}";
                using (var WC = new WebClient())
                {
                    var ResponseString = WC.DownloadString(Endpoint);
                    var Response = JsonSerializer.Deserialize<WeatherResponse>(ResponseString);
                    if (Response != null && Response.Current != null)
                    {
                        TemperatureCelsius = Response.Current.TemperatureCelsius;
                    }
                }
            }
            catch
            {

            }
            return TemperatureCelsius;
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