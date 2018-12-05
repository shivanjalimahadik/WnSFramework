//-----------------------------------------------------------------------
// <copyright file="IProcessDA.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    using Entities.Wrappers;

    /// <summary>
    /// IProcess interface. Used to define all abstract methods of Process proces.
    /// </summary>
    public interface IProcessDA
    {
        /// <summary>
        /// Adds Process proces to database asynchronously.
        /// </summary>
        /// <param name="process">Array of Process.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddProcessAsync(Process[] process);

        /// <summary>
        /// Adds Process proces to database.
        /// </summary>
        /// <param name="process">Array of Process</param>
        /// <returns>Added array of Process</returns>
        Process[] AddProcesss(Process[] process);

        /// <summary>
        /// Gets a single Process based on id.
        /// </summary>
        /// <param name="id">Process Id</param>
        /// <returns>Process proces.</returns>
        Process GetProcess(string id);

        /// <summary>
        /// Gets a Process in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of Process id</param>
        /// <returns>Dictionary of Process proces</returns>
        Dictionary<string, Process> GetProcesss(string[] ids);

        /// <summary>
        /// Gets a Process collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of Process id</param>
        /// <returns>Array of Process proces</returns>
        Process[] GetProcesss(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all Processs
        /// </summary>
        /// <returns>Array of Process proces</returns>
        Process[] GetAll();

        /// <summary>
        /// Gets a Process collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of Process id</param>
        /// <returns>Array of Process proces</returns>
        Process[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a Process proces in database
        /// </summary>
        /// <param name="process">Array of Process</param>
        /// <returns>Updated array of Process proces</returns>
        Process[] UpdateProcesss(Process[] process);

        /// <summary>
        /// Deletes a Process from database.
        /// </summary>
        /// <param name="id">Guid representing Process id</param>
        /// <returns>Array of Process proces</returns>
        Process[] DeleteProcesss(string id);

        /// <summary>
        /// Get all Process
        /// </summary>
        /// <returns></returns>
        ProcessWrapper[] GetAllProcess();
    }
}
