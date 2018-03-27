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
            else
            {
                repository.AddUser(model);


                return RedirectToAction("Page1", "Home");
            }
        }

    }
}