using CatAggregatorApp.Configuration;
using CatAggregatorApp.Helper;
using CatAggregatorApp.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatAggregatorApp.Service
{
    public class PetApiService : IPetApiService
    {
        private IOptions<ApplicationConfig> _settings;
        public PetApiService(IOptions<ApplicationConfig> settings)
        {
            _settings = settings;
            ServiceHelper.Initialize();
        }

        public async Task<List<PetOwner>> LoadPetOwners()
        {
            List<PetOwner> owners = null;
            try
            {
                using (HttpResponseMessage responseMessage = await ServiceHelper.RESTClient.GetAsync(_settings.Value.RemoteServiceUrl))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        owners = await responseMessage.Content.ReadAsAsync<List<PetOwner>>();
                    }
                }
            }
            catch (Exception ex)
            {
                // send for logging
            }
            return owners;
        }
    }
}
