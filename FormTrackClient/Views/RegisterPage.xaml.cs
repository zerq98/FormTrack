namespace FormTrackClient.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private void ShowPassBtn_Clicked(object sender, EventArgs e)
    {
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        if (PasswordEntry.IsPassword)
        {
            ShowPassBtn.Text = "Show";
        }
        else
        {
            ShowPassBtn.Text = "Hide";
        }
    }

    private void ShowConfirmPassBtn_Clicked(object sender, EventArgs e)
    {
        ConfirmPasswordEntry.IsPassword = !ConfirmPasswordEntry.IsPassword;
        if (ConfirmPasswordEntry.IsPassword)
        {
            ShowConfirmPassBtn.Text = "Show";
        }
        else
        {
            ShowConfirmPassBtn.Text = "Hide";
        }
    }

    private void ConfirmBtn_Clicked(object sender, EventArgs e)
    {

    }

    private async void Login_Tapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Login");
    }
}