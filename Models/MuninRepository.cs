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

            if (context.Users.Any(eu => eu.Name != model.Name))
            {
                context.Users.Add(u);
                context.SaveChanges();
                return u.Id;
            }
            return u.Id;
        }

        
    }
}
