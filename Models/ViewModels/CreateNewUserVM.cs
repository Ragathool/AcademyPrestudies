﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyPrestudies.Models.ViewModels
{
    public class CreateNewUserVM
    {
        [Required(ErrorMessage = "Fel namn")]
        public string Name { get; set; }

        //[NotMapped]
        //[Compare("Name")]
        //public string ConfirmName { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Wrong format on password")]
        public string Password { get; set; }
    }
}
