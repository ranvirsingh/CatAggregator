using CatAggregatorApp.Constants;
using CatAggregatorApp.DTO;
using CatAggregatorApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatAggregatorApp.Processor
{
    public static class CatProcessor
    {
        public static CatNamesByOwnerGender SortCatNames(CatNamesByOwnerGender catNamesWithOwnerGender)
        {
            foreach (string gender in catNamesWithOwnerGender.Keys)
            {
                catNamesWithOwnerGender[gender].Sort();
            }
            return catNamesWithOwnerGender;
        }

        public static CatNamesByOwnerGender LoadCatNamesByOwnerGender(List<PetOwner> catOwners)
        {
            CatNamesByOwnerGender catNamesWithOwnerGender = new CatNamesByOwnerGender();

            foreach (PetOwner catOwner in catOwners)
            {
                if (catNamesWithOwnerGender.ContainsKey(catOwner.Gender))
                {
                    catNamesWithOwnerGender[catOwner.Gender].AddRange(catOwner.Pets.Where(pet => pet.Type.ToLowerInvariant() == Pets.cat).Select(pet => pet.Name).ToList());
                }
                else
                {
                    catNamesWithOwnerGender.Add(catOwner.Gender, catOwner.Pets.Where(pet => pet.Type.ToLowerInvariant() == Pets.cat).Select(pet => pet.Name).ToList());
                }
            }
            return catNamesWithOwnerGender;
        }
    }
}
