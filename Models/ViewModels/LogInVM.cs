using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPrestudies.Models.ViewModels
{
    public class LogInVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Användarnamn måste fyllas i")]
        public string Name { get; set; }

        public string ReturnUrl { get; set; }

        [Required(ErrorMessage = "Lösenord måste fyllas i")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
