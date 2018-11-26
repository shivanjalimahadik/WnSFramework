//-----------------------------------------------------------------------
// <copyright file="IWorkflowStepsRepository.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BusinessLogic.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    /// <summary>
    /// WorkflowSteps interface 
    /// </summary>
    public interface IWorkflowStepsRepository
    {
        /// <summary>
        /// Add WorkflowSteps
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps</param>
        /// <returns></returns>
        Task AddAsync(WorkflowSteps[] workflowSteps);

        /// <summary>
        /// Add WorkflowSteps
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps</param>
        /// <returns>Array of WorkflowSteps</returns>
        WorkflowSteps[] Add(WorkflowSteps[] workflowSteps);

        /// <summary>
        /// Get WorkflowSteps
        /// </summary>
        /// <param name="id">WorkflowSteps id</param>
        /// <returns>WorkflowSteps proces</returns>
        WorkflowSteps Get(string id);

        /// <summary>
        /// Get WorkflowSteps collection
        /// </summary>
        /// <param name="ids">Array of WorkflowSteps id</param>
        /// <returns>Dictionary based WorkflowSteps collection</returns>
        Dictionary<string, WorkflowSteps> Get(string[] ids);

        /// <summary>
        /// Get WorkflowSteps
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of WorkflowSteps</returns>
        WorkflowSteps[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of WorkflowSteps</returns>
        WorkflowSteps[] GetAll();

        /// <summary>
        /// Get WorkflowSteps
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of WorkflowSteps</returns>
        WorkflowSteps[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update WorkflowSteps
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps</param>
        /// <returns>Array of WorkflowSteps</returns>
        WorkflowSteps[] Update(WorkflowSteps[] workflowSteps);

        /// <summary>
        /// Delete WorkflowSteps
        /// </summary>
        /// <param name="id">WorkflowSteps id</param>
        /// <returns>Array of WorkflowSteps</returns>
        WorkflowSteps[] Delete(string id);
    }
}
