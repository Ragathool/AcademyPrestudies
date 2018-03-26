using System;
using System.Collections.Generic;

namespace AcademyPrestudies.Models.Entities
{
    public partial class CourseProgress
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? UserId { get; set; }
        public bool FinishedId { get; set; }

        public Courses Course { get; set; }
        public Users User { get; set; }
    }
}
