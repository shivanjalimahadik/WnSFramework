using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Wrappers
{
    public class OUWrapper
    {
        public string OrganizationUnitName { get; set; }

        public string OrganizationUnitDescription { get; set; }

        public string BusinessUnitName { get; set; }

        public string SrNum { get; set; }

        public Guid Id { get; set; }
    }
}
