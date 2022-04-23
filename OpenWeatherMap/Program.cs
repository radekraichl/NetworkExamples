using System;
using System.Threading.Tasks;

namespace OpenWeatherMap
{
    class Program
    {
        static async Task Main()
        {
            OpenWeatherMapDataProvider weatherProvider = new();
            WeatherInfo weather = await weatherProvider.GetWeatherByCityNameAsync("Praha");

            Console.WriteLine($"Název:           {weather.Name}");
            Console.WriteLine($"Zeměpisná šířka: {weather.Coordinates.Longitude}");
            Console.WriteLine($"Zeměpisná délka: {weather.Coordinates.Latitude}");
            Console.WriteLine($"Počasí:          {weather.Weather[0].Main}, {weather.Weather[0].Description}");
            Console.WriteLine($"Teplota:         {weather.Main.Temperature}");
            Console.WriteLine($"Vlhkost:         {weather.Main.Humidity}");
            Console.WriteLine($"Tlak:            {weather.Main.Pressure}");
        }
    }
}
