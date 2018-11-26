//-----------------------------------------------------------------------
// <copyright file="IWorkflowDA.cs" company="SA Technology">
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
    /// IWorkflow interface. Used to define all abstract methods of Workflow proces.
    /// </summary>
    public interface IWorkflowDA
    {
        /// <summary>
        /// Adds Workflow proces to database asynchronously.
        /// </summary>
        /// <param name="workflows">Array of Workflow.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddWorkflowAsync(Workflow[] workflows);

        /// <summary>
        /// Adds Workflow proces to database.
        /// </summary>
        /// <param name="workflows">Array of Workflow</param>
        /// <returns>Added array of Workflow</returns>
        Workflow[] AddWorkflows(Workflow[] workflows);

        /// <summary>
        /// Gets a single Workflow based on id.
        /// </summary>
        /// <param name="id">Workflow Id</param>
        /// <returns>Workflow proces.</returns>
        Workflow GetWorkflow(string id);

        /// <summary>
        /// Gets a Workflow in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of Workflow id</param>
        /// <returns>Dictionary of Workflow proces</returns>
        Dictionary<string, Workflow> GetWorkflows(string[] ids);

        /// <summary>
        /// Gets a Workflow collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of Workflow id</param>
        /// <returns>Array of Workflow proces</returns>
        Workflow[] GetWorkflows(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all Workflows
        /// </summary>
        /// <returns>Array of Workflow proces</returns>
        Workflow[] GetAll();

        /// <summary>
        /// Gets a Workflow collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of Workflow id</param>
        /// <returns>Array of Workflow proces</returns>
        Workflow[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a Workflow proces in database
        /// </summary>
        /// <param name="workflows">Array of Workflow</param>
        /// <returns>Updated array of Workflow proces</returns>
        Workflow[] UpdateWorkflows(Workflow[] workflows);

        /// <summary>
        /// Deletes a Workflow from database.
        /// </summary>
        /// <param name="id">Guid representing Workflow id</param>
        /// <returns>Array of Workflow proces</returns>
        Workflow[] DeleteWorkflows(string id);
    }
}
