using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class LegalEntityViewmodel
    {
        [Display(Name = "Legal Entity")]
        [Required(ErrorMessage = "Legal entity name is required")]
        public string LegalEntityName { get; set; }

        public Guid Id { get; set; }

        public IList<LegalEntity> LegalEntityList { get; set; }
    }
}