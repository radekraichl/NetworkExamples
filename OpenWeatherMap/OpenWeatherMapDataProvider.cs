using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenWeatherMap;

internal class OpenWeatherMapDataProvider
{
    private readonly string apiKey = Config.API_KEY;

    public async Task<WeatherInfo> GetWeatherByCityNameAsync(string cityName)
    {
        string request = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric&appid={apiKey}&lang=cz";
        return await GetWeatherInfoAsync(request);
    }

    public async Task<WeatherInfo> GetWeatherByCityIDAsync(string id)
    {
        string request = $"https://api.openweathermap.org/data/2.5/weather?id={id}&units=metric&appid={apiKey}&lang=cz";
        return await GetWeatherInfoAsync(request);
    }

    private static async Task<WeatherInfo> GetWeatherInfoAsync(string request)
    {
        using HttpClient httpClient = new();
        HttpResponseMessage response = await httpClient.GetAsync(request);

        if (response.IsSuccessStatusCode)
        
        {
            string jsonString = await response.Content.ReadAsStringAsync();

            using JsonDocument jsonDocument = JsonDocument.Parse(jsonString);

            return JsonSerializer.Deserialize<WeatherInfo>(jsonDocument);
        }

        return null;
    }
}
