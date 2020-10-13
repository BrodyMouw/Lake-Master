using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LakeLife.Models;
using LakeLife.ViewModels;

namespace LakeLife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {

        public CartPageViewModel _ViewModel;
        public CartPage()
        {
            InitializeComponent();
            BindingContext = _ViewModel = new CartPageViewModel();
        }

        private void GoBack(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
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