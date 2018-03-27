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
        IdentityDbContext identityContext;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;

        public AccountRepository(
            IdentityDbContext identityContext,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            this.identityContext = identityContext;
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
            var result = await userManager.CreateAsync(new IdentityUser(model.Name), model.Password);
            return result;
        }
    }
}
