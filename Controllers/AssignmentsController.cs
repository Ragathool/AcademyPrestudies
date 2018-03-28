using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyPrestudies.Models;
using AcademyPrestudies.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AcademyPrestudies.Controllers
{
    public class AssignmentsController : Controller
    {
        IMemoryCache cache;

        AssignmentRepository assignmentrepository;
        AccountRepository accountrepository;

        public AssignmentsController(AssignmentRepository assignmentrepository, IMemoryCache cache, AccountRepository accountrepository)
        {
            this.assignmentrepository = assignmentrepository;
            this.accountrepository = accountrepository;
            this.cache = cache;
        }

        [HttpGet]
        public IActionResult CourseFrontPage(CourseFrontPageVM model)
        {
            CourseFrontPageVM[] courseArray = assignmentrepository.GetAllAssignments();
            return View(courseArray);
        }

        [HttpGet]
        public IActionResult AssignmentPage(int id)
        {
            var courseModel = assignmentrepository.GetAssignmentById(id);
            
            AssignmentPageVM model = new AssignmentPageVM
            {
                Name = courseModel.Name,
                Description = courseModel.Description,
                UserId = 1,
                CourseId = courseModel.Id,
                FinishedId = true
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AssignmentPage()
        {
            return View();
        }


    }
}
