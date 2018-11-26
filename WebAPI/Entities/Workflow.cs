namespace Entities
{
    using System;
    public class Workflow : BaseEntity
    {
        public Guid EntityID { get; set; }

        public string WorkflowNumber { get; set; }

        public string WorkflowDescription { get; set; }
    }
}
