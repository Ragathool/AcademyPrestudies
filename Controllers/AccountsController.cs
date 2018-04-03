using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyPrestudies.Models;
using AcademyPrestudies.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace AcademyPrestudies.Controllers
{
    public class AccountsController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        AssignmentRepository assignmentrepository;  
        AccountRepository accountrepository;

        public AccountsController(AssignmentRepository assignmentrepository, IMemoryCache cache, AccountRepository accountrepository, UserManager<IdentityUser> userManager)
        {
            this.assignmentrepository = assignmentrepository;
            this.accountrepository = accountrepository;
            this.cache = cache;
            _userManager = userManager;

        }
        IMemoryCache cache;

        [Route("")]
        [HttpGet]
        [Route("login")]
        public IActionResult LogIn()
        {
            //var model = new LogInVM { ReturnUrl = returnUrl };
            return View();

        }

        [HttpPost]
        [Route("logIn")]
        public async Task<IActionResult> Login(LogInVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Check if credentials is valid (and set auth cookie)
            if (!await accountrepository.TryLoginAsync(viewModel))
            {
                // Show login error
                ModelState.AddModelError(nameof(LogInVM.Name), "Invalid credentials");
                return View(viewModel);
            }

            // Redirect user
            if (string.IsNullOrWhiteSpace(viewModel.ReturnUrl))
                return RedirectToAction(nameof(AssignmentsController.CourseFrontPage), "Assignments");

            else
                return Redirect(viewModel.ReturnUrl);
        }


        [HttpGet]
        public IActionResult CreateNewUser()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser(CreateNewUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                await accountrepository.AddUser(model);
                return RedirectToAction(nameof(AccountsController.LogIn), "Accounts");
            }
        }
    }

}
