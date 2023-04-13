namespace WeatherApp1; // Defining a namespace called "WeatherApp1".

public partial class MainPage : ContentPage // Defining a public partial class called "MainPage" that extends the ContentPage class.
{
    private RestService _restService; // Declaring a private variable of type RestService called "_restService".

    public MainPage() // Constructor for the MainPage class.
    {
        InitializeComponent(); // Initializing the MainPage component.
        _restService = new RestService(); // Instantiating a new RestService object and assigning it to the "_restService" variable.
    }

    async void OnGetWeatherButtonClicked(object sender, EventArgs e) // Defining an asynchronous event handler for the "Get Weather" button click event.
    {
        if (!string.IsNullOrWhiteSpace(_cityEntry.Text)) // Checking if the city entry field is not null or empty.
        {
            WeatherData weatherData = await
                _restService.
                GetWeatherData(GenerateRequestURL(Constants.OpenWeatherMapEndpoint)); // Using the RestService object to get the weather data for the entered city.

            BindingContext = weatherData; // Assigning the weather data object to the MainPage's BindingContext to update the UI.
        }
    }

    string GenerateRequestURL(string endPoint) // Defining a private method that returns a string and takes a string parameter called "endPoint".
    {
        string requestUri = endPoint; // Initializing the request URI to the specified endpoint.
        requestUri += $"?q={_cityEntry.Text}"; // Adding the entered city to the request URI.
        requestUri += "&units=imperial"; // Adding the unit of measurement for temperature to the request URI.
        requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}"; // Adding the API key to the request URI.
        return requestUri; // Returning the generated request URI.
    }
}
