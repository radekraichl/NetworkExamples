using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenWeatherMap;

internal class OpenWeatherMapDataProvider
{
    private readonly string API_KEY = "3af09621cb03ff4438fd934032c2f0e9";

    public async Task<WeatherInfo> GetWeatherByCityName(string cityName)
    {
        return await GetWeatherInfo(GetRequestStringWeatherByCityName(cityName));
    }

    public async Task<WeatherInfo> GetWeatherByCityID(string id)
    {
        return await GetWeatherInfo(GetRequestStringWeatherByCityID(id));
    }

    public async Task<string> GetJson_WeatherByCityName(string cityName)
    {
        return await GetJsonFromRequest(GetRequestStringWeatherByCityName(cityName));
    }

    public async Task<string> GetJson_WeatherByCityID(string id)
    {
        return await GetJsonFromRequest(GetRequestStringWeatherByCityID(id));
    }

    public static async Task<string> GetJsonFromRequest(string request)
    {
        using HttpClient httpClient = new();
        using HttpResponseMessage response = await httpClient.GetAsync(request);

        if (response.IsSuccessStatusCode)
        {
            string jsonString = await response.Content.ReadAsStringAsync();

            JsonDocument jsonDocument = JsonDocument.Parse(jsonString);

            return JsonSerializer.Serialize(jsonDocument, new JsonSerializerOptions { WriteIndented = true });
        }

        return null;
    }

    private static async Task<WeatherInfo> GetWeatherInfo(string request)
    {
        string jsonString = await GetJsonFromRequest(request);

        if (jsonString != null)
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(jsonString);

            return new WeatherInfo
            {
                Longitude = (float)jsonDocument.RootElement.GetProperty("coord").GetProperty("lon").GetDouble(),
                Latitude = (float)jsonDocument.RootElement.GetProperty("coord").GetProperty("lat").GetDouble(),
                WeatherMain = jsonDocument.RootElement.GetProperty("weather")[0].GetProperty("main").GetString(),
                WeatherDescription = jsonDocument.RootElement.GetProperty("weather")[0].GetProperty("description").GetString(),
                Temperature = (float)jsonDocument.RootElement.GetProperty("main").GetProperty("temp").GetDouble(),
                Humidity = (int)jsonDocument.RootElement.GetProperty("main").GetProperty("humidity").GetDouble(),
                Pressure = (int)jsonDocument.RootElement.GetProperty("main").GetProperty("pressure").GetDouble(),
            };
        }

        return null;
    }

    private string GetRequestStringWeatherByCityName(string cityName)
    {
        return $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric&appid={API_KEY}&lang=cz";
    }

    private string GetRequestStringWeatherByCityID(string id)
    {
        return $"https://api.openweathermap.org/data/2.5/weather?id={id}&units=metric&appid={API_KEY}&lang=cz";
    }
}
