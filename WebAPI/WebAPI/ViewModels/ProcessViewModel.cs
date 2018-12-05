using Entities;
using Entities.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAPI.ViewModels
{
    public class ProcessViewModel
    {
        [Display(Name = "Process")]
        [Required(ErrorMessage = "Process name is required")]
        public string ProcessName { get; set; }

        [Display(Name = "Resources")]
        public string ResourceName { get; set; }

        public Guid Id { get; set; }

        public IList<Process> ProcessList { get; set; }

        public IList<Resources> ResourceList { get; set; }

        public IEnumerable<SelectListItem> RList { get; set; }

        [Required(ErrorMessage = "Please select Resource")]

        public Guid? RId { get; set; }
        
        public IList<ProcessWrapper> ProcessWrapperList { get; set; }
    }
}