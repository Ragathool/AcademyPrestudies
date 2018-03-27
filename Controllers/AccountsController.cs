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
    public class AccountsController : Controller
    {

        MuninRepository repository;
        AccountRepository accountrepository;

        public AccountsController(MuninRepository repository, IMemoryCache cache, AccountRepository accountrepository)
        {
            this.repository = repository;
            this.accountrepository = accountrepository;
            this.cache = cache;

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
                return RedirectToAction(nameof(HomeController.CourseFrontPage), "Home");
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
                return RedirectToAction(nameof(HomeController.CourseFrontPage), "Home");
            }

            
        }


    }

   }
