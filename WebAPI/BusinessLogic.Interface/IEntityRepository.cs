//-----------------------------------------------------------------------
// <copyright file="IEntityRepository.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BusinessLogic.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    /// <summary>
    /// Entity interface 
    /// </summary>
    public interface IEntityRepository
    {
        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entitys">Array of Entity</param>
        /// <returns></returns>
        Task AddAsync(Entity[] entitys);

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entitys">Array of Entity</param>
        /// <returns>Array of Entity</returns>
        Entity[] Add(Entity[] entitys);

        /// <summary>
        /// Get Entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity entity</returns>
        Entity Get(string id);

        /// <summary>
        /// Get Entity collection
        /// </summary>
        /// <param name="ids">Array of Entity id</param>
        /// <returns>Dictionary based Entity collection</returns>
        Dictionary<string, Entity> Get(string[] ids);

        /// <summary>
        /// Get Entity
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Entity</returns>
        Entity[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of Entity</returns>
        Entity[] GetAll();

        /// <summary>
        /// Get Entity
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Entity</returns>
        Entity[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entitys">Array of Entity</param>
        /// <returns>Array of Entity</returns>
        Entity[] Update(Entity[] entitys);

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Array of Entity</returns>
        Entity[] Delete(string id);
    }
}
