using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTrackClient.ViewModels
{
    public partial class HomePageVM:BaseVM
    {
        [ObservableProperty]
        string username = $"Hi {MauiProgram.UserName}!!!";

        [RelayCommand]
        async Task OpenPlansPageAsync(string page)
        {
        }

        [RelayCommand]
        async Task ShowNavigationPageAsync(string page)
        {

        }
    }
}
