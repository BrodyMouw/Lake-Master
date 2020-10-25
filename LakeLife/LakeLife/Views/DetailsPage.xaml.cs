using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LakeLife.Models;
using LakeLife.Helpers;

namespace LakeLife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Gig gig)
        {
            InitializeComponent();
            this.Gig = gig;
            this.BindingContext = this;
        }

        public Gig Gig { get; set; }

        private void AddToCart(object sender, EventArgs e)
        {
            AddedPopUp.HeightRequest = 40;
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var selectedItem = this.Gig;

                var index = selectedItem.Index;
                if (index == 1)
                    Settings.ItemStatus1 = true;
                if (index == 2)
                    Settings.ItemStatus2 = true;
                if (index == 3)
                    Settings.ItemStatus3 = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is " + ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void GoBack(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AddedPopUp.HeightRequest = 0;
            DetailsView.TranslationY = 600;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
            AddedPopUp.HeightRequest = 0;
        }
    }
}