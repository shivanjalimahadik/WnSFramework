//-----------------------------------------------------------------------
// <copyright file="SqlDatabaseSettings.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Util
{
    using DataAccess.Interface;

    /// <summary>
    /// SQL database settings class
    /// </summary>
    public class SqlDatabaseSettings : ISqlDatabaseSettings
    {
        /// <summary>
        /// Gets or sets connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets schema name
        /// </summary>
        public string SchemaName { get; set; }
    }
}
