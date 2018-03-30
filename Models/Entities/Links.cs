using System;
using System.Collections.Generic;

namespace AcademyPrestudies.Models.Entities
{
    public partial class Links
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string LinkInfo { get; set; }
        public int CourseId { get; set; }

        public Courses Course { get; set; }
    }
}
