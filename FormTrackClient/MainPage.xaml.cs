namespace FormTrackClient;

public partial class MainPage : ContentPage
{
	public MainPage()
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

	private void ConfirmBtn_Clicked(object sender, EventArgs e)
	{

	}

	private void RememberPassword_Tapped(object sender, EventArgs e)
	{

	}

    private void Register_Tapped(object sender, EventArgs e)
    {

    }

    private void FbImage_Clicked(object sender,EventArgs e)
	{

	}

    private void GoogleImage_Clicked(object sender, EventArgs e)
    {

    }
}

