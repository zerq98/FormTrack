using FormTrackClient.ViewModels;

namespace FormTrackClient;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        this.Focus();
    }
}