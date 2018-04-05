using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPrestudies.Models.ViewModels
{
    public class CreateNewUserVM
    {
        [Required(ErrorMessage = "Du måste fylla i ett användarnamn")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Du måste fylla i ett lösenord")]
        [DataType(DataType.Password, ErrorMessage = "Wrong format on password")]
        [StringLength(100, ErrorMessage = "Lösenordet måste bestå av minst sex tecken", MinimumLength = 6)]
        [RegularExpression("(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*+\\/|!\"£$%^&*()#[\\]@~'?><,.=-_]).{6,}", ErrorMessage = "Lösenordet måste vara 6-20 tecken och innehålla en versal, en gemen, en siffra och ett specialtecken.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Du måste fylla i ditt förnamn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Du måste fylla i ditt efternamn")]
        public string LastName { get; set; }
    }
}
