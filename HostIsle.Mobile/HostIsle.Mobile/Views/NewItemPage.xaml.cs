using System;
using System.Collections.Generic;
using System.ComponentModel;
using HostIsle.Mobile.Models;
using HostIsle.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HostIsle.Mobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewItemPage"/> class.
        /// </summary>
        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}