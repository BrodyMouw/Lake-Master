using System.Collections.Generic;
using LakeLife.Models;
using LakeLife.Data;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using LakeLife.Services.ServiceInterface;

[assembly: Xamarin.Forms.Dependency(typeof(LakeLife.Services.ServiceImplementation.GigService))]

namespace LakeLife.Services.ServiceImplementation
{
    public class GigService : IGigService
    {
        private List<Gig> Gigs;

        public GigService()
        {
            Gigs = new List<Gig>();
        }

        public async Task<List<Gig>> GetGigs()
        {
            Gigs.Clear();

            Gigs.Add(new Gig
            { 
                Image = "boatFeet.jpg",
                GigName = "Tarp and Clean Package",
                Index = 1, Price = "$60",
                Description = GigDescriptions.tarpNClean 
            });

            Gigs.Add(new Gig
            {
                Image = "halfDetail.jpg",
                GigName = "Half Detail Package",
                Index = 2,
                Price = "$300",
                Description = GigDescriptions.filler
            });

            Gigs.Add(new Gig
            {
                Image = "fullDetail.jpg",
                GigName = "Full Detail Package",
                Index = 3,
                Price = "$900",
                Description = GigDescriptions.filler
            });

            return await Task.FromResult(Gigs);
        }
    }
}
