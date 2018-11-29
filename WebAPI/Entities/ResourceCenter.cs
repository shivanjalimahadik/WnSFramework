namespace Entities
{
    using System;

    public class ResourceCenter : BaseEntity
    {
        public string ResourceCenterName { get; set; }

        public Guid? CostCenterID { get; set; }
    }
}
