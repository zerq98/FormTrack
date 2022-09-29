using FormTrackClient.ViewModels;

namespace FormTrackClient.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}