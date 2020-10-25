using LakeLife.Helpers;
using LakeLife.Models;
using LakeLife.Services.ServiceInterface;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LakeLife.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public List<GigType> GigTypeList => GetGigTypes();
        public ObservableRangeCollection<Gig> GigList { get; set; } = new ObservableRangeCollection<Gig>();
        public List<Gig> CartItems;
        public readonly IGigService _Service;
        public Command GetData { get; set; }

        public string cartCount;

        public string CartCount
        {
            get { return cartCount; }
            set { SetProperty(ref cartCount, value); }
        }

        public MainPageViewModel()
        {
            GigList = new ObservableRangeCollection<Gig>();
            GetData = new Command(async () => await GetDataCommand());
            _Service = DependencyService.Get<IGigService>();
            setList();
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

        private async Task GetDataCommand()
        {
            if (IsBusy == true)
            {
                return;
            }
            try
            {
                IsBusy = true;
                List<Gig> Gigs = await _Service.GetGigs();

                CartCount = CartCounter.CartCount().ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception is : " + e);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void setList()
        {
            List<Gig> Gigs = await _Service.GetGigs();
            GigList.ReplaceRange(Gigs);
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
                txtCtrl.TextColor = Xamarin.Forms.Color.FromHex(hexColor);
        }
    }

    public class GigType
    {
        public string TypeName { get; set; }
    }
}
