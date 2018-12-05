using Entities;
using Entities.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAPI.ViewModels
{
    public class ResourceViewModel
    {
        [Display(Name = "Resource name")]
        [Required(ErrorMessage = "Resource name is required.")]
        public string ResourceName { get; set; }

        [Display(Name = "Resource Center")]
        public string ResourceCenterName { get; set; }

        public Guid Id { get; set; }

        public IList<Resources> ResourceList { get; set; }

        public IList<ResourceCenter> ResourceCentersList { get; set; }

        public IEnumerable<SelectListItem> RCList { get; set; }

        [Required(ErrorMessage = "Please select Resource Unit")]
        public Guid? RCId { get; set; }

        public IList<ResourceWrapper> ResourceWrapperList { get; set; }
    }
}