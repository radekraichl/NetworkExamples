namespace OpenWeatherMap;

class WeatherInfo
{
    public float Longitude { get; set; }
    public float Latitude { get; set; }
    public string WeatherMain { get; set; }
    public string WeatherDescription { get; set; }
    public float Temperature { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
}
