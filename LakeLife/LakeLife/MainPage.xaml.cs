using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using LakeLife.Models;
using System.Runtime.CompilerServices;
using LakeLife.Data;

namespace LakeLife
{
    public partial class MainPage : ContentPage
    {

        // test comments
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        protected  MainPage(Gig newItem)
        {
            this.CartItems.Add(newItem);
        }

        public List<GigType> GigTypeList => GetGigTypes();
        public List<Gig> GigList => GetGigs();

        public List<Gig> CartItems;

        public void addToCartItems(Gig newItem)
        {
           
        }

        private List<GigType> GetGigTypes()
        {
            return new List<GigType>
            {
                new GigType { TypeName = "All" },
                new GigType { TypeName = "Studio" },
                new GigType { TypeName = "4 Bed" },
                new GigType { TypeName = "3 Bed" },
                new GigType { TypeName = "Office" }
            };
        }

        private List<Gig> GetGigs()
        {
            return new List<Gig>
            {
                new Gig { Image = "boatFeet.jpg", GigName = "Tarp and Clean Package", Price = "$60",  Description = GigDescriptions.tarpNClean },
                new Gig { Image = "halfDetail.jpg", GigName = "Half Detail Package", Price = "$300",  Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Gig { Image = "fullDetail.jpg", GigName = "Full Detail Package", Price = "$900", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
            };
        }

        private async void GigSelected(object sender, EventArgs e)
        {
            var property = (sender as View).BindingContext as Gig;
            await this.Navigation.PushAsync(new DetailsPage(property));
        }

        private async void OpenCart(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new CartPage(CartItems));
        }

        private void SelectType(object sender, EventArgs e)
        {
            var view = sender as View;
            var parent = view.Parent as StackLayout;

            foreach (var child in parent.Children)
            {
                VisualStateManager.GoToState(child, "Normal");
                ChangeTextColor(child, "#707070");
            }

            VisualStateManager.GoToState(view, "Selected");
            ChangeTextColor(view, "#FFFFFF");
        }

        private void ChangeTextColor(View child, string hexColor)
        {
            var txtCtrl = child.FindByName<Label>("PropertyTypeName");

            if (txtCtrl != null)
                txtCtrl.TextColor = Color.FromHex(hexColor);
        }
    }

    public class GigType
    {
        public string TypeName { get; set; }
    }
}
