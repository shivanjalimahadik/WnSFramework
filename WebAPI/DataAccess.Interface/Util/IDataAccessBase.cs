//-----------------------------------------------------------------------
// <copyright file="IDataAccessBase.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// IDataAccessBase interface of type T. Used to define all abstract methods of required for database operations.
    /// </summary>
    /// <typeparam name="T">Type of the value to be returned</typeparam>
    public interface IDataAccessBase<T> where T : class
    {
        /// <summary>
        /// Adds array of items of type T to database
        /// </summary>
        /// <param name="items">Array of items of type T</param>
        /// <returns>Added array of items of type T</returns>
        T[] Add(T[] items);

        /// <summary>
        /// Removes item of type T from database.
        /// </summary>
        /// <param name="item">Item of type T</param>
        void Remove(T item);

        /// <summary>
        /// Updates an item of type T
        /// </summary>
        /// <param name="item">Item of type T</param>
        void Update(T item);

        /// <summary>
        /// Find an item of type T by id
        /// </summary>
        /// <param name="id">Guid of item of type T</param>
        /// <returns>Item of type T</returns>
        T FindById(string id);

        /// <summary>
        /// Gets list of items of type T
        /// </summary>
        /// <param name="ids">List of Guids of items of type T</param>
        /// <returns>List of items of type T</returns>
        List<T> FindByIds(List<string> ids);

        /// <summary>
        /// Gets list of items of type T
        /// </summary>
        /// <param name="id">id of the type </param>
        /// <returns>List of items of type T</returns>
        List<T> GetCollectionById(string id);

        /// <summary>
        /// Gets IEnumerable collection of items of type T.
        /// </summary>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>IEnumerable collection of items of type T</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets a collection of items of type T
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="ids">IEnumerable collection of temp table Guids</param>
        /// <returns>IEnumerable collection of items of type T</returns>
        IEnumerable<T> FindByTempTableIds(string query, IEnumerable<Guid> ids);

        /// <summary>
        /// Gets IEnumerable collection of items of type T.
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns>IEnumerable collection of items of type T.</returns>
        IEnumerable<T> Find(string query);

        /// <summary>
        /// Gets IEnumerable collection of items of type T.
        /// </summary>
        /// <returns>IEnumerable collection of items of type T.</returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// Gets IEnumerable collection of dynamic types
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="paramValues">Parameter values</param>
        /// <returns>IEnumerable collection of dynamic types</returns>
        IEnumerable<dynamic> FindDynamic(string query, object paramValues);

        /// <summary>
        /// Gets IEnumerable collection of items of type T
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortProperty">Sort property</param>
        /// <param name="sortDescending">sort Descending</param>
        /// <param name="expression">Predicate expression</param>
        /// <returns>IEnumerable collection of items of type T</returns>
        IEnumerable<T> FindPage(int pageNumber, int pageSize, string sortProperty, bool sortDescending, Expression<Func<T, bool>> expression);
    }
}
