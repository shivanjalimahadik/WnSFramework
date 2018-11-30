using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAPI.ViewModels
{
    public class UsersViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "User name")]
        [Required(ErrorMessage = "User name is requied")]
        public string UserName { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is requied")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is requied")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is requied")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is requied")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Password expiry")]
        [Required(ErrorMessage = "Password expiry date is requied")]
        public System.DateTime PasswordExpiry { get; set; }

        [Display(Name = "Contact no")]
        [Required(ErrorMessage = "contac no is requied")]
        public string ContactNo { get; set; }

        public IEnumerable<SelectListItem> OUList { get; set; }

        [Required(ErrorMessage  = "Organization unit is required")]
        [Display(Name = "Organization unit")]
        public Guid? OUId { get; set; }

        public IEnumerable<SelectListItem> BUList { get; set; }

        [Required(ErrorMessage = "Business unit is requried")]
        [Display(Name = "Business unit")]
        public Guid? BUId { get; set; }

        public IList<Entities.Wrappers.UsersWrapper> UsersList { get; set; }
    }
}