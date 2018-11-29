using System;

namespace Entities.Wrappers
{
    public class ResourceCenterWrapper
    {
        public string ResourceCenterName { get; set; }

        public string ResourceCenterDescription { get; set; }

        public string CostCenterName { get; set; }

        public Guid Id { get; set; }
    }
}
