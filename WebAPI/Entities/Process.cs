namespace Entities
{
    using System;

    public class Process : BaseEntity
    {
        public string ProcessName { get; set; }

        public Guid ResourcesID { get; set; }
    }
}
