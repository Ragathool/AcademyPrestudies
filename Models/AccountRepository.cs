using AcademyPrestudies.Models.Entities;
using AcademyPrestudies.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPrestudies.Models
{
    public class AccountRepository
    {
        MuninContext context;
        IdentityDbContext identityContext;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;

        public AccountRepository(
            IdentityDbContext identityContext,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            MuninContext context
            )
        {
            this.identityContext = identityContext;
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
