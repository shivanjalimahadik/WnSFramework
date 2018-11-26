//-----------------------------------------------------------------------
// <copyright file="ILookupHelper.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Util
{
    /// <summary>
    /// Interface for lookup helper
    /// </summary>
    public interface ILookupHelper
    {
        /// <summary>
        /// Gets filtered entities
        /// </summary>
        /// <param name="limit">Limit number</param>
        /// <param name="sortProperty">Sort property</param>
        /// <param name="sortDescending">Whether to sort descending</param>
        /// <param name="searchProperty">Search property</param>
        /// <param name="searchText">Search text</param>
        /// <param name="tableName">Table name</param>
        /// <param name="columns">Column names</param>
        /// <returns>Filtered entities</returns>
        dynamic[] GetFilteredEntities(int limit, string sortProperty, bool sortDescending, string searchProperty, string searchText, string tableName, string[] columns);
    }
}