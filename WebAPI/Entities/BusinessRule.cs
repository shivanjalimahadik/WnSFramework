namespace Entities
{
    public class BusinessRule : BaseEntity
    {
        public string TableName { get; set; }

        public string SelectedField { get; set; }

        public string Operator { get; set; }

        public string Value { get; set; }

        public bool IsEscalation { get; set; }

        public System.DateTime ActionDateFrom { get; set; }

        public System.DateTime ActionDateTo { get; set; }

        public bool IsApproved { get; set; }

        public string EscalateTo { get; set; }

        public string EscalateOperator { get; set; }

        public string EscalateValue { get; set; }

        public string ActionPoint { get; set; }

        public string ForwardTo { get; set; }
    }
}
