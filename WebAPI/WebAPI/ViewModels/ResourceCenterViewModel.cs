using Entities;
using Entities.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAPI.ViewModels
{
    public class ResourceCenterViewModel
    {
        [Display(Name = "Resource Center")]
        [Required(ErrorMessage = "Resource center name is required")]
        public string ResourceCenterName { get; set; }

        [Display(Name = "Cost Center")]
        public string CostCenterName { get; set; }

        public Guid Id { get; set; }

        public IList<ResourceCenter> ResourceCenterList { get; set; }

        public IList<CostCenter> CostCenterList { get; set; }

        public IEnumerable<SelectListItem> CCList { get; set; }

        [Required(ErrorMessage = "Please select Cost Center")]
        public Guid? CCId { get; set; }

        public IList<ResourceCenterWrapper> RCWrapperList { get; set; }
    }
}