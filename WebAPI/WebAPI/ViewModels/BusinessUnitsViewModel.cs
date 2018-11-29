using Entities;
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

        public Guid Id { get; set; }

        public string BusinessUnitDescription { get; set; }

        public IList<BusinessUnit> businessUnitList { get; set; }

        public IEnumerable<SelectListItem> LEList { get; set; }

    }
}