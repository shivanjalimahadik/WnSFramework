using Entities;
using Entities.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAPI.ViewModels
{
    public class OrganizationUnitViewModel
    {
        [Display(Name = "Organization Unit")]
        [Required(ErrorMessage = "Organization unit name is required")]
        public string OrganizationUnitName { get; set; }

        [Display(Name = "Description")]
        public string OrganizationUnitDescription { get; set; }

        [Display(Name = "Business Unit")]
        public string BusinessUnitName { get; set; }

        public Guid Id { get; set; }

        public IList<OrganizationUnit> OrganizationUnitList { get; set; }

        public IList<BusinessUnit> BusinessUnitList { get; set; }

        public IEnumerable<SelectListItem> BUList { get; set; }

        [Required(ErrorMessage = "Please select Business Unit")]
        public Guid? BUId { get; set; }

        public IList<OUWrapper> OUWrapperList { get; set; }
    }
}