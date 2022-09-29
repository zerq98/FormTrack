using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FormTrackClient.ViewModels
{
    public partial class HomePageVM : BaseVM
    {
        [ObservableProperty]
        private string username = $"Hi {MauiProgram.UserName}!!!";

        [RelayCommand]
        private async Task OpenPlansPageAsync(string page)
        {
        }

        [RelayCommand]
        private async Task ShowNavigationPageAsync(string page)
        {
        }
    }
}