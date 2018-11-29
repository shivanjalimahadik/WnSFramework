//-----------------------------------------------------------------------
// <copyright file="IResourceCenterRepository.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BusinessLogic.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    using Entities.Wrappers;

    /// <summary>
    /// ResourceCenter interface 
    /// </summary>
    public interface IResourceCenterRepository
    {
        /// <summary>
        /// Add ResourceCenter
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter</param>
        /// <returns></returns>
        Task AddAsync(ResourceCenter[] resourceCenters);

        /// <summary>
        /// Add ResourceCenter
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter</param>
        /// <returns>Array of ResourceCenter</returns>
        ResourceCenter[] Add(ResourceCenter[] resourceCenters);

        /// <summary>
        /// Get ResourceCenter
        /// </summary>
        /// <param name="id">ResourceCenter id</param>
        /// <returns>ResourceCenter proces</returns>
        ResourceCenter Get(string id);

        /// <summary>
        /// Get ResourceCenter collection
        /// </summary>
        /// <param name="ids">Array of ResourceCenter id</param>
        /// <returns>Dictionary based ResourceCenter collection</returns>
        Dictionary<string, ResourceCenter> Get(string[] ids);

        /// <summary>
        /// Get ResourceCenter
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of ResourceCenter</returns>
        ResourceCenter[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of ResourceCenter</returns>
        ResourceCenter[] GetAll();

        /// <summary>
        /// Get ResourceCenter
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of ResourceCenter</returns>
        ResourceCenter[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update ResourceCenter
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter</param>
        /// <returns>Array of ResourceCenter</returns>
        ResourceCenter[] Update(ResourceCenter[] resourceCenters);

        /// <summary>
        /// Delete ResourceCenter
        /// </summary>
        /// <param name="id">ResourceCenter id</param>
        /// <returns>Array of ResourceCenter</returns>
        ResourceCenter[] Delete(string id);

        /// <summary>
        /// Get all Resource Center
        /// </summary>
        /// <returns></returns>
        ResourceCenterWrapper[] GetAllResourceCenters();
    }
}
