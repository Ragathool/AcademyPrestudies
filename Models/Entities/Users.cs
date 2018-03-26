using System;
using System.Collections.Generic;

namespace AcademyPrestudies.Models.Entities
{
    public partial class Users
    {
        public Users()
        {
            CourseProgress = new HashSet<CourseProgress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public ICollection<CourseProgress> CourseProgress { get; set; }
    }
}
