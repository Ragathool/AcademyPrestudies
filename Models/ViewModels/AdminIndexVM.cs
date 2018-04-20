using AcademyPrestudies.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPrestudies.Models.ViewModels
{
    public class AdminIndexVM
    {
        public List<Courses> Courses { get; set; }
        public List<Users> Users { get; set; }
    }
}
