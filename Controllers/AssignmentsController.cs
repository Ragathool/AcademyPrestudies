
using System.Collections.Generic;
using System.Security.Claims;
using AcademyPrestudies.Models;
using AcademyPrestudies.Models.Entities;
using AcademyPrestudies.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;


namespace AcademyPrestudies.Controllers
{
    public class AssignmentsController : Controller
    {
        IMemoryCache cache;

        private UserManager<IdentityUser> _userManager;

        AssignmentRepository assignmentrepository;
        AccountRepository accountrepository;

        public AssignmentsController(AssignmentRepository assignmentrepository, IMemoryCache cache, AccountRepository accountrepository, UserManager<IdentityUser> userManager)
        {
            this.assignmentrepository = assignmentrepository;
            this.accountrepository = accountrepository;
            this.cache = cache;
            _userManager = userManager;
        }


        [HttpGet]
        [Authorize]
        public IActionResult CourseFrontPage(CourseFrontPageVM model)
        {

            List<Courses> courses = assignmentrepository.GetAllAssignments();
            model.Courses = courses;
            

           ClaimsPrincipal currentUser = User;
            var aspNetUserId = _userManager.GetUserId(User);
            var userId = assignmentrepository.GetUserIdByAspNetId(aspNetUserId);
            var username = assignmentrepository.GetUserNameByAspNetId(aspNetUserId);
            var finishedcourses = assignmentrepository.GetFinishedCourses(userId);
            var progressbar = (double)finishedcourses / (double)courses.Count;
            var progressbarpercent = progressbar * 100;

            List<UserProgress> userProgress = assignmentrepository.GetFinishedCoursesProgress(userId);

            model.UserProgress = userProgress;

            model.UserId = userId;
            model.UserName = username;

            model.ProgressbarValue = progressbarpercent;
            

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AssignmentPageV1(int id, CourseFrontPageVM cfpmodel)
        {
            List<Courses> courses = assignmentrepository.GetAllAssignments();
            cfpmodel.Courses = courses;

            var courseModel = assignmentrepository.GetAssignmentById(id);
            ClaimsPrincipal currentUser = User;
            var aspNetUserId = _userManager.GetUserId(User);
            var userId = assignmentrepository.GetUserIdByAspNetId(aspNetUserId);
            var username = assignmentrepository.GetUserNameByAspNetId(aspNetUserId);
            var finishedId = assignmentrepository.GetCourseFinishedId(userId, courseModel.Id);
            var instructions = assignmentrepository.GetInstructions(courseModel.Id);
            var solutions = assignmentrepository.GetSolutions(courseModel.Id);
            var exerciseid = assignmentrepository.GetExerciseId(courseModel.Id);
            var tipsid = assignmentrepository.GetTipsId(exerciseid);
            var tipinfo = assignmentrepository.GetTipInfos(tipsid);
            var urls = assignmentrepository.GetUrls(courseModel.Id);
            var linkinfos = assignmentrepository.GetLinkInfos(courseModel.Id);
            var finishedcourses = assignmentrepository.GetFinishedCourses(userId);
            var progressbar = (double)finishedcourses / (double)courses.Count;
            var progressbarpercent = progressbar * 100;

            AssignmentPageV1VM model = new AssignmentPageV1VM
            {
                Name = courseModel.Name,
                Description = courseModel.Description,
                UserId = userId,
                UserName = username,
                CourseId = courseModel.Id,
                FinishedId = finishedId,
                Instructions = instructions,
                Solutions = solutions,
                TipInfos = tipinfo,
                Urls = urls,
                LinkInfos = linkinfos,
                ProgressbarValue = progressbarpercent
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AssignmentPageV1(AssignmentPageV1VM model)
        {
            var statusChangedModel = assignmentrepository.AssignmentCompleted(model);
            return View(statusChangedModel);
        }


        [HttpGet]
        [Authorize]
        public IActionResult AssignmentPageV2(int id, CourseFrontPageVM cfpmodel)
        {
            List<Courses> courses = assignmentrepository.GetAllAssignments();
            cfpmodel.Courses = courses;

            var courseModel = assignmentrepository.GetAssignmentById(id);
            ClaimsPrincipal currentUser = User;
            var aspNetUserId = _userManager.GetUserId(User);
            var userId = assignmentrepository.GetUserIdByAspNetId(aspNetUserId);
            var username = assignmentrepository.GetUserNameByAspNetId(aspNetUserId);
            var finishedId = assignmentrepository.GetCourseFinishedId(userId, courseModel.Id);
            var instructions = assignmentrepository.GetInstructions(courseModel.Id);
            var solutions = assignmentrepository.GetSolutions(courseModel.Id);
            var exerciseid = assignmentrepository.GetExerciseId(courseModel.Id);
            var tipsid = assignmentrepository.GetTipsId(exerciseid);
            var tipinfo = assignmentrepository.GetTipInfos(tipsid);
            var urls = assignmentrepository.GetUrls(courseModel.Id);
            var linkinfos = assignmentrepository.GetLinkInfos(courseModel.Id);
            var finishedcourses = assignmentrepository.GetFinishedCourses(userId);
            var progressbar = (double)finishedcourses / (double)courses.Count;
            var progressbarpercent = progressbar * 100;

            AssignmentPageV2VM model = new AssignmentPageV2VM
            {
                Name = courseModel.Name,
                Description = courseModel.Description,
                UserId = userId,
                UserName = username,
                CourseId = courseModel.Id,
                FinishedId = finishedId,
                Instructions = instructions,
                Solutions = solutions,
                TipInfos = tipinfo,
                Urls = urls,
                LinkInfos = linkinfos,
                ProgressbarValue = progressbarpercent
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AssignmentPageV2(AssignmentPageV2VM model)
        {
            var statusChangedModel = assignmentrepository.AssignmentCompleted(model);
            return View(statusChangedModel);
        }

        
        [HttpGet]
        [Authorize]
        public IActionResult AssignmentPageV3(int id, CourseFrontPageVM cfpmodel)
        {
            List<Courses> courses = assignmentrepository.GetAllAssignments();
            cfpmodel.Courses = courses;

            var courseModel = assignmentrepository.GetAssignmentById(id);
            ClaimsPrincipal currentUser = User;
            var aspNetUserId = _userManager.GetUserId(User);
            var userId = assignmentrepository.GetUserIdByAspNetId(aspNetUserId);
            var username = assignmentrepository.GetUserNameByAspNetId(aspNetUserId);
            var finishedId = assignmentrepository.GetCourseFinishedId(userId, courseModel.Id);
            var instructions = assignmentrepository.GetInstructions(courseModel.Id);
            var solutions = assignmentrepository.GetSolutions(courseModel.Id);
            var exerciseid = assignmentrepository.GetExerciseId(courseModel.Id);
            var tipsid = assignmentrepository.GetTipsId(exerciseid);
            var tipinfo = assignmentrepository.GetTipInfos(tipsid);
            var urls = assignmentrepository.GetUrls(courseModel.Id);
            var linkinfos = assignmentrepository.GetLinkInfos(courseModel.Id);
            var finishedcourses = assignmentrepository.GetFinishedCourses(userId);
            var progressbar = (double)finishedcourses / (double)courses.Count;
            var progressbarpercent = progressbar * 100;

            AssignmentPageV3VM model = new AssignmentPageV3VM
            {
                Name = courseModel.Name,
                Description = courseModel.Description,
                UserId = userId,
                UserName = username,
                CourseId = courseModel.Id,
                FinishedId = finishedId,
                Instructions = instructions,
                Solutions = solutions,
                TipInfos = tipinfo,
                Urls = urls,
                LinkInfos = linkinfos,
                ProgressbarValue = progressbarpercent
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AssignmentPageV3(AssignmentPageV3VM model)
        {
            var statusChangedModel = assignmentrepository.AssignmentCompleted(model);
            return View(statusChangedModel);
        }
    }
}
