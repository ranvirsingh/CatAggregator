using System.Collections.Generic;
using System.Threading.Tasks;
using CatAggregatorApp.Model;

namespace CatAggregatorApp.Service
{
    public interface IPetApiService
    {
        Task<List<PetOwner>> LoadPetOwners();
    }
}