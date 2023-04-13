using Newtonsoft.Json; // Importing the Newtonsoft.Json namespace for deserializing JSON.
using System;
using System.Collections.Generic;
using System.Diagnostics; // Importing the System.Diagnostics namespace for debugging.
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherApp1 // Defining a namespace called "WeatherApp1".
{
    public class RestService // Defining a public class called "RestService".
    {
        private HttpClient _client; // Declaring a private variable of type HttpClient called "_client".

        public RestService() // Constructor for the RestService class.
        {
            _client = new HttpClient(); // Instantiating a new HttpClient object and assigning it to the "_client" variable.
        }

        public async Task<WeatherData> GetWeatherData(string query) // Defining a public asynchronous method that returns a Task object of type WeatherData, with a string parameter called "query".
        {
            WeatherData weatherData = null; // Declaring a variable of type WeatherData called "weatherData" and initializing it to null.

            try // Starting a try block.
            {
                var response = await _client.GetAsync(query); // Sending a GET request to the specified URI and getting the response in a variable called "response".
                if (response.IsSuccessStatusCode) // Checking if the response is successful (has a 200 series status code).
                {
                    var content = await response.Content.ReadAsStringAsync(); // Reading the response content as a string and storing it in a variable called "content".
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content); // Deserializing the JSON string into a WeatherData object and assigning it to the "weatherData" variable.
                }
            }
            catch (Exception ex) // Catching any exception that occurs in the try block and assigning it to a variable called "ex".
            {
                Debug.WriteLine(ex.Message); // Writing the error message to the debugger output window.
                throw; // Rethrowing the exception to the calling code.
            }
            return weatherData; // Returning the "weatherData" object.
        }
    }
}
