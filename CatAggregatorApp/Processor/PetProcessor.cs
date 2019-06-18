using CatAggregatorApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAggregatorApp.Processor
{
    public static class PetProcessor
    {
        public static List<PetOwner> RemoveOwnersWithoutPets(List<PetOwner> owners)
        {
            return owners.FindAll(owner => owner.Pets != null);
        }

        public static List<PetOwner> GetOwnersByPetType(List<PetOwner> petOwners, string petType)
        {
            return (from petOwner in petOwners
                    where petOwner.Pets.Any(pet => pet.Type.ToLowerInvariant() == petType.ToLowerInvariant())
                    select petOwner).ToList();
        }

    }
}
