//-----------------------------------------------------------------------
// <copyright file="DapperExtensions.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Util
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;

    /// <summary>
    /// Static class to define all dapper extension methods
    /// </summary>
    public static class DapperExtensions
    {
        /// <summary>
        /// Inserts item of type T in database.
        /// </summary>
        /// <typeparam name="T">Type of the value to be inserted</typeparam>
        /// <param name="cnn">Database connection object of type IDbConnection</param>
        /// <param name="tableName">Table name</param>
        /// <param name="param">Dynamic parameters</param>
        /// <returns>Inserted record of type T</returns>
        public static T Insert<T>(this IDbConnection cnn, string tableName, dynamic param)
        {
            IEnumerable<T> result = SqlMapper.Query<T>(cnn, DynamicQuery.GetInsertQuery(tableName, param), param);
            return result.First();
        }

        /// <summary>
        /// Inserts many records of type T in database
        /// </summary>
        /// <param name="cnn">Database connection object of type IDbConnection</param>
        /// <param name="tableName">Table name</param>
        /// <param name="paramValues">Array of dynamic parameters</param>
        public static void InsertMany(this IDbConnection cnn, string tableName, dynamic[] paramValues)
        {
            var result = SqlMapper.Execute(cnn, DynamicQuery.GetInsertQuery(tableName, paramValues[0]), paramValues);
        }

        /// <summary>
        /// Inserts many records of type T in database asynchronously
        /// </summary>
        /// <param name="cnn">Database connection object </param>
        /// <param name="tableName">Table name</param>
        /// <param name="paramValues">Dynamic parameters</param>
        /// <returns>Asynchronous task</returns>
        public static async Task InsertManyAsync(this IDbConnection cnn, string tableName, dynamic[] paramValues)
        {
            await SqlMapper.ExecuteAsync(cnn, DynamicQuery.GetInsertQuery(tableName, paramValues[0]), paramValues);
        }

        /// <summary>
        /// Executes SQL command
        /// </summary>
        /// <param name="cnn">Database connection object</param>
        /// <param name="commands">SQL command</param>
        /// <param name="paramValues">Parameter values</param>
        /// <returns>Successful execution returns 0</returns>
        public static int ExecuteCommands(this IDbConnection cnn, string commands, object paramValues)
        {
            var cnt = -1;
            using (var transaction = cnn.BeginTransaction())
            {
                cnt = cnn.Execute(commands, paramValues, transaction);
                transaction.Commit();
            }

            return cnt;
        }

        /// <summary>
        /// Update records in database.
        /// </summary>
        /// <param name="cnn">Database connection object of type IDbConnection</param>
        /// <param name="tableName">Table name</param>
        /// <param name="param">Dynamic parameters</param>
        public static void Update(this IDbConnection cnn, string tableName, dynamic param)
        {
            SqlMapper.Execute(cnn, DynamicQuery.GetUpdateQuery(tableName, param), param);
        }

        /// <summary>
        /// Updates many records in database table
        /// </summary>
        /// <param name="cnn">Database connection object of type IDbConnection</param>
        /// <param name="tableName">Table name</param>
        /// <param name="param">Array of dynamic parameters</param>
        public static void UpdateMany(this IDbConnection cnn, string tableName, dynamic[] param)
        {
            SqlMapper.Execute(cnn, DynamicQuery.GetUpdateQuery(tableName, param[0]), param);
        }

        /// <summary>
        /// Updates many records in database table asynchronously
        /// </summary>
        /// <param name="cnn">Database connection object of type IDbConnection</param>
        /// <param name="tableName">Table name</param>
        /// <param name="param">Array of dynamic parameters</param>
        /// <returns>Asynchronous task</returns>
        public static Task UpdateManyAsync(this IDbConnection cnn, string tableName, dynamic[] param)
        {
            return SqlMapper.ExecuteAsync(cnn, DynamicQuery.GetUpdateQuery(tableName, param[0]), param);
        }

        /// <summary>
        /// Gets paging for items of type T
        /// </summary>
        /// <typeparam name="T">Type of the value for which paging is configured</typeparam>
        /// <param name="cnn">Database connection object of type IDbConnection</param>
        /// <param name="tableName">Table name</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortProperty">Sort property</param>
        /// <param name="sortDescending">Whether to sort descending</param>
        /// <param name="searchText">Search text to filter the result</param>
        /// <returns>IEnumerable collection of items of type T.</returns>
        public static IEnumerable<T> GetPaging<T>(this IDbConnection cnn, string tableName, int pageNumber, int pageSize, string sortProperty, bool sortDescending, string searchText)
        {
            IEnumerable<T> result = SqlMapper.Query<T>(cnn, DynamicQuery.GetPagingQuery(tableName, pageNumber, pageSize, sortProperty, sortDescending, searchText));
            return result;
        }

        public static void ExecuteViaStoredProcedure(this IDbConnection cnn, string storedProcedureName, DynamicParameters parameters)
        {
            SqlMapper.Query(cnn, storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}