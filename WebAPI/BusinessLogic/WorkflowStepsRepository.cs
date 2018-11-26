//-----------------------------------------------------------------------
// <copyright file="WorkflowStepsRepository.cs" company="SA Technology">
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
    public class WorkflowStepsRepository : IWorkflowStepsRepository
    {
        /// <summary>
        /// IWorkflowStepsDA variable
        /// </summary>
        private IWorkflowStepsDA _WorkflowStepsDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowStepsRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public WorkflowStepsRepository(IWorkflowStepsDA workflowStepsDA)
        {
            _WorkflowStepsDA = workflowStepsDA;
        }

        /// <summary>
        /// Add WorkflowSteps
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(WorkflowSteps[] workflowSteps)
        {
            await _WorkflowStepsDA.AddWorkflowStepsAsync(workflowSteps);
        }

        /// <summary>
        /// Add WorkflowSteps
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps</param>
        /// <returns>Array of WorkflowSteps</returns>
        public WorkflowSteps[] Add(WorkflowSteps[] workflowSteps)
        {
            return _WorkflowStepsDA.AddWorkflowStepss(workflowSteps);
        }

        /// <summary>
        /// Get WorkflowSteps
        /// </summary>
        /// <param name="id">WorkflowSteps id</param>
        /// <returns>WorkflowSteps</returns>
        public WorkflowSteps Get(string id)
        {
            return _WorkflowStepsDA.GetWorkflowSteps(id);
        }

        /// <summary>
        /// Get WorkflowSteps collection
        /// </summary>
        /// <param name="ids">Array of WorkflowSteps id</param>
        /// <returns>Dictionary based WorkflowSteps collection</returns>
        public Dictionary<string, WorkflowSteps> Get(string[] ids)
        {
            return _WorkflowStepsDA.GetWorkflowStepss(ids);
        }

        /// <summary>
        /// Get WorkflowSteps
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of WorkflowSteps</returns>
        public WorkflowSteps[] Get(IEnumerable<Guid?> ids)
        {
            return _WorkflowStepsDA.GetWorkflowStepss(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of WorkflowSteps</returns>
        public WorkflowSteps[] GetAll()
        {
            return _WorkflowStepsDA.GetAll();
        }

        /// <summary>
        /// Get WorkflowSteps
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of WorkflowSteps</returns>
        public WorkflowSteps[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _WorkflowStepsDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update WorkflowSteps
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps</param>
        /// <returns>Array of WorkflowSteps</returns>
        public WorkflowSteps[] Update(WorkflowSteps[] workflowSteps)
        {
            return _WorkflowStepsDA.UpdateWorkflowStepss(workflowSteps);
        }

        /// <summary>
        /// Delete WorkflowSteps
        /// </summary>
        /// <param name="id">WorkflowSteps id</param>
        /// <returns>Array of WorkflowSteps</returns>
        public WorkflowSteps[] Delete(string id)
        {
            return _WorkflowStepsDA.DeleteWorkflowStepss(id);
        }
    }
}
