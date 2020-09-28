﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        public List<GigType> GigTypeList => GetGigTypes();
        public List<Gig> GigList => GetGigs();

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
                new Gig { Image = "apt1.png", Address = "2162 Patricia Ave, LA", Location = "Califonia", Price = "$1500/mo", Bed = "4 Bed", Bath = "3 Bath", Space = "1600 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Gig { Image = "apt2.png", Address = "2168 Cushions Dr, LA", Location = "Califonia", Price = "$1000/mo", Bed = "3 Bed", Bath = "1 Bath", Space = "1100 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Gig { Image = "apt3.png", Address = "2112 Anthony Way, LA", Location = "Califonia", Price = "$900/mo", Bed = "2 Bed", Bath = "2 Bath", Space = "1200 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
            };
        }

        private async void GigSelected(object sender, EventArgs e)
        {
            var property = (sender as View).BindingContext as Gig;
            await this.Navigation.PushAsync(new DetailsPage(property));
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

    public class Gig
    {
        public string Id => Guid.NewGuid().ToString("N");
        public string PropertyName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Bed { get; set; }
        public string Bath { get; set; }
        public string Space { get; set; }
        public string Details { get; set; }
    }
}
