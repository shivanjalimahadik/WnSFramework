//-----------------------------------------------------------------------
// <copyright file="DataAccessBase.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Util
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Dapper;
    using DataAccess.Interface;
    using Entities;

    /// <summary>
    /// Abstract class of type T
    /// </summary>
    /// <typeparam name="T">Type of the value for which database operations will be performed</typeparam>
    public abstract class DataAccessBase<T> : IDataAccessBase<T> where T : BaseEntity
    {
        /// <summary>
        /// Variable of type SQL database settings
        /// </summary>
        protected readonly ISqlDatabaseSettings SqlDataBaseSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="{DataAccessBase<T>}" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">Instance of SQL database settings</param>
        public DataAccessBase(ISqlDatabaseSettings sqlDataBaseSettings)
        {
            this.SqlDataBaseSettings = sqlDataBaseSettings;
        }

        /// <summary>
        /// Gets SQL database connection
        /// </summary>
        internal IDbConnection _sqlConnection
        {
            get { return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString); }
        }

        /// <summary>
        /// Gets database table name
        /// </summary>
        private string _tableName
        {
            get { return this.GetTableName(); }
        }

        /// <summary>
        /// Adds array of items of type T in database
        /// </summary>
        /// <param name="items">Array of items of type T</param>
        /// <returns>Array of items of type T in database</returns>
        public virtual T[] Add(T[] items)
        {
            if (items == null || items.Length == 0)
            {
                return items;
            }

            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                dbConnection.InsertMany(this._tableName, items.Select(x => (dynamic)this.Mapping(x)).ToArray());
            }

            return items;
        }

        /// <summary>
        /// Executes and returns single value from database
        /// </summary>
        /// <typeparam name="S">Type of the value</typeparam>
        /// <param name="query">SQL query</param>
        /// <param name="paramValues">Parameter values</param>
        /// <returns>Scalar value</returns>
        public virtual S ExecuteScalar<S>(string query, object paramValues)
        {
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                return dbConnection.ExecuteScalar<S>(query, paramValues);
            }
        }

        /// <summary>
        /// Updates an item of type T in database
        /// </summary>
        /// <param name="item">Item of type T</param>
        public virtual void Update(T item)
        {
            var parameters = (object)this.Mapping(item);
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                dbConnection.Update(this._tableName, parameters);
            }
        }

        /// <summary>
        /// Removes an item of type T from database
        /// </summary>
        /// <param name="item">Item of type T</param>
        public virtual void Remove(T item)
        {
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE " + this._tableName + " SET IsActive = 0 WHERE ID=@ID", new { ID = item.Id });
            }
        }

        /// <summary>
        /// Finds list of items of type T
        /// </summary>
        /// <param name="ids">List of Guids of items of type T</param>
        /// <returns>List of items of type T</returns>
        public virtual List<T> FindByIds(List<string> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return new List<T>();
            }

            ids = ids.Distinct().ToList();

            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                var filter = string.Empty;
                foreach (var id in ids)
                {
                    filter += "'" + id + "'";
                    if (ids.Last() != id)
                    {
                        filter += ",";
                    }
                }

                return dbConnection.Query<T>(string.Format("SELECT * FROM {0} WHERE ID in ({1}) AND IsActive = 1", this._tableName, filter))
                        .ToList();
            }

        }

        /// <summary>
        /// Finds list of items of type T
        /// </summary>
        /// <param name="id">Id of the type. Typicaly primary key</param>
        /// <returns>List of items of type T</returns>
        public virtual List<T> GetCollectionById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new List<T>();
            }

            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                var filter = "'" + id + "'";

                return dbConnection.Query<T>(string.Format("SELECT * FROM {0} WHERE ID in ({1}) AND IsActive = 1", this._tableName, filter))
                        .ToList();
            }

        }

        /// <summary>
        /// finds item of type T from database.
        /// </summary>
        /// <param name="id">guid of item of type T</param>
        /// <returns>Item of type T</returns>
        public virtual T FindById(string id)
        {
            return this.FindByIds(new List<string> { id }).SingleOrDefault();
        }

        /// <summary>
        /// Finds items of type T from database.
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>IEnumerable collection of items of type T</returns>
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> items;

            // extract the dynamic sql query and parameters from predicate
            var result = DynamicQuery.GetDynamicQuery(this._tableName, predicate);

            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                items = dbConnection.Query<T>(result.Sql, (object)result.Param);
            }

            return items;
        }

        /// <summary>
        /// Adds items of type T in database
        /// </summary>
        /// <param name="items">Array of items of type T</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(T[] items)
        {
            if (items == null || items.Length == 0)
            {
                return;
            }

            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                await dbConnection.InsertManyAsync(this._tableName, items.Select(x => (dynamic)this.Mapping(x)).ToArray());
            }
        }

        /// <summary>
        /// Gets count of items of type T in table
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns>Count of items of type T</returns>
        public virtual int Count(string query)
        {
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                var res = dbConnection.ExecuteScalar<int>(query);
                return res;
            }

            return 0;
        }

        /// <summary>
        /// Finds and item of type T from database.
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns>IEnumerable collection of items of type T</returns>
        public virtual IEnumerable<T> Find(string query)
        {
            IEnumerable<T> items;
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                items = dbConnection.Query<T>(query);
            }

            return items;
        }

        /// <summary>
        /// Finds and item of type T from database.
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="paramValues">Parameter values</param>
        /// <returns>IEnumerable collection of items of type T</returns>
        public virtual IEnumerable<T> Find(string query, object paramValues)
        {
            IEnumerable<T> items;
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                items = dbConnection.Query<T>(query, paramValues, commandTimeout: 9999);
            }

            return items;
        }

        /// <summary>
        /// Finds items of type T.
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="ids">IEnumerable collection of Guids of items of type T</param>
        /// <returns>IEnumerable collection of items of type T</returns>
        public virtual IEnumerable<T> FindByTempTableIds(string query, IEnumerable<Guid> ids)
        {
            IEnumerable<T> items;
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                dbConnection.Execute("CREATE TABLE #tempIds(Id uniqueidentifier not null);");
                while (ids.Any())
                {
                    var idsToInsert = ids.Take(1000);
                    ids = ids.Skip(1000).ToList();

                    StringBuilder insertQuery = new StringBuilder("INSERT INTO #tempIds VALUES ('");
                    insertQuery.Append(string.Join("'),('", idsToInsert));
                    insertQuery.Append("');");

                    dbConnection.Execute(insertQuery.ToString());
                }

                query = query.Replace("@Ids", "select distinct Id from #tempIds");
                items = dbConnection.Query<T>(query, null, commandTimeout: 9999);
            }

            return items;
        }

        /// <summary>
        /// Finds item from database
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="paramValues">Parameter values</param>
        /// <returns>IEnumerable collection of items</returns>
        public virtual IEnumerable<dynamic> FindDynamic(string query, object paramValues)
        {
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                return dbConnection.Query(query, paramValues);
            }
        }

        /// <summary>
        /// Finds all items of type T from database
        /// </summary>
        /// <returns>IEnumerable collection of items of type T</returns>
        public virtual IEnumerable<T> FindAll()
        {
            IEnumerable<T> items;

            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                items = dbConnection.Query<T>("SELECT * FROM " + this._tableName + " WHERE IsActive = 1");
            }

            return items;
        }

        /// <summary>
        /// Deletes item from database.
        /// </summary>
        /// <param name="dbIds">Array of Guids</param>
        public virtual void DeleteByGuid(Guid[] dbIds)
        {
            using (IDbConnection dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                var items = dbIds.Select(x => new { ID = x });
                SqlMapper.Execute(dbConnection, "UPDATE " + this._tableName + " SET IsActive = 0 WHERE ID=@ID", items);
            }
        }

        /// <summary>
        /// Finds page for the item of type T
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortProperty">sort property</param>
        /// <param name="sortDescending">Whether to sort descending</param>
        /// <param name="expression">Predicate expression</param>
        /// <returns>IEnumerable collection of type T</returns>
        public virtual IEnumerable<T> FindPage(int pageNumber, int pageSize, string sortProperty, bool sortDescending, Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> items;

            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                var queryResult = DynamicQuery.GetDynamicPageQuery(this._tableName, pageNumber, pageSize, sortProperty, sortDescending, expression);
                items = dbConnection.Query<T>(queryResult.Sql, (object)queryResult.Param);
            }

            return items;
        }
        
        /// <summary>
        /// Executes SQL command
        /// </summary>
        /// <param name="commands">SQL command</param>
        /// <param name="paramValus">Parameter values</param>
        /// <returns>Successful execution returns 0</returns>
        public virtual int ExecuteCommands(string commands, object paramValus)
        {
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                return dbConnection.ExecuteCommands(commands, paramValus);
            }
        }

        /// <summary>
        /// Executes SQL query
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="paramValus">Parameter values</param>
        /// <returns>IEnumerable collection of items</returns>
        public virtual IEnumerable<dynamic> ExecuteQuery(string query, object paramValus)
        {
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                return dbConnection.Query(query, paramValus);
            }
        }

        /// <summary>
        /// Executes SQL query
        /// </summary>
        /// <typeparam name="T">Type to be returned</typeparam>
        /// <param name="query">SQL query</param>
        /// <param name="paramValus">Parameter values</param>
        /// <returns>IEnumerable collection of items of type T</returns>
        public virtual IEnumerable<T> ExecuteQuery<T>(string query, object paramValus)
        {
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                var result = dbConnection.Query<T>(query, paramValus);
                return result;
            }
        }

        /// <summary>
        /// Updates an item of type T in database.
        /// </summary>
        /// <param name="item">Array of items of type T</param>
        public virtual void Update(T[] item)
        {
            var parameters = item.Select(x => this.Mapping(x)).ToArray();
            if (parameters.Count() > 0)
            {
                using (var dbConnection = this._sqlConnection)
                {
                    dbConnection.Open();
                    dbConnection.UpdateMany(this._tableName, parameters);
                }
            }
        }

        /// <summary>
        /// Updates an item of type T in database.
        /// </summary>
        /// <param name="item">Array of items of type T</param>
        /// <returns>Asynchronous task</returns>
        public virtual async Task UpdateAsync(T[] item)
        {
            try
            {
                await this.UpdateWithTask(item);
            }
            catch (SqlException)
            {
                await this.UpdateWithTask(item);
            }
        }

        /// <summary>
        /// Deletes an item from database
        /// </summary>
        /// <param name="dbIds">Array of ids of items to be deleted</param>
        public virtual void DeleteByDbId(string[] dbIds)
        {
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                var items = dbIds.Select(x => new { ID = x });
                dbConnection.Execute("UPDATE " + this._tableName + " SET IsActive = 0 WHERE ID=@ID", items);
            }
        }

        /// <summary>
        /// Gets paging for item of type T
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortProperty">Sort property</param>
        /// <param name="sortDescending">Whether to sort descending</param>
        /// <param name="searchText">Search text</param>
        /// <returns>IEnumerable collection of items of type T</returns>
        public virtual IEnumerable<T> GetPaging(int pageNumber, int pageSize, string sortProperty, bool sortDescending, string searchText)
        {
            IEnumerable<T> items = null;

            using (IDbConnection dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                items = dbConnection.GetPaging<T>(this._tableName, pageNumber, pageSize, sortProperty, sortDescending, searchText);
            }

            return items;
        }

        /// <summary>
        /// Abstract method to get table name.
        /// </summary>
        /// <returns>Table name</returns>
        internal abstract string GetTableName();

        /// <summary>
        /// Gets item with all properties mapped.
        /// </summary>
        /// <param name="item">Item of type T</param>
        /// <returns>An item of type T</returns>
        internal virtual dynamic Mapping(T item)
        {
            // override this method in specific implementation to select data which needs to be sent to SQL DB
            return item;
        }

        /// <summary>
        /// Gets columns of tables from database
        /// </summary>
        /// <param name="columns">Column names</param>
        /// <param name="index">Index value.</param>
        /// <returns>Column for index</returns>
        private static string GetColumnQueryForIndex(string[] columns, int index)
        {
            return string.Concat("( ", string.Join(", ", columns.Select(col => string.Concat("@", col, index))), "  )");
        }

        /// <summary>
        /// Get properties of type T
        /// </summary>
        /// <param name="entity">Dynamic entity</param>
        /// <returns>Array of PropertyInfo</returns>
        private static PropertyInfo[] GetEntityProperties(dynamic entity)
        {
            return entity.GetType().GetProperties();
        }

        /// <summary>
        /// Gets column names of table
        /// </summary>
        /// <param name="properties">Array of PropertyInfo</param>
        /// <returns>String array containing column names</returns>
        private static string[] GetColumnNames(PropertyInfo[] properties)
        {
            return properties.Select(prop => prop.Name).Where(name => name != "Id").ToArray();
        }
        
        /// <summary>
        /// Gets entities
        /// </summary>
        /// <param name="items">Array of items of type T</param>
        /// <returns>Dynamic array</returns>
        private dynamic[] GetEntities(T[] items)
        {
            return items.Select(x => this.Mapping(x)).ToArray();
        }

        /// <summary>
        /// Updates an item of type T in database.
        /// </summary>
        /// <param name="item">Array of items of type T</param>
        /// <returns>Asynchronous task</returns>
        private async Task UpdateWithTask(T[] item)
        {
            var parameters = item.Select(x => this.Mapping(x)).ToArray();
            using (var dbConnection = this._sqlConnection)
            {
                dbConnection.Open();
                await dbConnection.UpdateManyAsync(this._tableName, parameters);
            }
        }

        public virtual void ExecuteStoredProcedure(string storedProcedureName, DynamicParameters parameters)
        {
            using (var dbconnection = this._sqlConnection)
            {
                dbconnection.Open();
                dbconnection.ExecuteViaStoredProcedure(storedProcedureName, parameters);
            }
        }
    }
}
