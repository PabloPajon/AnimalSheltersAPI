using System;
using System.Collections.Generic;

namespace AnimalSheltersAPI.Models
{
    public partial class Shelter
    {
        public Shelter()
        {
            Animals = new HashSet<Animal>();
        }

        public string? Name { get; set; }
        public string? Owner { get; set; }
        public int ShelterId { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
