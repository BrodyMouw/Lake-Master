using LakeLife.Data;
using LakeLife.Helpers;
using LakeLife.Models;
using LakeLife.Services.ServiceInterface;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LakeLife.ViewModels
{
    public class CartPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Gig> CartList { get; set; } = new ObservableRangeCollection<Gig>();
        public readonly IGigService _Service;
        public MvvmHelpers.Commands.Command GetData { get; set; }

        public List<Gig> GigList => GetGigs();

        public string totalPrice;

        public string TotalPrice
        {
            get { return totalPrice; }
            set { SetProperty(ref totalPrice, value); }
        }

        public CartPageViewModel()
        {
            CartList = new ObservableRangeCollection<Gig>();
            GetData = new MvvmHelpers.Commands.Command(async () => await GetDataCommand());
            _Service = DependencyService.Get<IGigService>();
            setList();
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

                TotalPrice = CalculateTotal.calculateTotal().ToString("C0");
                //TotalPrice = String.Format("{0:N2}", temp);
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

            CartList.Clear();

            foreach(Gig gig in Gigs)
            {
                if(Settings.ItemStatus1 == true)
                {
                    if(gig.Index == 1)
                    {
                        CartList.Add(gig);
                    }
                }

                if (Settings.ItemStatus2 == true)
                {
                    if (gig.Index == 2)
                    {
                        CartList.Add(gig);
                    }
                }

                if (Settings.ItemStatus3 == true)
                {
                    if (gig.Index == 3)
                    {
                        CartList.Add(gig);
                    }
                }
            }
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
    }
}
