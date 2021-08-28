using System;
using HostIsle.Mobile.Services;
using HostIsle.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HostIsle.Mobile
{
    public partial class App : Application
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
