//-----------------------------------------------------------------------
// <copyright file="BaseEntity.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Entities
{
    using System;

    /// <summary>
    /// BaseEntity class. It holds required basic properties.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity" /> class.
        /// </summary>
        public BaseEntity()
        {
            this.CreatedOn = DateTime.Now;
            this.UpdatedOn = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets id for entity.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// User Defined field 1
        /// </summary>
        public string UDF1 { get; set; }

        /// <summary>
        /// User Defined field 2
        /// </summary>
        public string UDF2 { get; set; }

        /// <summary>
        /// User Defined field 3
        /// </summary>
        public string UDF3 { get; set; }

        /// <summary>
        /// User Defined field 4
        /// </summary>
        public string UDF4 { get; set; }

        /// <summary>
        /// User Defined field 5
        /// </summary>
        public string UDF5 { get; set; }

        

        /// <summary>
        /// Portal Id
        /// </summary>
        public string PortalID { get; set; }

        /// <summary>
        /// Organization Unit Id
        /// </summary>
        public Guid? OrganizationUnitID { get; set; }

        /// <summary>
        /// Buisness Unit Id
        /// </summary>
        public Guid? BusinessUnitID { get; set; }

        /// <summary>
        /// Application Id
        /// </summary>
        public string AppID { get; set; }

        /// <summary>
        /// Primary IP address
        /// </summary>
        public string PrimaryIPAdd { get; set; }

        /// <summary>
        /// Secondary IP address
        /// </summary>
        public string SecondaryIPAdd { get; set; }

        /// <summary>
        /// Azure region
        /// </summary>
        public string AzureRegion { get; set; }

        /// <summary>
        /// Gets or sets entity created on datetime.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets entity modified on datetime.
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets user name who created entity.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets user name who modified entity.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether entity is deleted.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Legal Entity Id
        /// </summary>
        public Guid? LegalEntityID { get; set; }

    }
}
