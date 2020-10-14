using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using LakeLife.Models;
using LakeLife.ViewModels;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace LakeLife
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel _ViewModel;

        // test comments
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _ViewModel = new MainPageViewModel();   
        }

        private async void GigSelected(object sender, EventArgs e)
        {
            var property = (sender as View).BindingContext as Gig;
            await this.Navigation.PushAsync(new DetailsPage(property));
        }

        private async void OpenCart(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new CartPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Run(() =>
            {
                _ViewModel.GetData.Execute(null);
            });
        }
    }
}
