using AcademyPrestudies.Models.Entities;
using AcademyPrestudies.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AcademyPrestudies.Models
{
    public class AccountRepository
    {
        MuninContext context;
        IdentityDbContext identityContext;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        RoleManager<IdentityRole> roleManager;

        public AccountRepository(
            IdentityDbContext identityContext,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            MuninContext context
            )
        {
            this.identityContext = identityContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;            this.context = context;
        }



        public async Task<bool> TryLoginAsync(LogInVM viewModel)
        {
            // Create DB schema (first time)
            //var createSchemaResult = await identityContext.Database.EnsureCreatedAsync();

            // Create a hard coded user (first time)
            //var createResult = await userManager.CreateAsync(new IdentityUser("user"), "Password_123");

            var loginResult = await signInManager.PasswordSignInAsync(viewModel.Name, viewModel.Password, false, false);

            

            return loginResult.Succeeded;
        }

        public int GetUserId()
        {
            return 0;
        }

            internal async Task<IdentityResult> AddUser(CreateNewUserVM model)
        {
            var newUser = new IdentityUser(model.UserName);
            var result = await userManager.CreateAsync(newUser, model.Password);
            var newUserId = newUser.Id;
            context.Users.Add(new Users
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                AspNetUserId = newUserId

            });
            await context.SaveChangesAsync();
            

            return result;
        }
    }
}
