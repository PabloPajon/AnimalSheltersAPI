using System;
using System.Collections.Generic;

namespace AnimalSheltersAPI.Models
{
    public partial class Animal
    {
        public string? Specie { get; set; }
        public string? Race { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Sex { get; set; }
        public string? State { get; set; }
        public int AnimalId { get; set; }
        public int ShelterId { get; set; }

        public virtual Shelter Shelter { get; set; } = null!;
    }
}
