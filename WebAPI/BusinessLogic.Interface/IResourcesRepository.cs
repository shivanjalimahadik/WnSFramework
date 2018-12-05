//-----------------------------------------------------------------------
// <copyright file="IResourcesRepository.cs" company="SA Technology">
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
    /// Resources interface 
    /// </summary>
    public interface IResourcesRepository
    {
        /// <summary>
        /// Add Resources
        /// </summary>
        /// <param name="resources">Array of Resources</param>
        /// <returns></returns>
        Task AddAsync(Resources[] resources);

        /// <summary>
        /// Add Resources
        /// </summary>
        /// <param name="resources">Array of Resources</param>
        /// <returns>Array of Resources</returns>
        Resources[] Add(Resources[] resources);

        /// <summary>
        /// Get Resources
        /// </summary>
        /// <param name="id">Resources id</param>
        /// <returns>Resources proces</returns>
        Resources Get(string id);

        /// <summary>
        /// Get Resources collection
        /// </summary>
        /// <param name="ids">Array of Resources id</param>
        /// <returns>Dictionary based Resources collection</returns>
        Dictionary<string, Resources> Get(string[] ids);

        /// <summary>
        /// Get Resources
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Resources</returns>
        Resources[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of Resources</returns>
        Resources[] GetAll();

        /// <summary>
        /// Get Resources
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Resources</returns>
        Resources[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update Resources
        /// </summary>
        /// <param name="resources">Array of Resources</param>
        /// <returns>Array of Resources</returns>
        Resources[] Update(Resources[] resources);

        /// <summary>
        /// Delete Resources
        /// </summary>
        /// <param name="id">Resources id</param>
        /// <returns>Array of Resources</returns>
        Resources[] Delete(string id);

        /// <summary>
        /// Get all Resources
        /// </summary>
        /// <returns></returns>
        ResourceWrapper[] GetAllResources();
    }
}
