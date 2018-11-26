//-----------------------------------------------------------------------
// <copyright file="IUserRoleMappingDA.cs" company="SA Technology">
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
    /// IUserRoleMapping interface. Used to define all abstract methods of UserRoleMapping proces.
    /// </summary>
    public interface IUserRoleMappingDA
    {
        /// <summary>
        /// Adds UserRoleMapping proces to database asynchronously.
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddUserRoleMappingAsync(UserRoleMapping[] userRoleMappings);

        /// <summary>
        /// Adds UserRoleMapping proces to database.
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping</param>
        /// <returns>Added array of UserRoleMapping</returns>
        UserRoleMapping[] AddUserRoleMappings(UserRoleMapping[] userRoleMappings);

        /// <summary>
        /// Gets a single UserRoleMapping based on id.
        /// </summary>
        /// <param name="id">UserRoleMapping Id</param>
        /// <returns>UserRoleMapping proces.</returns>
        UserRoleMapping GetUserRoleMapping(string id);

        /// <summary>
        /// Gets a UserRoleMapping in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of UserRoleMapping id</param>
        /// <returns>Dictionary of UserRoleMapping proces</returns>
        Dictionary<string, UserRoleMapping> GetUserRoleMappings(string[] ids);

        /// <summary>
        /// Gets a UserRoleMapping collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of UserRoleMapping id</param>
        /// <returns>Array of UserRoleMapping proces</returns>
        UserRoleMapping[] GetUserRoleMappings(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all UserRoleMappings
        /// </summary>
        /// <returns>Array of UserRoleMapping proces</returns>
        UserRoleMapping[] GetAll();

        /// <summary>
        /// Gets a UserRoleMapping collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of UserRoleMapping id</param>
        /// <returns>Array of UserRoleMapping proces</returns>
        UserRoleMapping[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a UserRoleMapping proces in database
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping</param>
        /// <returns>Updated array of UserRoleMapping proces</returns>
        UserRoleMapping[] UpdateUserRoleMappings(UserRoleMapping[] userRoleMappings);

        /// <summary>
        /// Deletes a UserRoleMapping from database.
        /// </summary>
        /// <param name="id">Guid representing UserRoleMapping id</param>
        /// <returns>Array of UserRoleMapping proces</returns>
        UserRoleMapping[] DeleteUserRoleMappings(string id);
    }
}
