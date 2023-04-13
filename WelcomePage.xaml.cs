namespace WeatherApp1;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}
	// Makes the welcome page the main page
    private void BtnGetStarted_Clicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new MainPage());
    }
}