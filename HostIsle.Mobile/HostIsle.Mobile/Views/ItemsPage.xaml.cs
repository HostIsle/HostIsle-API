using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostIsle.Mobile.Models;
using HostIsle.Mobile.ViewModels;
using HostIsle.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HostIsle.Mobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsPage"/> class.
        /// </summary>
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}