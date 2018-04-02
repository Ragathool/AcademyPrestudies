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


        public AssignmentPageVM AssignmentCompleted(AssignmentPageVM model)
        {


            var a = context.CourseProgress.FirstOrDefault
                    (x => x.CourseId == model.CourseId && x.UserId == model.UserId);

            if (a.FinishedId == true)
            {
                a.FinishedId = false;
            }
            else
            {
                a.FinishedId = true;
            }

            context.CourseProgress.Update(a);
            context.SaveChanges();

            AssignmentPageVM b = new AssignmentPageVM();

            b = model;
            b.FinishedId = a.FinishedId;

            return b;

        }

        internal List<Courses> GetAllAssignments()
        {
            var a = context.Courses.Select
                    (c => new Courses
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description
                    })
                    .OrderBy(c => c.Name)
                    .ToList();

            return a;
        }

        internal Courses GetAssignmentById(int id)
        {
            var a = context.Courses.FirstOrDefault
                    (x => x.Id == id);
            return a;
        }

        internal int GetFinishedCourses(int userId)
        {
            var a = context.CourseProgress.Where
                    (x => x.FinishedId == true && x.UserId == userId).ToList();

            return a.Count;
        }

        internal int GetUserIdByAspNetId(string id)
        {
            var a = context.Users.FirstOrDefault
                    (x => x.AspNetUserId == id);
            var usersId = a.Id;
            return usersId;
        }

        internal string GetUserNameByAspNetId(string id)
        {
            var a = context.Users.FirstOrDefault
                    (x => x.AspNetUserId == id);
            var usersId = a.FirstName + " " + a.LastName;
            return usersId;
        }

        public bool GetCourseFinishedId(int userId, int courseId)
        {
            var a = context.CourseProgress.FirstOrDefault
                    (x => x.CourseId == courseId && x.UserId == userId);

            return a.FinishedId;
        }

        internal List<string> GetSolutions(int id)
        {
            var exercises = context.Exercise.Where
                    (x => x.Id == id).ToList();

            var b = new List<string>();
            for (int i = 0; i < exercises.Count; i++)
            {
                b.Add(exercises[i].Solution);
            }
            return b;
        }

        internal List<string> GetLinkInfos(int id)
        {
            var linkinfo = context.Links.Where
                    (x => x.CourseId == id).ToList();

            var b = new List<string>();
            for (int i = 0; i < linkinfo.Count; i++)
            {
                b.Add(linkinfo[i].LinkInfo);
            }
            return b;
        }

        internal List<string> GetUrls(int id)
        {
            var urls = context.Links.Where
                    (x => x.Id == id).ToList();

            var b = new List<string>();
            for (int i = 0; i < urls.Count; i++)
            {
                b.Add(urls[i].Url);
            }
            return b;
        }

        internal List<string> GetTipInfos(int id)
        {
            var tipinfos = context.Tips.Where
                    (x => x.Id == id).ToList();

            var b = new List<string>();
            for (int i = 0; i < tipinfos.Count; i++)
            {
                b.Add(tipinfos[i].TipInfo);
            }
            return b;
        }

        internal List<string> GetInstructions(int id)
        {
            var exercises = context.Exercise.Where
                    (x => x.Id == id).ToList();

            var b = new List<string>();
            for (int i = 0; i < exercises.Count; i++)
            {
                b.Add(exercises[i].Instruction);
            }
            return b;
        }
    }
}
