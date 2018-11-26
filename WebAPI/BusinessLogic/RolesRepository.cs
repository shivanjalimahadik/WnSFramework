//-----------------------------------------------------------------------
// <copyright file="RolesRepository.cs" company="SA Technology">
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
    public class RolesRepository : IRolesRepository
    {
        /// <summary>
        /// IRolesDA variable
        /// </summary>
        private IRolesDA _RolesDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public RolesRepository(IRolesDA rolesDA)
        {
            _RolesDA = rolesDA;
        }

        /// <summary>
        /// Add Roles
        /// </summary>
        /// <param name="roles">Array of Roles</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(Roles[] roles)
        {
            await _RolesDA.AddRolesAsync(roles);
        }

        /// <summary>
        /// Add Roles
        /// </summary>
        /// <param name="roles">Array of Roles</param>
        /// <returns>Array of Roles</returns>
        public Roles[] Add(Roles[] roles)
        {
            return _RolesDA.AddRoless(roles);
        }

        /// <summary>
        /// Get Roles
        /// </summary>
        /// <param name="id">Roles id</param>
        /// <returns>Roles</returns>
        public Roles Get(string id)
        {
            return _RolesDA.GetRoles(id);
        }

        /// <summary>
        /// Get Roles collection
        /// </summary>
        /// <param name="ids">Array of Roles id</param>
        /// <returns>Dictionary based Roles collection</returns>
        public Dictionary<string, Roles> Get(string[] ids)
        {
            return _RolesDA.GetRoless(ids);
        }

        /// <summary>
        /// Get Roles
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Roles</returns>
        public Roles[] Get(IEnumerable<Guid?> ids)
        {
            return _RolesDA.GetRoless(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of Roles</returns>
        public Roles[] GetAll()
        {
            return _RolesDA.GetAll();
        }

        /// <summary>
        /// Get Roles
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Roles</returns>
        public Roles[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _RolesDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update Roles
        /// </summary>
        /// <param name="roles">Array of Roles</param>
        /// <returns>Array of Roles</returns>
        public Roles[] Update(Roles[] roles)
        {
            return _RolesDA.UpdateRoless(roles);
        }

        /// <summary>
        /// Delete Roles
        /// </summary>
        /// <param name="id">Roles id</param>
        /// <returns>Array of Roles</returns>
        public Roles[] Delete(string id)
        {
            return _RolesDA.DeleteRoless(id);
        }
    }
}
