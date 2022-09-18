using FormTrackClient.Views;

namespace FormTrackClient;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("Login", typeof(MainPage));
        Routing.RegisterRoute("Register", typeof(RegisterPage));
	}
}
