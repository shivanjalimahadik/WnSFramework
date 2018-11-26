//-----------------------------------------------------------------------
// <copyright file="IRolesRepository.cs" company="SA Technology">
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
    /// Roles interface 
    /// </summary>
    public interface IRolesRepository
    {
        /// <summary>
        /// Add Roles
        /// </summary>
        /// <param name="roles">Array of Roles</param>
        /// <returns></returns>
        Task AddAsync(Roles[] roles);

        /// <summary>
        /// Add Roles
        /// </summary>
        /// <param name="roles">Array of Roles</param>
        /// <returns>Array of Roles</returns>
        Roles[] Add(Roles[] roles);

        /// <summary>
        /// Get Roles
        /// </summary>
        /// <param name="id">Roles id</param>
        /// <returns>Roles proces</returns>
        Roles Get(string id);

        /// <summary>
        /// Get Roles collection
        /// </summary>
        /// <param name="ids">Array of Roles id</param>
        /// <returns>Dictionary based Roles collection</returns>
        Dictionary<string, Roles> Get(string[] ids);

        /// <summary>
        /// Get Roles
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Roles</returns>
        Roles[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of Roles</returns>
        Roles[] GetAll();

        /// <summary>
        /// Get Roles
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Roles</returns>
        Roles[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update Roles
        /// </summary>
        /// <param name="roles">Array of Roles</param>
        /// <returns>Array of Roles</returns>
        Roles[] Update(Roles[] roles);

        /// <summary>
        /// Delete Roles
        /// </summary>
        /// <param name="id">Roles id</param>
        /// <returns>Array of Roles</returns>
        Roles[] Delete(string id);
    }
}
