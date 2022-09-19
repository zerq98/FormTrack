using FormTrackClient.ViewModels;

namespace FormTrackClient;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void RememberPassword_Tapped(object sender, EventArgs e)
    {
    }

    private void FbImage_Clicked(object sender, EventArgs e)
    {
    }

    private void GoogleImage_Clicked(object sender, EventArgs e)
    {
    }
}