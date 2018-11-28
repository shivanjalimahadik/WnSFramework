using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class CostCentersViewModel
    {
        [Display(Name = "Cost Center name")]
        [Required(ErrorMessage = "Cost Center name is required.")]
        public string CostCenterName { get; set; }

        public Guid Id { get; set; }

        public IList<CostCenter> costList { get; set; }

        public Guid? OrganizationUnitID { get; set; }
    }
}