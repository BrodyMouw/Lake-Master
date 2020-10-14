using LakeLife.Helpers;
using Plugin.SharedTransitions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("NunitoSans-Regular.ttf", Alias = "ThemeFontRegular")]
[assembly: ExportFont("NunitoSans-SemiBold.ttf", Alias = "ThemeFontSemiBold")]
[assembly: ExportFont("NunitoSans-Bold.ttf", Alias = "ThemeFontBold")]
[assembly: ExportFont("Balqis.ttf", Alias = "FancyFont")]
[assembly: ExportFont("FjallaOne-Regular.ttf", Alias = "Fjalla")]

namespace LakeLife
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new SharedTransitionNavigationPage(new SplashPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#5dade2"),
            };
        }

        protected override void OnStart()
        {
            Settings.Reset();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
