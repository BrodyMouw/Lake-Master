using System.Collections.Generic;
using System.Threading.Tasks;
using LakeLife.Models;

namespace LakeLife.Services.ServiceInterface
{
    public interface IGigService
    {
        Task<List<Gig>> GetGigs();
    }
}