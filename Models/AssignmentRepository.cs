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
            
            var a = context.CourseProgress.FirstOrDefault
                    (x => x.CourseId == model.CourseId && x.UserId == model.UserId);

            a.FinishedId = true;

            context.CourseProgress.Update(a);
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
