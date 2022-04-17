using System.Text.Json.Serialization;

namespace OpenWeatherMap;

internal class WeatherInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("coord")]
    public Coordinates Coordinates { get; set; }

    [JsonPropertyName("weather")]
    public Weather[] Weather { get; set; }
}

internal class Coordinates
{
    [JsonPropertyName("lon")]
    public float Longitude { get; set; }

    [JsonPropertyName("lat")]
    public float Latitude { get; set; }
}

internal class Weather
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("main")]
    public string Main { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}
