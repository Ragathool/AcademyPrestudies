
using AcademyPrestudies.Models;
using AcademyPrestudies.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AcademyPrestudies.Controllers
{
    public class AdminController : Controller
    {
        IMemoryCache cache;

        private UserManager<IdentityUser> _userManager;

        AssignmentRepository assignmentrepository;
        AccountRepository accountrepository;

        public AdminController(AssignmentRepository assignmentrepository, IMemoryCache cache, AccountRepository accountrepository, UserManager<IdentityUser> userManager)
        {
            this.assignmentrepository = assignmentrepository;
            this.accountrepository = accountrepository;
            this.cache = cache;
            _userManager = userManager;
        }


        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index(AdminIndexVM model)
        {
            var courses = assignmentrepository.GetAllAssignments();
            var users = assignmentrepository.GetAllUsers();
            model.Users = users;
            model.Courses = courses;
            return View(model);
        }
    }
}