using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FormTrackClient.Api;
using FormTrackClient.Models.Dtos;

namespace FormTrackClient.ViewModels
{
    public partial class MainPageVM : BaseVM
    {
        [ObservableProperty]
        private bool isAlertVisible = false;

        [ObservableProperty]
        private string login = String.Empty;

        [ObservableProperty]
        private string password = String.Empty;

        [ObservableProperty]
        private string alertMessage;

        [ObservableProperty]
        private bool isPasswordShow = true;

        [ObservableProperty]
        private string passwordShowBtnText = "Show";

        [RelayCommand]
        private void SelectNextControl(Entry entry)
        {
            entry.Focus();
        }

        [RelayCommand]
        private async Task ExecuteLogin()
        {
            if (Login == String.Empty || Password == String.Empty)
            {
                AlertMessage = "Email or password is empty. Provide data and try again.";
                await Shell.Current.DisplayAlert("", AlertMessage, "Try again");
                return;
            }

            var apiClient = new ApiClient();
            var response = await apiClient.LoginAsync(new LoginDto
            {
                Email = login,
                Password = password
            });

            if (response == null)
            {
                AlertMessage = "There was a problem with connection to server.";
                await Shell.Current.DisplayAlert("", AlertMessage, "Try again");
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
                await Shell.Current.DisplayAlert("", AlertMessage, "Try again");
            }
        }

        [RelayCommand]
        private async Task ShowRegisterPage()
        {
            await Shell.Current.GoToAsync("Register");
        }

        [RelayCommand]
        private void EntryFocused()
        {
            IsAlertVisible = false;
        }

        [RelayCommand]
        private void ChangePasswordVisible()
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
        private async Task ShowRememberPasswordPage()
        {
            await Shell.Current.GoToAsync("RememberPassword");
        }

        [RelayCommand]
        private async Task LoginWithProviders(string provider)
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