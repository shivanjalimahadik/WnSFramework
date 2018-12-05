//-----------------------------------------------------------------------
// <copyright file="UserRoleMappingRepository.cs" company="SA Technology">
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

    public class UserRoleMappingRepository : IUserRoleMappingRepository
    {
        /// <summary>
        /// IUserRoleMappingDA variable
        /// </summary>
        private IUserRoleMappingDA _UserRoleMappingDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleMappingRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public UserRoleMappingRepository(IUserRoleMappingDA userRoleMappingsDA)
        {
            _UserRoleMappingDA = userRoleMappingsDA;
        }

        /// <summary>
        /// Add UserRoleMapping
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(UserRoleMapping[] userRoleMappings)
        {
            await _UserRoleMappingDA.AddUserRoleMappingAsync(userRoleMappings);
        }

        /// <summary>
        /// Add UserRoleMapping
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping</param>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleMapping[] Add(UserRoleMapping[] userRoleMappings)
        {
            return _UserRoleMappingDA.AddUserRoleMappings(userRoleMappings);
        }

        /// <summary>
        /// Get UserRoleMapping
        /// </summary>
        /// <param name="id">UserRoleMapping id</param>
        /// <returns>UserRoleMapping</returns>
        public UserRoleMapping Get(string id)
        {
            return _UserRoleMappingDA.GetUserRoleMapping(id);
        }

        /// <summary>
        /// Get UserRoleMapping collection
        /// </summary>
        /// <param name="ids">Array of UserRoleMapping id</param>
        /// <returns>Dictionary based UserRoleMapping collection</returns>
        public Dictionary<string, UserRoleMapping> Get(string[] ids)
        {
            return _UserRoleMappingDA.GetUserRoleMappings(ids);
        }

        /// <summary>
        /// Get UserRoleMapping
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleMapping[] Get(IEnumerable<Guid?> ids)
        {
            return _UserRoleMappingDA.GetUserRoleMappings(ids);
        }

        /// <summary>
        /// Get all User role mappings
        /// </summary>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleMapping[] GetAll()
        {
            return _UserRoleMappingDA.GetAll();
        }

        /// <summary>
        /// Get all User role mappings
        /// </summary>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleWrapper[] GetAllUserRoleMapping()
        {
            return _UserRoleMappingDA.GetAllUserRoleMapping();
        }

        /// <summary>
        /// Get UserRoleMapping
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleMapping[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _UserRoleMappingDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update UserRoleMapping
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping</param>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleMapping[] Update(UserRoleMapping[] userRoleMappings)
        {
            return _UserRoleMappingDA.UpdateUserRoleMappings(userRoleMappings);
        }

        /// <summary>
        /// Delete UserRoleMapping
        /// </summary>
        /// <param name="id">UserRoleMapping id</param>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleMapping[] Delete(string id)
        {
            return _UserRoleMappingDA.DeleteUserRoleMappings(id);
        }
    }
}
