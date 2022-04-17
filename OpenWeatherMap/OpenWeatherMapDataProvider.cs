using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenWeatherMap;

internal class OpenWeatherMapDataProvider
{
    private readonly string API_KEY = "3af09621cb03ff4438fd934032c2f0e9";

    public async Task<WeatherInfo> GetWeatherByCityNameAsync(string cityName)
    {
        string request = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric&appid={API_KEY}&lang=cz";
        return await GetWeatherInfoAsync(request);
    }

    public async Task<WeatherInfo> GetWeatherByCityIDAsync(string id)
    {
        string request = $"https://api.openweathermap.org/data/2.5/weather?id={id}&units=metric&appid={API_KEY}&lang=cz";
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
