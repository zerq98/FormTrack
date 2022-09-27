using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FormTrackClient.Api;
using FormTrackClient.Models.Dtos;

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
        async Task ExecuteLogin()
        {
            if(Login==String.Empty || Password == String.Empty)
            {
                AlertMessage = "Email or password is empty. Provide data and try again.";
                IsAlertVisible = true;
                return;
            }

            var apiClient = new ApiClient();
            var response = await apiClient.LoginAsync(new LoginDto
            {
                Email = login,
                Password = password
            });

            if(response == null)
            {
                AlertMessage = "There was a problem with connection to server.";
                IsAlertVisible = true;
                return;
            }

            if (response.Code == 200)
            {
                MauiProgram.TokenExpireDate = response.Data.ExpireDate;
                MauiProgram.BearerToken = response.Data.Token;
                MauiProgram.UserName = response.Data.Username;
                await Shell.Current.GoToAsync("Home");
            }
            else
            {
                AlertMessage = response.ErrorMessage;
                IsAlertVisible = true;
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
            if (!IsPasswordShow)
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