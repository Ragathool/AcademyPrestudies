using System;
using System.Collections.Generic;

namespace AcademyPrestudies.Models.Entities
{
    public partial class Courses
    {
        public Courses()
        {
            CourseProgress = new HashSet<CourseProgress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CourseProgress> CourseProgress { get; set; }
    }
}
