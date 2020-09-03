using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGO.Models;
using System.ComponentModel.DataAnnotations;


namespace NGO.ViewModel
{
    public class RegisterVolunteerViewModel
    {
        public int Id { get; set; }
       
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        [Range(10, 100)]
        public int Age { get; set; }

        public UserType UserType { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public List<InterestArea> InterestAreas { get; set; }
       
    }

   
}