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
        public string UserName { get; set; }
        public bool FinishedId { get; set; }
        public double ProgressbarValue { get; set; }
        public List<string> Instructions { get; set; }
        public List<string> Solutions { get; set; }
        public List<string> Urls { get; set; }
        public List<string> LinkInfos { get; set; }
        public List<string> TipInfos { get; set; }

    
        public Links Links { get; set; }
    }
}
