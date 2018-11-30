//-----------------------------------------------------------------------
// <copyright file="IUsersRepository.cs" company="SA Technology">
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
    /// Users interface 
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Add Users
        /// </summary>
        /// <param name="users">Array of Users</param>
        /// <returns></returns>
        Task AddAsync(Users[] users);

        /// <summary>
        /// Add Users
        /// </summary>
        /// <param name="users">Array of Users</param>
        /// <returns>Array of Users</returns>
        Users[] Add(Users[] users);

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="id">Users id</param>
        /// <returns>Users entity</returns>
        Users Get(string id);

        /// <summary>
        /// Get Users collection
        /// </summary>
        /// <param name="ids">Array of Users id</param>
        /// <returns>Dictionary based Users collection</returns>
        Dictionary<string, Users> Get(string[] ids);

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Users</returns>
        Users[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>Array of Users</returns>
        Users[] GetAll();

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Users</returns>
        Users[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update Users
        /// </summary>
        /// <param name="users">Array of Users</param>
        /// <returns>Array of Users</returns>
        Users[] Update(Users[] users);

        /// <summary>
        /// Delete Users
        /// </summary>
        /// <param name="id">Users id</param>
        /// <returns>Array of Users</returns>
        Users[] Delete(string id);

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>Array of Users</returns>
        UsersWrapper[] GetAllUsers();
    }
}
