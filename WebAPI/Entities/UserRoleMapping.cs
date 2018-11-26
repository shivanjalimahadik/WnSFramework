namespace Entities
{
    using System;
    public class UserRoleMapping : BaseEntity
    {
        public Guid UserID { get; set; }

        public Guid RoleID { get; set; }
    }
}
