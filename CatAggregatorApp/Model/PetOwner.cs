using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAggregatorApp.Model
{
    public class PetOwner
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
