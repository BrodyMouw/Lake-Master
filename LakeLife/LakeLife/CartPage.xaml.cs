using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LakeLife.Models;

namespace LakeLife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public List<Gig> ShoppingList;
        public CartPage(List<Gig> cartItems)
        {
            InitializeComponent();
            this.ShoppingList = cartItems;
        }

        private void GoBack(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}