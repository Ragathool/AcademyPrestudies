using AcademyPrestudies.Models.Entities;
using AcademyPrestudies.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPrestudies.Models
{
    public class MuninRepository
    {
        private readonly MuninContext context;

        public MuninRepository(MuninContext context)
        {
            this.context = context;
        }

        internal int AddUser(CreateNewUserVM model)
        {
            var u = new Users
            {
                Name = model.Name,
                Password = model.Password
            };

                context.Users.Add(u);
                context.SaveChanges();
                return u.Id;
        }

        internal bool CheckExistingUser(CreateNewUserVM model)
        {
            var u = new Users
            {
                Name = model.Name,
                Password = model.Password
            };
            if (context.Users.Any(eu => eu.Name == model.Name))
            {
                return true;
            }
            return false;
        }

        internal bool LogInUser(LogInVM model)
        {
            var LogIn = context.Users.SingleOrDefault(eu => eu.Name == model.Name);
            if (LogIn != null)
            {
                if (LogIn.Password == model.Password)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
            
        }


    }
}
