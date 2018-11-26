namespace Entities
{
    using System;
    public class WorkflowSteps : BaseEntity
    {
        public string StepNumber { get; set; }

        public Guid UserID { get; set; }

        public Guid RoleID { get; set; }

        public Guid WorkflowBusinessRuleID { get; set; }
    }
}
