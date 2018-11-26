//-----------------------------------------------------------------------
// <copyright file="IResourceCenterDA.cs" company="SA Technology">
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
    /// IResourceCenter interface. Used to define all abstract methods of ResourceCenter proces.
    /// </summary>
    public interface IResourceCenterDA
    {
        /// <summary>
        /// Adds ResourceCenter proces to database asynchronously.
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddResourceCenterAsync(ResourceCenter[] resourceCenters);

        /// <summary>
        /// Adds ResourceCenter proces to database.
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter</param>
        /// <returns>Added array of ResourceCenter</returns>
        ResourceCenter[] AddResourceCenters(ResourceCenter[] resourceCenters);

        /// <summary>
        /// Gets a single ResourceCenter based on id.
        /// </summary>
        /// <param name="id">ResourceCenter Id</param>
        /// <returns>ResourceCenter proces.</returns>
        ResourceCenter GetResourceCenter(string id);

        /// <summary>
        /// Gets a ResourceCenter in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of ResourceCenter id</param>
        /// <returns>Dictionary of ResourceCenter proces</returns>
        Dictionary<string, ResourceCenter> GetResourceCenters(string[] ids);

        /// <summary>
        /// Gets a ResourceCenter collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of ResourceCenter id</param>
        /// <returns>Array of ResourceCenter proces</returns>
        ResourceCenter[] GetResourceCenters(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all ResourceCenters
        /// </summary>
        /// <returns>Array of ResourceCenter proces</returns>
        ResourceCenter[] GetAll();

        /// <summary>
        /// Gets a ResourceCenter collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of ResourceCenter id</param>
        /// <returns>Array of ResourceCenter proces</returns>
        ResourceCenter[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a ResourceCenter proces in database
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter</param>
        /// <returns>Updated array of ResourceCenter proces</returns>
        ResourceCenter[] UpdateResourceCenters(ResourceCenter[] resourceCenters);

        /// <summary>
        /// Deletes a ResourceCenter from database.
        /// </summary>
        /// <param name="id">Guid representing ResourceCenter id</param>
        /// <returns>Array of ResourceCenter proces</returns>
        ResourceCenter[] DeleteResourceCenters(string id);
    }
}
