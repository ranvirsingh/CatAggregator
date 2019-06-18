using CatAggregatorApp.Controllers;
using CatAggregatorApp.Model;
using CatAggregatorApp.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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

            var catController = new CatController(petApiServiceMock.Object);
            var content = catController.GetCatNamesByOwnerGender();

            var expected = "<html><body><h5>female</h5><ul><li>Ket</li></ul></body></html>";
            Assert.AreEqual(expected, content.Result.Content.ToString());

        }

        [TestMethod]
        public void ShouldProduceValidContentResultWhenServiceUnAvailable()
        {
            var petApiServiceMock = new Mock<IPetApiService>();
            petApiServiceMock.Setup(s => s.LoadPetOwners()).Returns(
                Task.FromResult<List<PetOwner>>(null));

            var catController = new CatController(petApiServiceMock.Object);
            var content = catController.GetCatNamesByOwnerGender();

            var expected = "Looks like remote service is unavailable. :(";
            Assert.AreEqual(expected, content.Result.Content.ToString());
        }
    }
}
