using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Wrappers
{
    public class UsersWrapper
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        public string OrganizationUnitName { get; set; }

        public string BusinessUnitName { get; set; }
    }
}
