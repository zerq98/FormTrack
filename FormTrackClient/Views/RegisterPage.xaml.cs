using FormTrackClient.ViewModels;

namespace FormTrackClient.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterPageVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}