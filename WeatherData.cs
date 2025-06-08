using Newtonsoft.Json;

namespace WeatherApp1
{
    // I hold all the data returned by the OpenWeatherMap API
    public class WeatherData
    {
        [JsonProperty("name")]
        public string Title { get; set; }            // I map the city name

        [JsonProperty("coord")]
        public Coord Coordinates { get; set; }       // I store longitude & latitude

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }       // I store weather descriptions

        [JsonProperty("main")]
        public Main Main { get; set; }               // I store temp, pressure, humidity

        [JsonProperty("visibility")]
        public long Visibility { get; set; }         // I store visibility in meters

        [JsonProperty("wind")]
        public Wind Wind { get; set; }               // I store wind speed & direction

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }           // I store cloudiness percentage

        [JsonProperty("dt")]
        public long Timestamp { get; set; }          // I store the data timestamp

        [JsonProperty("sys")]
        public Sys Sys { get; set; }                 // I store country, sunrise, sunset

        [JsonProperty("id")]
        public long CityId { get; set; }             // I store the city’s unique ID

        [JsonProperty("cod")]
        public long StatusCode { get; set; }         // I store the API response code
    }

    // I store geographic coordinates
    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }

    // I store the main weather group and description
    public class Weather
    {
        [JsonProperty("id")]
        public long Id { get; set; }                 // Condition ID

        [JsonProperty("main")]
        public string Main { get; set; }             // Group (e.g., Rain, Clear)

        [JsonProperty("description")]
        public string Description { get; set; }      // Detailed description

        [JsonProperty("icon")]
        public string Icon { get; set; }             // Icon code
    }

    // I store temperature and related info
    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }
    }

    // I store wind speed and direction
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public long Degree { get; set; }
    }

    // I store cloudiness percentage
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }

    // I store system info: country code, sunrise/sunset
    public class Sys
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("sunset")]
        public long Sunset { get; set; }
    }
}
