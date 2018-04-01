using AcademyPrestudies.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPrestudies.Models.ViewModels
{
    public class CourseFrontPageVM
    {

        public List<Courses> Courses { get; set; }

        public double ProgressbarValue { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
