using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp1
{
    public class RestService
    {
        private readonly HttpClient _client;  // I use this client to call the weather API

        public RestService()
        {
            _client = new HttpClient();  // I create the HttpClient when my service starts
        }

        /// <summary>
        /// I fetch weather data from the given query URL and deserialize it.
        /// </summary>
        public async Task<WeatherData> GetWeatherData(string query)
        {
            try
            {
                // I send a GET to the OpenWeather endpoint
                var response = await _client.GetAsync(query);

                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"API error: {response.StatusCode}");
                    return null;
                }

                // I read the JSON payload
                var json = await response.Content.ReadAsStringAsync();

                // I turn it into my WeatherData model
                var data = JsonConvert.DeserializeObject<WeatherData>(json);
                return data;
            }
            catch (Exception ex)
            {
                // I log any error that bubbles up
                Debug.WriteLine($"Fetch failed: {ex.Message}");
                return null;
            }
        }
    }
}
