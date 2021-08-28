using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HostIsle.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutViewModel"/> class.
        /// </summary>
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}