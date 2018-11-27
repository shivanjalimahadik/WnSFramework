using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class RolesViewModel
    {
        [Display(Name = "Role name")]
        [Required(ErrorMessage = "Role name is required.")]
        public string RoleName { get; set; }

        public Guid Id { get; set; }

        public IList<Roles> rolesList { get; set; }
    }
}