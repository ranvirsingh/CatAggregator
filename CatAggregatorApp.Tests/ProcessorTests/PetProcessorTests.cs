using CatAggregatorApp.DTO;
using CatAggregatorApp.Model;
using CatAggregatorApp.Processor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CatAggregatorApp.Tests
{
    [TestClass]
    public class PetProcessorTests
    {
        [TestCategory("RemoveOwnersWithoutPets")]
        [TestMethod]
        public void ShouldRemoveOwnersWhenNoPetProvided()
        {
            List<PetOwner> expected = new List<PetOwner> {
                new PetOwner {
                    Gender = "female",
                    Pets = new List<Pet> {
                        new Pet { Name = "Rock", Type = "Dog" },
                        new Pet { Name = "Ket", Type = "Cat" }}
                }
            };

            List<PetOwner> actualList = new List<PetOwner> {
                new PetOwner {
                    Gender = "male",
                    Pets = null
                },
                new PetOwner {
                    Gender = "female",
                    Pets = new List<Pet> {
                        new Pet { Name = "Rock", Type = "Dog" },
                        new Pet { Name = "Ket", Type = "Cat" }}
                },
                new PetOwner {
                    Gender = "unspecified",
                    Pets = null
                }
            };

            List<PetOwner> actual = PetProcessor.RemoveOwnersWithoutPets(actualList);

            Assert.AreEqual(expected.Count, actual.Count);
            // TODO: Add object comparison
        }

        [TestCategory("GetOwnersByPetType")]
        [TestMethod]
        public void ShouldFilterOutOnlyCatOwnersWhenMixTypes()
        {
            List<PetOwner> expected = new List<PetOwner> {
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

            List<PetOwner> actual = PetProcessor.GetOwnersByPetType(actualList, "Cat");

            Assert.AreNotEqual(expected.Count, actualList.Count);
            Assert.AreEqual(expected.Count, actual.Count);
            // TODO: Add object comparison
        }
        [TestMethod]
        public void ShouldFilterOutOnlyCatOwnersWhenNoCatTypes()
        {
            List<PetOwner> expected = new List<PetOwner>();

            List<PetOwner> actualList = new List<PetOwner> {
                new PetOwner {
                    Gender = "male",
                    Pets = new List<Pet> { new Pet { Name = "Jacky", Type = "Dog" } }
                },
                new PetOwner {
                    Gender = "female",
                    Pets = new List<Pet> {
                        new Pet { Name = "Rock", Type = "Dog" }}
                },
                new PetOwner {
                    Gender = "unspecified",
                    Pets = new List<Pet> {
                        new Pet { Name = "Stone", Type = "Horse" }}
                }
            };

            List<PetOwner> actual = PetProcessor.GetOwnersByPetType(actualList, "Cat");

            Assert.AreNotEqual(expected.Count, actualList.Count);
            Assert.AreEqual(expected.Count, actual.Count);
            // TODO: Add object comparison
        }
        [TestMethod]
        public void ShouldFilterOutOnlyCatOwnersWhenNoneType()
        {
            List<PetOwner> expected = new List<PetOwner>();

            List<PetOwner> actualList = new List<PetOwner> {
                new PetOwner {
                    Gender = "male",
                    Pets = new List<Pet>()
                },
                new PetOwner {
                    Gender = "female",
                    Pets = new List<Pet>()
                },
                new PetOwner {
                    Gender = "unspecified",
                    Pets = new List<Pet>()
                }
            };

            List<PetOwner> actual = PetProcessor.GetOwnersByPetType(actualList, "Cat");

            Assert.AreNotEqual(expected.Count, actualList.Count);
            Assert.AreEqual(expected.Count, actual.Count);
            // TODO: Add object comparison
        }

    }
}
