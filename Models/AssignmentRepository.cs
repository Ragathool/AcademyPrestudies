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
            // WHERE context. CourseId && UserID == CourseId && UserID
            // CourseProgress FinishedId = true, 
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

        internal int GetUserIdByAspNetId(string id)
        {
            var a = context.Users.FirstOrDefault
                    (x => x.AspNetUserId == id);
            var usersId = a.Id;
            return usersId;
        }
    }
}
