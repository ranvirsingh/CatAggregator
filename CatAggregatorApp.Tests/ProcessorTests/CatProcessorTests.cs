using CatAggregatorApp.DTO;
using CatAggregatorApp.Model;
using CatAggregatorApp.Processor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CatAggregatorApp.Tests
{
    [TestClass]
    public class CatProcessorTests
    {
        [TestCategory("SortCatNames")]
        [TestMethod]
        public void ShouldSortCatNamesInTheObject()
        {
            CatNamesByOwnerGender expected = new CatNamesByOwnerGender();
            expected.Add("fruits", new List<string> { "apple", "banana", "kiwi" });

            CatNamesByOwnerGender viewModel = new CatNamesByOwnerGender();
            viewModel.Add("fruits", new List<string> { "banana", "kiwi", "apple" });

            CatNamesByOwnerGender actual = CatProcessor.SortCatNames(viewModel);

            CollectionAssert.AreEqual(expected["fruits"], actual["fruits"]);
        }

        [TestCategory("LoadCatNamesWithOwnerGender")]
        [TestMethod]
        public void ShouldReturnCatNamesOnlyWhenMixTypeProvided()
        {
            List<PetOwner> actualList = new List<PetOwner> {
                new PetOwner {
                    Gender = "male",
                    Pets = new List<Pet> { new Pet { Name = "Jacky", Type = "Dog" } }
                },
                new PetOwner {
                    Gender = "female",
                    Pets = new List<Pet> {
                        new Pet { Name = "Rock", Type = "Dog" },
                        new Pet { Name = "Ket", Type = "Cat" }}
                },
                new PetOwner {
                    Gender = "unspecified",
                    Pets = new List<Pet> {
                        new Pet { Name = "Raty", Type = "Cat" },
                        new Pet { Name = "Stone", Type = "Horse" }}
                }
            };

            CatNamesByOwnerGender expected = new CatNamesByOwnerGender();
            expected.Add("female", new List<string> { "Ket" });
            expected.Add("unspecified", new List<string> { "Raty" });

            CatNamesByOwnerGender actual = CatProcessor.LoadCatNamesByOwnerGender(actualList);

            Assert.AreEqual(expected["female"].Count, actual["female"].Count);
            Assert.AreEqual(expected["unspecified"].Count, actual["unspecified"].Count);
            // TODO: Add object comparison
        }
    }
}
