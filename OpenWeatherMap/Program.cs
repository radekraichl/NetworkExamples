using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
    class Program
    {
        static async Task Main()
        {
            OpenWeatherMapDataProvider weatherProvider = new();

            WeatherInfo weather = await weatherProvider.GetWeatherByCityName("Fojtovice");
            //WeatherInfo weather = await weatherProvider.GetWeatherByCityID("3063548");

            string json = await weatherProvider.GetJson_WeatherByCityName("sdfsdfsdfsd");
            Console.WriteLine(json);

            //Console.WriteLine($"Zeměpisná šířka: {weather.Longitude}");
            //Console.WriteLine($"Zeměpisná délka: {weather.Latitude}");
            //Console.WriteLine($"Počasí:          {weather.WeatherMain}, {weather.WeatherDescription}");
            //Console.WriteLine($"Teplota:         {MathF.Round(weather.Temperature, 1)}");
            //Console.WriteLine($"Vlhkost:         {weather.Humidity}");
            //Console.WriteLine($"Tlak:            {weather.Pressure}");
        }
    }
}
