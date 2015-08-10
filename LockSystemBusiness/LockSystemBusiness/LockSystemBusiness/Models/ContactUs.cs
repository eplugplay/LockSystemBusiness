using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace LockSystemBusiness.Models
{
    public class ContactUs
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string BusinessName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Inquiry { get; set; }
        public string Captcha { get; set; }
    }
}