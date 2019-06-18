using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CatAggregatorApp.Constants;
using CatAggregatorApp.DTO;
using CatAggregatorApp.Model;
using CatAggregatorApp.Processor;
using CatAggregatorApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace CatAggregatorApp.Controllers
{
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly IPetApiService _petApiService;
        public CatController(IPetApiService petApiService)
        {
            _petApiService = petApiService;
        }

        [HttpGet]
        [Route("api/Cat/GetCatNamesByOwnerGender")]
        public async Task<ContentResult> GetCatNamesByOwnerGender()
        {
            string content = string.Empty;
            List<PetOwner> owners = await _petApiService.LoadPetOwners();
            content = (owners != null) ?  ProcessResults(owners) :  "Looks like remote service is unavailable. :(";
            
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = content
            };
        }

        private string ProcessResults(List<PetOwner> owners)
        {
            owners = PetProcessor.RemoveOwnersWithoutPets(owners);
            owners = PetProcessor.GetOwnersByPetType(owners, Pets.cat);

            CatNamesByOwnerGender catNamesViewModel = CatProcessor.LoadCatNamesByOwnerGender(owners);
            catNamesViewModel = CatProcessor.SortCatNames(catNamesViewModel);

            return HTMLProcessor.FormatHTML(catNamesViewModel);
        }
    }
}
