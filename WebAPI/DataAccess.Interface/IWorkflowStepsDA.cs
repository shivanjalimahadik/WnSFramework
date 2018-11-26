//-----------------------------------------------------------------------
// <copyright file="IWorkflowStepsDA.cs" company="SA Technology">
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
    /// IWorkflowSteps interface. Used to define all abstract methods of WorkflowSteps proces.
    /// </summary>
    public interface IWorkflowStepsDA
    {
        /// <summary>
        /// Adds WorkflowSteps proces to database asynchronously.
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddWorkflowStepsAsync(WorkflowSteps[] workflowSteps);

        /// <summary>
        /// Adds WorkflowSteps proces to database.
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps</param>
        /// <returns>Added array of WorkflowSteps</returns>
        WorkflowSteps[] AddWorkflowStepss(WorkflowSteps[] workflowSteps);

        /// <summary>
        /// Gets a single WorkflowSteps based on id.
        /// </summary>
        /// <param name="id">WorkflowSteps Id</param>
        /// <returns>WorkflowSteps proces.</returns>
        WorkflowSteps GetWorkflowSteps(string id);

        /// <summary>
        /// Gets a WorkflowSteps in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of WorkflowSteps id</param>
        /// <returns>Dictionary of WorkflowSteps proces</returns>
        Dictionary<string, WorkflowSteps> GetWorkflowStepss(string[] ids);

        /// <summary>
        /// Gets a WorkflowSteps collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of WorkflowSteps id</param>
        /// <returns>Array of WorkflowSteps proces</returns>
        WorkflowSteps[] GetWorkflowStepss(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all WorkflowStepss
        /// </summary>
        /// <returns>Array of WorkflowSteps proces</returns>
        WorkflowSteps[] GetAll();

        /// <summary>
        /// Gets a WorkflowSteps collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of WorkflowSteps id</param>
        /// <returns>Array of WorkflowSteps proces</returns>
        WorkflowSteps[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a WorkflowSteps proces in database
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps</param>
        /// <returns>Updated array of WorkflowSteps proces</returns>
        WorkflowSteps[] UpdateWorkflowStepss(WorkflowSteps[] workflowSteps);

        /// <summary>
        /// Deletes a WorkflowSteps from database.
        /// </summary>
        /// <param name="id">Guid representing WorkflowSteps id</param>
        /// <returns>Array of WorkflowSteps proces</returns>
        WorkflowSteps[] DeleteWorkflowStepss(string id);
    }
}
