﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        private readonly SignInManager<IdentityUser> _SignInManager;
        private SignInManager<IdentityUser> _signInManager;
         

        AssignmentRepository assignmentrepository;
        AccountRepository accountrepository;

        public AssignmentsController(AssignmentRepository assignmentrepository, IMemoryCache cache, AccountRepository accountrepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> _signInManager)
        {
            this.assignmentrepository = assignmentrepository;
            this.accountrepository = accountrepository;
            this.cache = cache;
            _userManager = userManager;
            _SignInManager = _signInManager;
        }


        [HttpGet]
        [Authorize]
        public IActionResult CourseFrontPage(CourseFrontPageVM model)
        {

            List<Courses> courses = assignmentrepository.GetAllAssignments();
            model.Courses = courses;

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var aspNetUserId = _userManager.GetUserId(User);
            var userId = assignmentrepository.GetUserIdByAspNetId(aspNetUserId);
            var username = assignmentrepository.GetUserNameByAspNetId(aspNetUserId);
            var finishedcourses = assignmentrepository.GetFinishedCourses(userId);
            var progressbar = (double)finishedcourses / (double)courses.Count;
            var progressbarpercent = progressbar * 100;

            model.UserId = userId;
            model.UserName = username;

            model.ProgressbarValue = progressbarpercent; 

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AssignmentPage(int id, CourseFrontPageVM cfpmodel)
        {
            List<Courses> courses = assignmentrepository.GetAllAssignments();
            cfpmodel.Courses = courses;

            var courseModel = assignmentrepository.GetAssignmentById(id);
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var aspNetUserId = _userManager.GetUserId(User);
            var userId = assignmentrepository.GetUserIdByAspNetId(aspNetUserId);
            var username = assignmentrepository.GetUserNameByAspNetId(aspNetUserId);
            var finishedId = assignmentrepository.GetCourseFinishedId(userId, courseModel.Id);
            var instructions = assignmentrepository.GetInstructions(courseModel.Id);
            var solutions = assignmentrepository.GetSolutions(courseModel.Id);
            var tipinfo = assignmentrepository.GetTipInfos(courseModel.Id);
            var urls = assignmentrepository.GetUrls(courseModel.Id);
            var linkinfos = assignmentrepository.GetLinkInfos(courseModel.Id);
            var finishedcourses = assignmentrepository.GetFinishedCourses(userId);
            var progressbar = (double)finishedcourses / (double)courses.Count;
            var progressbarpercent = progressbar * 100;

            AssignmentPageVM model = new AssignmentPageVM
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
        public IActionResult AssignmentPage(AssignmentPageVM model)
        {
            var statusChangedModel = assignmentrepository.AssignmentCompleted(model);
            return View(statusChangedModel);
        }

        


    }
}
