//-----------------------------------------------------------------------
// <copyright file="LookupHelper.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Util
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Dapper;
    using DataAccess.Interface;

    /// <summary>
    /// Lookup helper class
    /// </summary>
    public class LookupHelper : ILookupHelper
    {
        /// <summary>
        /// Database settings variable
        /// </summary>
        private readonly ISqlDatabaseSettings sqlDataBaseSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupHelper" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public LookupHelper(ISqlDatabaseSettings sqlDataBaseSettings)
        {
            this.sqlDataBaseSettings = sqlDataBaseSettings;
        }

        /// <summary>
        /// Gets SQL database connection object
        /// </summary>
        internal IDbConnection SqlConnection
        {
            get { return new SqlConnection(this.sqlDataBaseSettings.ConnectionString); }
        }

        /// <summary>
        /// Gets entities
        /// </summary>
        /// <param name="limit">Limit number</param>
        /// <param name="sortProperty">sort property</param>
        /// <param name="sortDescending">Whether to sort descending</param>
        /// <param name="searchProperty">Search property</param>
        /// <param name="searchText">Search text</param>
        /// <param name="tableName">Table name</param>
        /// <param name="columns">Column names</param>
        /// <returns>Filtered entities</returns>
        public dynamic[] GetFilteredEntities(int limit, string sortProperty, bool sortDescending, string searchProperty, string searchText, string tableName, string[] columns)
        {
            var columnSelection = string.Join(" ,", columns);
            var query = string.Format(" SELECT TOP {0} {1} FROM {2} WHERE Active = 1 AND {3} LIKE '{4}%' ", limit, columnSelection, tableName, searchProperty, searchText);

            if (!string.IsNullOrEmpty(sortProperty))
            {
                query += " ORDER BY " + sortProperty;
            }

            if (sortDescending)
            {
                query += " DESC ";
            }

            using (var dbConnection = this.SqlConnection)
            {
                dbConnection.Open();
                return dbConnection.Query(query).ToArray();
            }
        }
    }
}