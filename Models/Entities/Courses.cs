using System;
using System.Collections.Generic;

namespace AcademyPrestudies.Models.Entities
{
    public partial class Courses
    {
        public Courses()
        {
            Links = new HashSet<Links>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Links> Links { get; set; }
    }
}
