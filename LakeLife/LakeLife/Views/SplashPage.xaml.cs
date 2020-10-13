using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LakeLife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            this.Title = "Lake Life";
            this.BindingContext = this;
        }

        private async void GetStarted(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SharedTransitionNavigationPage(new MainPage()));
        }

    }
}