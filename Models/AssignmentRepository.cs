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
        private readonly MuninContext context;

        public AssignmentRepository(MuninContext context)
        {
            this.context = context;
        }


        public void AssignmentCompleted(AssignmentPageVM model)
        {
            
            CourseProgress CourseProgress = new CourseProgress{FinishedId = true, };
            context.CourseProgress.Update(CourseProgress);
            context.SaveChanges();
        }

    }
}
