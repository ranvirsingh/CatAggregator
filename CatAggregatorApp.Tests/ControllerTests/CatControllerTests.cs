using CatAggregatorApp.Controllers;
using CatAggregatorApp.Model;
using CatAggregatorApp.Service;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatAggregatorApp.Tests
{
    [TestClass]
    public class CatControllerTests
    {
        [TestMethod]
        public void ShouldProduceValidContentResultWhenServiceAvailableAsync()
        {
            var petApiServiceMock = new Mock<IPetApiService>();
            petApiServiceMock.Setup(s => s.LoadPetOwners()).Returns(
                Task.FromResult<List<PetOwner>>(new List<PetOwner> {
                new PetOwner {
                    Gender = "female",
                    Pets = new List<Pet> {
                        new Pet { Name = "Rock", Type = "Dog" },
                        new Pet { Name = "Ket", Type = "Cat" }}
                }
            }));

            var logCatControllerMock = new Mock<ILogger<CatController>>();

            var catController = new CatController(petApiServiceMock.Object, logCatControllerMock.Object);
            var content = catController.GetCatNamesByOwnerGender();

            var expected = "<html><body><h5>female</h5><ul><li>Ket</li></ul></body></html>";
            Assert.AreEqual(expected, content.Result.Content.ToString());

        }

        [TestMethod]
        public void ShouldThrowExceptionWhenServiceUnAvailable()
        {
            // it will be taken care by global exception handling
            var petApiServiceMock = new Mock<IPetApiService>();
            petApiServiceMock.Setup(s => s.LoadPetOwners()).Returns(
                Task.FromResult<List<PetOwner>>(null));

            var logCatControllerMock = new Mock<ILogger<CatController>>();

            var catController = new CatController(petApiServiceMock.Object, logCatControllerMock.Object);

            var content = catController.GetCatNamesByOwnerGender();

            Assert.AreEqual("Faulted", content.Status.ToString()); 
        }
    }
}
