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


        public AssignmentPageV1VM AssignmentCompleted(AssignmentPageV1VM model)
        {


            var a = context.UserProgress.FirstOrDefault
                    (x => x.CourseId == model.CourseId && x.UserId == model.UserId);

            if (a.CourseFinishedId == true)
            {
                a.CourseFinishedId = false;
            }
            else
            {
                a.CourseFinishedId = true;
            }

            context.UserProgress.Update(a);
            context.SaveChanges();

            AssignmentPageV1VM b = new AssignmentPageV1VM();

            b = model;
            b.FinishedId = a.CourseFinishedId;
            
            var finished = GetFinishedCourses((b.UserId).GetValueOrDefault());
            var courseCount = GetAllAssignments().Count;
            var progressbar = (double)finished / (double)courseCount;
            var progressbarpercent = progressbar * 100;

            b.ProgressbarValue = progressbarpercent;

            return b;

        }

        internal List<Users> GetAllUsers()
        {
            var a = context.Users.Select
                    (u => new Users
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        
                    })
                    .OrderBy(u => u.FirstName)
                    .ToList();

            return a;
        }

        public AssignmentPageV2VM AssignmentCompleted(AssignmentPageV2VM model)
        {


            var a = context.UserProgress.FirstOrDefault
                    (x => x.CourseId == model.CourseId && x.UserId == model.UserId);

            if (a.CourseFinishedId == true)
            {
                a.CourseFinishedId = false;
            }
            else
            {
                a.CourseFinishedId = true;
            }

            context.UserProgress.Update(a);
            context.SaveChanges();

            AssignmentPageV2VM b = new AssignmentPageV2VM();

            b = model;
            b.FinishedId = a.CourseFinishedId;

            var finished = GetFinishedCourses((b.UserId).GetValueOrDefault());
            var courseCount = GetAllAssignments().Count;
            var progressbar = (double)finished / (double)courseCount;
            var progressbarpercent = progressbar * 100;

            b.ProgressbarValue = progressbarpercent;

            return b;

        }
        public AssignmentPageV3VM AssignmentCompleted(AssignmentPageV3VM model)
        {


            var a = context.UserProgress.FirstOrDefault
                    (x => x.CourseId == model.CourseId && x.UserId == model.UserId);

            if (a.CourseFinishedId == true)
            {
                a.CourseFinishedId = false;
            }
            else
            {
                a.CourseFinishedId = true;
            }

            context.UserProgress.Update(a);
            context.SaveChanges();

            AssignmentPageV3VM b = new AssignmentPageV3VM();

            b = model;
            b.FinishedId = a.CourseFinishedId;

            var finished = GetFinishedCourses((b.UserId).GetValueOrDefault());
            var courseCount = GetAllAssignments().Count;
            var progressbar = (double)finished / (double)courseCount;
            var progressbarpercent = progressbar * 100;

            b.ProgressbarValue = progressbarpercent;

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
            var a = context.UserProgress.Where
                    (x => x.CourseFinishedId == true && x.UserId == userId).ToList();

            return a.Count;
        }

        public List<UserProgress> GetFinishedCoursesProgress(int userId)
        {
            var a = context.UserProgress.Where
                    (x => x.CourseFinishedId == true && x.UserId == userId).ToList();

            return a;
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
            var a = context.UserProgress.FirstOrDefault
                    (x => x.CourseId == courseId && x.UserId == userId);

            return a.CourseFinishedId;
        }

        internal List<string> GetSolutions(int id)
        {
            var exercises = context.Exercise.Where
                    (x => x.CourseId == id).ToList();

            var b = new List<string>();
            for (int i = 0; i < exercises.Count; i++)
            {
                b.Add(exercises[i].Solution);
            }
            return b;
        }

        internal List<int> GetTipsId(List<int> exerciseid)
        {
            var b = new List<int>();

            foreach (var id in exerciseid)
            {
                var tips = context.Tips.Where
                                    (x => x.Id == id).ToList();

                
                for (int i = 0; i < tips.Count; i++)
                {
                    b.Add(tips[i].Id);
                }
            }
            
            return b;
        }

        internal List<int> GetExerciseId(int id)
        {
            var exercises = context.Exercise.Where
                    (x => x.CourseId == id).ToList();

            var b = new List<int>();
            for (int i = 0; i < exercises.Count; i++)
            {
                b.Add(exercises[i].Id);
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
                    (x => x.CourseId == id).ToList();

            var b = new List<string>();
            for (int i = 0; i < urls.Count; i++)
            {
                b.Add(urls[i].Url);
            }
            return b;
        }

        internal List<string> GetTipInfos(List<int> tipsid)
        {
            var b = new List<string>();

            foreach (var id in tipsid)
            {
                var tipinfos = context.Tips.Where
                                    (x => x.Id == id).ToList();
                
                for (int i = 0; i < tipinfos.Count; i++)
                {
                    b.Add(tipinfos[i].TipInfo);
                }
            }
            
            return b;
        }

        internal List<string> GetInstructions(int id)
        {
            var exercises = context.Exercise.Where
                    (x => x.CourseId == id).ToList();

            var b = new List<string>();
            for (int i = 0; i < exercises.Count; i++)
            {
                b.Add(exercises[i].Instruction);
            }
            return b;
        }
    }
}
