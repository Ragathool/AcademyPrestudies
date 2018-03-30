using System;
using System.Collections.Generic;

namespace AcademyPrestudies.Models.Entities
{
    public partial class Exercise
    {
        public Exercise()
        {
            Tips = new HashSet<Tips>();
        }

        public int Id { get; set; }
        public string Instruction { get; set; }
        public string Solution { get; set; }

        public ICollection<Tips> Tips { get; set; }
    }
}
