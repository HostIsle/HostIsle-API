using System.ComponentModel;
using HostIsle.Mobile.ViewModels;
using Xamarin.Forms;

namespace HostIsle.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDetailPage"/> class.
        /// </summary>
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}