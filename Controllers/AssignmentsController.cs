using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AcademyPrestudies.Models;
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
        public IActionResult CourseFrontPage(CourseFrontPageVM model)
        {
            CourseFrontPageVM[] courseArray = assignmentrepository.GetAllAssignments();
            return View(courseArray);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AssignmentPage(int id)
        {
            var courseModel = assignmentrepository.GetAssignmentById(id);

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var aspNetUserId = _userManager.GetUserId(User);

            var userId = assignmentrepository.GetUserIdByAspNetId(aspNetUserId);
            

            AssignmentPageVM model = new AssignmentPageVM
            {
                Name = courseModel.Name,
                Description = courseModel.Description,
                UserId = userId,
                CourseId = courseModel.Id,
                FinishedId = false
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AssignmentPage(AssignmentPageVM model)
        {
            assignmentrepository.AssignmentCompleted(model);
            return View(model);
        }


    }
}
