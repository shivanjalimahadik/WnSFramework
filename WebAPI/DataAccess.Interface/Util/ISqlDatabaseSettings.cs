//-----------------------------------------------------------------------
// <copyright file="ISqlDatabaseSettings.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Interface
{
    /// <summary>
    /// Interface for SQL database settings. Holds abstract properties like connection string and schema name.
    /// </summary>
    public interface ISqlDatabaseSettings
    {
        /// <summary>
        /// Gets or sets connection string property.
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets Schema name.
        /// </summary>
        string SchemaName { get; set; }
    }
}
