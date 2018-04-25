using System;
using System.Collections.Generic;

namespace AcademyPrestudies.Models.Entities
{
    public partial class Courses
    {
        public Courses()
        {
            Exercise = new HashSet<Exercise>();
            Links = new HashSet<Links>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ClassId { get; set; }

        public Classes Class { get; set; }
        public ICollection<Exercise> Exercise { get; set; }
        public ICollection<Links> Links { get; set; }
    }
}
