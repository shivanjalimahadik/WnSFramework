//-----------------------------------------------------------------------
// <copyright file="IRolesDA.cs" company="SA Technology">
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
    /// IRoles interface. Used to define all abstract methods of Roles proces.
    /// </summary>
    public interface IRolesDA
    {
        /// <summary>
        /// Adds Roles proces to database asynchronously.
        /// </summary>
        /// <param name="roles">Array of Roles.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddRolesAsync(Roles[] roles);

        /// <summary>
        /// Adds Roles proces to database.
        /// </summary>
        /// <param name="roles">Array of Roles</param>
        /// <returns>Added array of Roles</returns>
        Roles[] AddRoless(Roles[] roles);

        /// <summary>
        /// Gets a single Roles based on id.
        /// </summary>
        /// <param name="id">Roles Id</param>
        /// <returns>Roles proces.</returns>
        Roles GetRoles(string id);

        /// <summary>
        /// Gets a Roles in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of Roles id</param>
        /// <returns>Dictionary of Roles proces</returns>
        Dictionary<string, Roles> GetRoless(string[] ids);

        /// <summary>
        /// Gets a Roles collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of Roles id</param>
        /// <returns>Array of Roles proces</returns>
        Roles[] GetRoless(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all Roless
        /// </summary>
        /// <returns>Array of Roles proces</returns>
        Roles[] GetAll();

        /// <summary>
        /// Gets a Roles collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of Roles id</param>
        /// <returns>Array of Roles proces</returns>
        Roles[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a Roles proces in database
        /// </summary>
        /// <param name="roles">Array of Roles</param>
        /// <returns>Updated array of Roles proces</returns>
        Roles[] UpdateRoless(Roles[] roles);

        /// <summary>
        /// Deletes a Roles from database.
        /// </summary>
        /// <param name="id">Guid representing Roles id</param>
        /// <returns>Array of Roles proces</returns>
        Roles[] DeleteRoless(string id);
    }
}
