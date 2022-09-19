using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTrackClient.ViewModels
{
    public partial class RegisterPageVM : BaseVM
    {
        [ObservableProperty]
        string email = string.Empty;
        [ObservableProperty]
        string username = string.Empty;
        [ObservableProperty]
        string password = string.Empty;
        [ObservableProperty]
        string confirmPassword = string.Empty;
        [ObservableProperty]
        string showPasswordBtnText = string.Empty;
        [ObservableProperty]
        string showConfirmPasswordBtnText = string.Empty;
        [ObservableProperty]
        string alertMessage = string.Empty;
        [ObservableProperty]
        bool isAlertVisible = false;
        [ObservableProperty]
        bool isPasswordVisible = true;
        [ObservableProperty]
        bool isConfirmPasswordVisible = true;
        [ObservableProperty]
        bool isNormalUser = true;

        [RelayCommand]
        void EntryFocused()
        {
            IsAlertVisible = false;
        }

        [RelayCommand]
        void ChangePasswordVisible()
        {
            IsPasswordVisible = !IsPasswordVisible;
            if (IsPasswordVisible)
            {
                ShowPasswordBtnText = "Hide";
            }
            else
            {
                ShowPasswordBtnText = "Show";
            }
        }

        [RelayCommand]
        void ChangeConfirmPasswordVisible()
        {
            IsConfirmPasswordVisible = !IsConfirmPasswordVisible;
            if (IsPasswordVisible)
            {
                ShowConfirmPasswordBtnText = "Hide";
            }
            else
            {
                ShowConfirmPasswordBtnText = "Show";
            }
        }

        [RelayCommand]
        async Task ShowLoginPage()
        {
            await Shell.Current.GoToAsync("Login");
        }

        [RelayCommand]
        void ExecuteRegister()
        {
            if(Email==String.Empty || Password==String.Empty || ConfirmPassword == String.Empty)
            {
                IsAlertVisible = true;
                AlertMessage = "Some of required fields are empty. Please provide data and try again.";
            }
        }
    }
}
