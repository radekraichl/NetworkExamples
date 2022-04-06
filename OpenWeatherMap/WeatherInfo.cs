namespace OpenWeatherMap;
using System.Text.Json;
using System.Text.Json.Serialization;


class WeatherInfo
{
    [JsonPropertyName("id")] 
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("coord")]
    public Coord Coord { get; set; }
    
    //public float Longitude { get; set; }
    //public float Latitude { get; set; }
    //public string WeatherMain { get; set; }
    //public string WeatherDescription { get; set; }
    //public float Temperature { get; set; }
    //public int Pressure { get; set; }
    //public int Humidity { get; set; }
}

class Coord
{
    [JsonPropertyName("lon")]
    public float Lon { get; set; }
    
    [JsonPropertyName("lat")]
    public float Lat { get; set; }
}
