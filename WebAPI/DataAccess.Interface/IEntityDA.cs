//-----------------------------------------------------------------------
// <copyright file="IEntityDA.cs" company="SA Technology">
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
    /// IEntity interface. Used to define all abstract methods of Entity entity.
    /// </summary>
    public interface IEntityDA
    {
        /// <summary>
        /// Adds Entity entity to database asynchronously.
        /// </summary>
        /// <param name="entitys">Array of Entity.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddEntityAsync(Entity[] entitys);

        /// <summary>
        /// Adds Entity entity to database.
        /// </summary>
        /// <param name="entitys">Array of Entity</param>
        /// <returns>Added array of Entity</returns>
        Entity[] AddEntitys(Entity[] entitys);

        /// <summary>
        /// Gets a single Entity based on id.
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <returns>Entity entity.</returns>
        Entity GetEntity(string id);

        /// <summary>
        /// Gets a Entity in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of Entity id</param>
        /// <returns>Dictionary of Entity entity</returns>
        Dictionary<string, Entity> GetEntitys(string[] ids);

        /// <summary>
        /// Gets a Entity collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of Entity id</param>
        /// <returns>Array of Entity entity</returns>
        Entity[] GetEntitys(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all Entitys
        /// </summary>
        /// <returns>Array of Entity entity</returns>
        Entity[] GetAll();

        /// <summary>
        /// Gets a Entity collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of Entity id</param>
        /// <returns>Array of Entity entity</returns>
        Entity[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a Entity entity in database
        /// </summary>
        /// <param name="entitys">Array of Entity</param>
        /// <returns>Updated array of Entity entity</returns>
        Entity[] UpdateEntitys(Entity[] entitys);

        /// <summary>
        /// Deletes a Entity from database.
        /// </summary>
        /// <param name="id">Guid representing Entity id</param>
        /// <returns>Array of Entity entity</returns>
        Entity[] DeleteEntitys(string id);
    }
}
