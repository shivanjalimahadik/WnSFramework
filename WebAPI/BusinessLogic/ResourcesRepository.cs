//-----------------------------------------------------------------------
// <copyright file="ResourcesRepository.cs" company="SA Technology">
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
    public class ResourcesRepository : IResourcesRepository
    {
        /// <summary>
        /// IResourcesDA variable
        /// </summary>
        private IResourcesDA _ResourcesDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public ResourcesRepository(IResourcesDA resourcesDA)
        {
            _ResourcesDA = resourcesDA;
        }

        /// <summary>
        /// Add Resources
        /// </summary>
        /// <param name="resources">Array of Resources</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(Resources[] resources)
        {
            await _ResourcesDA.AddResourcesAsync(resources);
        }

        /// <summary>
        /// Add Resources
        /// </summary>
        /// <param name="resources">Array of Resources</param>
        /// <returns>Array of Resources</returns>
        public Resources[] Add(Resources[] resources)
        {
            return _ResourcesDA.AddResourcess(resources);
        }

        /// <summary>
        /// Get Resources
        /// </summary>
        /// <param name="id">Resources id</param>
        /// <returns>Resources proces</returns>
        public Resources Get(string id)
        {
            return _ResourcesDA.GetResources(id);
        }

        /// <summary>
        /// Get Resources collection
        /// </summary>
        /// <param name="ids">Array of Resources id</param>
        /// <returns>Dictionary based Resources collection</returns>
        public Dictionary<string, Resources> Get(string[] ids)
        {
            return _ResourcesDA.GetResourcess(ids);
        }

        /// <summary>
        /// Get Resources
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Resources</returns>
        public Resources[] Get(IEnumerable<Guid?> ids)
        {
            return _ResourcesDA.GetResourcess(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of Resources</returns>
        public Resources[] GetAll()
        {
            return _ResourcesDA.GetAll();
        }

        /// <summary>
        /// Get Resources
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Resources</returns>
        public Resources[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _ResourcesDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update Resources
        /// </summary>
        /// <param name="resources">Array of Resources</param>
        /// <returns>Array of Resources</returns>
        public Resources[] Update(Resources[] resources)
        {
            return _ResourcesDA.UpdateResourcess(resources);
        }

        /// <summary>
        /// Delete Resources
        /// </summary>
        /// <param name="id">Resources id</param>
        /// <returns>Array of Resources</returns>
        public Resources[] Delete(string id)
        {
            return _ResourcesDA.DeleteResourcess(id);
        }
    }
}
