using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FormTrackClient.ViewModels
{
    public partial class MainPageVM : BaseVM
    {
        [ObservableProperty]
        bool isAlertVisible=false;
        [ObservableProperty]
        string login = String.Empty;
        [ObservableProperty]
        string password = String.Empty;
        [ObservableProperty]
        string alertMessage;
        [ObservableProperty]
        bool isPasswordShow=true;
        [ObservableProperty]
        string passwordShowBtnText = "Show";

        [RelayCommand]
        void ExecuteLogin()
        {
            if(Login==String.Empty || Password == String.Empty)
            {
                AlertMessage = "Email or password is empty. Provide data and try again.";
                IsAlertVisible = true;
                return;
            }

        }

        [RelayCommand]
        async Task ShowRegisterPage()
        {
            await Shell.Current.GoToAsync("Register");
        }

        [RelayCommand]
        void EntryFocused()
        {
            IsAlertVisible = false;
        }

        [RelayCommand]
        void ChangePasswordVisible()
        {
            IsPasswordShow = !IsPasswordShow;
            if (IsPasswordShow)
            {
                PasswordShowBtnText = "Hide";
            }
            else
            {
                PasswordShowBtnText = "Show";
            }
        }

        [RelayCommand]
        async Task ShowRememberPasswordPage()
        {
            await Shell.Current.GoToAsync("RememberPassword");
        }

        [RelayCommand]
        async Task LoginWithProviders(string provider)
        {
            switch (provider)
            {
                case "fb":
                    break;
                case "google":
                    break;
            }
        }
    }
}