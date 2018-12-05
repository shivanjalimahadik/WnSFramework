using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Wrappers
{
    public class UserRoleWrapper
    {
        public Guid? UserID { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AssignedRoles { get; set; }
    }
}
