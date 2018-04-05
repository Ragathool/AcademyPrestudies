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
            this.roleManager = roleManager;
            this.context = context;

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

            var u = context.Users.Add(new Users
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                AspNetUserId = newUserId

            });
            await context.SaveChangesAsync();

            var userid = GetUserIdByAspNetId(newUserId);
            var assignmentcount = GetAssignmentCount();

            for (int i = 1; i <= assignmentcount; i++)
            {
                context.CourseProgress.Add(new CourseProgress
                {
                    UserId = userid,
                    CourseId = i,
                    FinishedId = false

                });
                await context.SaveChangesAsync();
            }
            
            return result;
        }

        internal void TryLogOut()
        {
            signInManager.SignOutAsync();
        }

        private int GetAssignmentCount()
        {
            var a = context.Courses.ToList();

            return a.Count;
        }
        
        internal int GetUserIdByAspNetId(string id)
        {
            var a = context.Users.FirstOrDefault
                    (x => x.AspNetUserId == id);
            var usersId = a.Id;
            return usersId;
        }
    }
}
