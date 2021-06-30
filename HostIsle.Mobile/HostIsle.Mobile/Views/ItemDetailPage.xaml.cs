using HostIsle.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HostIsle.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}