//-----------------------------------------------------------------------
// <copyright file="ResourceCenterRepository.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLogic.Interface;
    using DataAccess.Interface;
    using Entities;
    using Entities.Wrappers;

    public class ResourceCenterRepository : IResourceCenterRepository
    {
        /// <summary>
        /// IResourceCenterDA variable
        /// </summary>
        private IResourceCenterDA _ResourceCenterDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceCenterRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public ResourceCenterRepository(IResourceCenterDA resourceCenterDA)
        {
            _ResourceCenterDA = resourceCenterDA;
        }

        /// <summary>
        /// Add ResourceCenter
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(ResourceCenter[] resourceCenters)
        {
            await _ResourceCenterDA.AddResourceCenterAsync(resourceCenters);
        }

        /// <summary>
        /// Add ResourceCenter
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter</param>
        /// <returns>Array of ResourceCenter</returns>
        public ResourceCenter[] Add(ResourceCenter[] resourceCenters)
        {
            return _ResourceCenterDA.AddResourceCenters(resourceCenters);
        }

        /// <summary>
        /// Get ResourceCenter
        /// </summary>
        /// <param name="id">ResourceCenter id</param>
        /// <returns>ResourceCenter proces</returns>
        public ResourceCenter Get(string id)
        {
            return _ResourceCenterDA.GetResourceCenter(id);
        }

        /// <summary>
        /// Get ResourceCenter collection
        /// </summary>
        /// <param name="ids">Array of ResourceCenter id</param>
        /// <returns>Dictionary based ResourceCenter collection</returns>
        public Dictionary<string, ResourceCenter> Get(string[] ids)
        {
            return _ResourceCenterDA.GetResourceCenters(ids);
        }

        /// <summary>
        /// Get ResourceCenter
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of ResourceCenter</returns>
        public ResourceCenter[] Get(IEnumerable<Guid?> ids)
        {
            return _ResourceCenterDA.GetResourceCenters(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of ResourceCenter</returns>
        public ResourceCenter[] GetAll()
        {
            return _ResourceCenterDA.GetAll();
        }

        /// <summary>
        /// Get ResourceCenter
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of ResourceCenter</returns>
        public ResourceCenter[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _ResourceCenterDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update ResourceCenter
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter</param>
        /// <returns>Array of ResourceCenter</returns>
        public ResourceCenter[] Update(ResourceCenter[] resourceCenters)
        {
            return _ResourceCenterDA.UpdateResourceCenters(resourceCenters);
        }

        /// <summary>
        /// Delete ResourceCenter
        /// </summary>
        /// <param name="id">ResourceCenter id</param>
        /// <returns>Array of ResourceCenter</returns>
        public ResourceCenter[] Delete(string id)
        {
            return _ResourceCenterDA.DeleteResourceCenters(id);
        }

        public ResourceCenterWrapper[] GetAllResourceCenters()
        {
            return _ResourceCenterDA.GetAllResourceCenters();
        }
    }
}
