using System;
using System.Collections.Generic;

namespace AcademyPrestudies.Models.Entities
{
    public partial class Classes
    {
        public Classes()
        {
            Courses = new HashSet<Courses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Courses> Courses { get; set; }
    }
}
