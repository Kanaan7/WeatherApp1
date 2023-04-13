namespace WeatherApp1;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
        InitializeComponent();
	}

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    private void BtnLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new WelcomePage());
    }
}