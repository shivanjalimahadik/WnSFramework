//-----------------------------------------------------------------------
// <copyright file="IUsersDA.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    /// <summary>
    /// IUsers interface. Used to define all abstract methods of Users entity.
    /// </summary>
    public interface IUsersDA
    {
        /// <summary>
        /// Adds Users entity to database asynchronously.
        /// </summary>
        /// <param name="users">Array of Users.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddUsersAsync(Users[] users);

        /// <summary>
        /// Adds Users entity to database.
        /// </summary>
        /// <param name="users">Array of Users</param>
        /// <returns>Added array of Users</returns>
        Users[] AddUserss(Users[] users);

        /// <summary>
        /// Gets a single Users based on id.
        /// </summary>
        /// <param name="id">Users Id</param>
        /// <returns>Users entity.</returns>
        Users GetUsers(string id);

        /// <summary>
        /// Gets a Users in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of Users id</param>
        /// <returns>Dictionary of Users entity</returns>
        Dictionary<string, Users> GetUserss(string[] ids);

        /// <summary>
        /// Gets a Users collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of Users id</param>
        /// <returns>Array of Users entity</returns>
        Users[] GetUserss(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all Userss
        /// </summary>
        /// <returns>Array of Users entity</returns>
        Users[] GetAll();

        /// <summary>
        /// Gets a Users collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of Users id</param>
        /// <returns>Array of Users entity</returns>
        Users[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a Users entity in database
        /// </summary>
        /// <param name="users">Array of Users</param>
        /// <returns>Updated array of Users entity</returns>
        Users[] UpdateUserss(Users[] users);

        /// <summary>
        /// Deletes a Users from database.
        /// </summary>
        /// <param name="id">Guid representing Users id</param>
        /// <returns>Array of Users entity</returns>
        Users[] DeleteUserss(string id);
    }
}
