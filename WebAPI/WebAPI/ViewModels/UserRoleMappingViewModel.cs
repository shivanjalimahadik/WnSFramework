using Entities.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAPI.ViewModels
{
    public class UserRoleMappingViewModel
    {
        public IList<UserRoleWrapper> UserRoleWrapper { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "Please select user")]
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "Please select at least one role")]
        public Guid[] SelectedRoles { get; set; }

        [Display(Name = "Roles")]
        public IEnumerable<SelectListItem> Roles { get; set; }

        [Display(Name = "User")]
        public IEnumerable<SelectListItem> UserList { get; set; }

        public Guid Id { get; set; }
    }
}