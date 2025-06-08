using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace WeatherApp1
{
    public partial class MainPage : ContentPage
    {
        readonly RestService _restService;
        List<string> _favorites = new();

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
            LoadFavorites();
        }

        async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            var city = _cityEntry.Text?.Trim();
            if (string.IsNullOrEmpty(city))
            {
                await DisplayAlert("Error", "Please enter a city name.", "OK");
                return;
            }

            // Pick units
            bool useImperial = UnitSwitch.IsToggled;
            var units = useImperial ? "imperial" : "metric";

            // Build request URL
            var url = $"{Constants.OpenWeatherMapEndpoint}"
                    + $"?q={Uri.EscapeDataString(city)}"
                    + $"&units={units}"
                    + $"&appid={Constants.OpenWeatherMapAPIKey}";

            // Fetch
            var data = await _restService.GetWeatherData(url);
            if (data == null)
            {
                await DisplayAlert("Error", "Could not fetch weather.", "OK");
                return;
            }

            // 1) Set dynamic background
            var main = data.Weather[0].Main.ToLower();
            var brushKey = main switch
            {
                "clear" => "SunnyGradient",
                "rain" => "RainyGradient",
                "drizzle" => "RainyGradient",
                "clouds" => "CloudyGradient",
                "snow" => "SnowyGradient",
                _ => "SunnyGradient"
            };
            if (Resources.ContainsKey(brushKey))
                Background = (Brush)Resources[brushKey];

            // 2) Condition icon
            ConditionImage.Source = data.Weather[0].Main.ToLower() switch
            {
                "clear" => "sunny.png",
                "snow" => "snowy.png",
                "rain" => "rainy.png",
                "drizzle" => "rainy.png",
                "clouds" => "cloudy.png",
                _ => "sunny.png"
            };

            // 3) Bind data + set labels
            BindingContext = data;
            TempLabel.Text = $"{data.Main.Temperature:F1} {(useImperial ? "°F" : "°C")}";
            DescLabel.Text = data.Weather[0].Description;

            // 4) Update favorite star
            FavoriteButton.Source = _favorites.Contains(data.Title)
                ? "star_filled.png"
                : "star_outline.png";

            // 5) Reveal panel
            WeatherPanel.IsVisible = true;
        }

        void OnFavoriteButtonClicked(object sender, EventArgs e)
        {
            if (BindingContext is not WeatherData data) return;
            var city = data.Title;

            if (_favorites.Contains(city))
                _favorites.Remove(city);
            else
                _favorites.Add(city);

            Preferences.Set("Favorites", string.Join(",", _favorites));

            FavoriteButton.Source = _favorites.Contains(city)
                ? "star_filled.png"
                : "star_outline.png";

            LoadFavorites();
        }

        void OnFavoriteSelected(object s, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0) return;
            var city = e.CurrentSelection[0] as string;
            _cityEntry.Text = city;
            OnGetWeatherClicked(this, EventArgs.Empty);
        }

        void LoadFavorites()
        {
            var saved = Preferences.Get("Favorites", "");
            _favorites = string.IsNullOrWhiteSpace(saved)
                ? new List<string>()
                : new List<string>(saved.Split(','));

            FavoritesView.ItemsSource = _favorites;
        }
    }
}
