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

        internal CourseFrontPageVM[] GetAllAssignments()
        {
            var a = context.Courses.Select 
                    (c => new CourseFrontPageVM
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description
                    })
                    .OrderBy(c => c.Name)
                    .ToArray();

            return a;
        }

        internal Courses GetAssignmentById(int id)
        {
            var a = context.Courses.FirstOrDefault
                    (x => x.Id == id);
            return a;
        }
    }
}
