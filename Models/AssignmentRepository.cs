using AcademyPrestudies.Models.Entities;
using AcademyPrestudies.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPrestudies.Models
{
    public class AssignmentRepository
    {
        private readonly AssignmentContext context;

        public AssignmentRepository(AssignmentContext context)
        {
            this.context = context;
        }


        public void AssignmentCompleted()
        {
            
            CourseProgress CourseProgress = new CourseProgress{ FinishedId = true };
            context.SaveChanges();
        }

    }
}
