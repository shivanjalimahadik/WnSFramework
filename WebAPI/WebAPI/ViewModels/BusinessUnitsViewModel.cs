using Entities;
using Entities.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAPI.ViewModels
{
    public class BusinessUnitsViewModel
    {
        [Display(Name = "Business Unit name")]
        [Required(ErrorMessage = "Business Unit name is required.")]
        public string BusinessUnitName { get; set; }

        [Display(Name = "Description")]
        public string BusinessUnitDescription { get; set; }

        [Display(Name = "Legal Entity")]
        public string LegalEntityName { get; set; }

        public Guid Id { get; set; }

        public IList<BusinessUnit> businessUnitList { get; set; }

        public IList<LegalEntity> LegalEntityList { get; set; }

        public IEnumerable<SelectListItem> LEList { get; set; }

        [Required(ErrorMessage = "Please select Business Unit")]
        public Guid? LEId { get; set; }

        public IList<BUWrapper> BUWrapperList { get; set; }

       
    }
}