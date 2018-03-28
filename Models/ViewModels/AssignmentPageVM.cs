using AcademyPrestudies.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPrestudies.Models.ViewModels
{
    public class AssignmentPageVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CourseId { get; set; }
        public int? UserId { get; set; }
        public bool FinishedId { get; set; }
    }
}
