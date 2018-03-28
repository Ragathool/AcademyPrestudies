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

        public IActionResult CourseFrontPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AssignmentPage()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AssignmentPage(AssignmentPageVM model)
        {
            assignmentrepository.AssignmentCompleted();

            return View(model);
        }

        
    }
}
