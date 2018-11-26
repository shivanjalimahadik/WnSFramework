namespace Entities
{
    using System;

    public class Resources : BaseEntity
    {
        public string ResourceName { get; set; }

        public Guid ResourceCenterID { get; set; }
    }
}
