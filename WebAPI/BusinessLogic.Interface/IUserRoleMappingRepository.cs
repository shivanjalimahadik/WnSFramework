//-----------------------------------------------------------------------
// <copyright file="IUserRoleMappingRepository.cs" company="SA Technology">
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
    /// UserRoleMapping interface 
    /// </summary>
    public interface IUserRoleMappingRepository
    {
        /// <summary>
        /// Add UserRoleMapping
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping</param>
        /// <returns></returns>
        Task AddAsync(UserRoleMapping[] userRoleMappings);

        /// <summary>
        /// Add UserRoleMapping
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping</param>
        /// <returns>Array of UserRoleMapping</returns>
        UserRoleMapping[] Add(UserRoleMapping[] userRoleMappings);

        /// <summary>
        /// Get UserRoleMapping
        /// </summary>
        /// <param name="id">UserRoleMapping id</param>
        /// <returns>UserRoleMapping proces</returns>
        UserRoleMapping Get(string id);

        /// <summary>
        /// Get UserRoleMapping collection
        /// </summary>
        /// <param name="ids">Array of UserRoleMapping id</param>
        /// <returns>Dictionary based UserRoleMapping collection</returns>
        Dictionary<string, UserRoleMapping> Get(string[] ids);

        /// <summary>
        /// Get UserRoleMapping
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of UserRoleMapping</returns>
        UserRoleMapping[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all User Role mappings
        /// </summary>
        /// <returns>Array of UserRoleMapping</returns>
        UserRoleMapping[] GetAll();

        /// <summary>
        /// Get all user role mappings
        /// </summary>
        /// <returns>Array of UserRoleMapping</returns>
        UserRoleWrapper[] GetAllUserRoleMapping();

        /// <summary>
        /// Get UserRoleMapping
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of UserRoleMapping</returns>
        UserRoleMapping[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update UserRoleMapping
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping</param>
        /// <returns>Array of UserRoleMapping</returns>
        UserRoleMapping[] Update(UserRoleMapping[] userRoleMappings);

        /// <summary>
        /// Delete UserRoleMapping
        /// </summary>
        /// <param name="id">UserRoleMapping id</param>
        /// <returns>Array of UserRoleMapping</returns>
        UserRoleMapping[] Delete(string id);
    }
}
