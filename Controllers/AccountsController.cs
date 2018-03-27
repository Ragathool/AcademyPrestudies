using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyPrestudies.Models;
using AcademyPrestudies.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AcademyPrestudies.Controllers
{
    public class AccountsController : Controller
    {

        MuninRepository repository;

        public AccountsController(MuninRepository repository)
        {
            this.repository = repository;
        }

        [Route ("")]
        [HttpPost]
        public IActionResult LogIn(LogInVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (repository.LogInUser(model))
            {
                return RedirectToAction("Page1", "Home");
            }
            else 
            {
                ModelState.AddModelError("Name", "Wrong username or password");
                return View();
            }

        }

        [Route("")]
        [HttpGet]
        public IActionResult LogIn()
        {
                return View();

        }

        [HttpGet]
        public IActionResult CreateNewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewUser(CreateNewUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (repository.CheckExistingUser(model))
            {
                ModelState.AddModelError("Name", "Name already exists");
                return View(model);
            }
            else
	        {
                repository.AddUser(model);

                return RedirectToAction("Page1", "Home");
            }

        }

    }
}