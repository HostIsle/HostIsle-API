using System;
using System.Collections.Generic;
using HostIsle.Mobile.ViewModels;
using HostIsle.Mobile.Views;
using Xamarin.Forms;

namespace HostIsle.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
