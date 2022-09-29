using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FormTrackClient.Api;
using FormTrackClient.Models.Dtos;

namespace FormTrackClient.ViewModels
{
    public partial class RegisterPageVM : BaseVM
    {
        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string confirmPassword = string.Empty;

        [ObservableProperty]
        private string showPasswordBtnText = "Show";

        [ObservableProperty]
        private string showConfirmPasswordBtnText = "Show";

        [ObservableProperty]
        private string alertMessage = string.Empty;

        [ObservableProperty]
        private bool isAlertVisible = false;

        [ObservableProperty]
        private bool isPasswordVisible = true;

        [ObservableProperty]
        private bool isConfirmPasswordVisible = true;

        [ObservableProperty]
        private bool isPersonalTrainer = false;

        [ObservableProperty]
        private bool isNormalUser = true;

        [RelayCommand]
        private void EntryFocused()
        {
            IsAlertVisible = false;
        }

        [RelayCommand]
        private void ChangePasswordVisible()
        {
            IsPasswordVisible = !IsPasswordVisible;
            if (!IsPasswordVisible)
            {
                ShowPasswordBtnText = "Hide";
            }
            else
            {
                ShowPasswordBtnText = "Show";
            }
        }

        [RelayCommand]
        private void ChangeConfirmPasswordVisible()
        {
            IsConfirmPasswordVisible = !IsConfirmPasswordVisible;
            if (!IsPasswordVisible)
            {
                ShowConfirmPasswordBtnText = "Hide";
            }
            else
            {
                ShowConfirmPasswordBtnText = "Show";
            }
        }

        [RelayCommand]
        private async Task ShowLoginPage()
        {
            await Shell.Current.GoToAsync("Register");
        }

        [RelayCommand]
        private async Task ExecuteRegister()
        {
            if (Email == String.Empty || Password == String.Empty || ConfirmPassword == String.Empty)
            {
                AlertMessage = "Some of required fields are empty. Please provide data and try again.";
                await Shell.Current.DisplayAlert("", AlertMessage, "Try again");
                return;
            }

            if (Password != ConfirmPassword)
            {
                AlertMessage = "Password and confirm password are not the same.";
                await Shell.Current.DisplayAlert("", AlertMessage, "Try again");
                return;
            }

            var apiClient = new ApiClient();
            var response = await apiClient.RegisterAsync(new RegisterDto
            {
                Email = Email,
                IsNormalUser = IsNormalUser,
                Password = Password,
                Username = Username,
            });

            if (response == null)
            {
                AlertMessage = "Something went wrong. Try again.";
                await Shell.Current.DisplayAlert("", AlertMessage, "Try again");
                return;
            }

            if (response.Code != 201)
            {
                AlertMessage = response.ErrorMessage;
                await Shell.Current.DisplayAlert("", AlertMessage, "Try again");
                return;
            }

            await Shell.Current.DisplayAlert("", response.ErrorMessage, "OK");

            await Task.Delay(5000);
            await Shell.Current.GoToAsync("Login/Register");
        }

        [RelayCommand]
        private void ChangeUserType()
        {
            IsPersonalTrainer = !IsPersonalTrainer;
        }
    }
}