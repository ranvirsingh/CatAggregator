using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CatAggregatorApp.Constants;
using CatAggregatorApp.DTO;
using CatAggregatorApp.Model;
using CatAggregatorApp.Processor;
using CatAggregatorApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CatAggregatorApp.Controllers
{
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly IPetApiService _petApiService;
        private readonly ILogger<CatController> _logger;

        public CatController(IPetApiService petApiService, ILogger<CatController> logger)
        {
            _petApiService = petApiService;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/Cat/GetCatNamesByOwnerGender")]
        public async Task<ContentResult> GetCatNamesByOwnerGender()
        {
            string content = string.Empty;
            _logger.LogInformation("Fetching data from a remote service.", null);

            List<PetOwner> owners = await _petApiService.LoadPetOwners();
            _logger.LogInformation("Response returned from remote service.", null);

            content = ProcessResults(owners);
            
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
