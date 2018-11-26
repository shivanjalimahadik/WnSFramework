//-----------------------------------------------------------------------
// <copyright file="IResourcesDA.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    /// <summary>
    /// IResources interface. Used to define all abstract methods of Resources proces.
    /// </summary>
    public interface IResourcesDA
    {
        /// <summary>
        /// Adds Resources proces to database asynchronously.
        /// </summary>
        /// <param name="resources">Array of Resources.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddResourcesAsync(Resources[] resources);

        /// <summary>
        /// Adds Resources proces to database.
        /// </summary>
        /// <param name="resources">Array of Resources</param>
        /// <returns>Added array of Resources</returns>
        Resources[] AddResourcess(Resources[] resources);

        /// <summary>
        /// Gets a single Resources based on id.
        /// </summary>
        /// <param name="id">Resources Id</param>
        /// <returns>Resources proces.</returns>
        Resources GetResources(string id);

        /// <summary>
        /// Gets a Resources in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of Resources id</param>
        /// <returns>Dictionary of Resources proces</returns>
        Dictionary<string, Resources> GetResourcess(string[] ids);

        /// <summary>
        /// Gets a Resources collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of Resources id</param>
        /// <returns>Array of Resources proces</returns>
        Resources[] GetResourcess(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all Resourcess
        /// </summary>
        /// <returns>Array of Resources proces</returns>
        Resources[] GetAll();

        /// <summary>
        /// Gets a Resources collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of Resources id</param>
        /// <returns>Array of Resources proces</returns>
        Resources[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a Resources proces in database
        /// </summary>
        /// <param name="resources">Array of Resources</param>
        /// <returns>Updated array of Resources proces</returns>
        Resources[] UpdateResourcess(Resources[] resources);

        /// <summary>
        /// Deletes a Resources from database.
        /// </summary>
        /// <param name="id">Guid representing Resources id</param>
        /// <returns>Array of Resources proces</returns>
        Resources[] DeleteResourcess(string id);
    }
}
