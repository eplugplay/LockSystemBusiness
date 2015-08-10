using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Mvc;
using System.Security;
using System.ComponentModel.DataAnnotations;

namespace LockSystemBusiness.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Username:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
}