//-----------------------------------------------------------------------
// <copyright file="WorkflowRepository.cs" company="SA Technology">
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
    public class WorkflowRepository : IWorkflowRepository
    {
        /// <summary>
        /// IWorkflowDA variable
        /// </summary>
        private IWorkflowDA _WorkflowDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public WorkflowRepository(IWorkflowDA workflowsDA)
        {
            _WorkflowDA = workflowsDA;
        }

        /// <summary>
        /// Add Workflow
        /// </summary>
        /// <param name="workflows">Array of Workflow</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(Workflow[] workflows)
        {
            await _WorkflowDA.AddWorkflowAsync(workflows);
        }

        /// <summary>
        /// Add Workflow
        /// </summary>
        /// <param name="workflows">Array of Workflow</param>
        /// <returns>Array of Workflow</returns>
        public Workflow[] Add(Workflow[] workflows)
        {
            return _WorkflowDA.AddWorkflows(workflows);
        }

        /// <summary>
        /// Get Workflow
        /// </summary>
        /// <param name="id">Workflow id</param>
        /// <returns>Workflow</returns>
        public Workflow Get(string id)
        {
            return _WorkflowDA.GetWorkflow(id);
        }

        /// <summary>
        /// Get Workflow collection
        /// </summary>
        /// <param name="ids">Array of Workflow id</param>
        /// <returns>Dictionary based Workflow collection</returns>
        public Dictionary<string, Workflow> Get(string[] ids)
        {
            return _WorkflowDA.GetWorkflows(ids);
        }

        /// <summary>
        /// Get Workflow
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Workflow</returns>
        public Workflow[] Get(IEnumerable<Guid?> ids)
        {
            return _WorkflowDA.GetWorkflows(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of Workflow</returns>
        public Workflow[] GetAll()
        {
            return _WorkflowDA.GetAll();
        }

        /// <summary>
        /// Get Workflow
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Workflow</returns>
        public Workflow[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _WorkflowDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update Workflow
        /// </summary>
        /// <param name="workflows">Array of Workflow</param>
        /// <returns>Array of Workflow</returns>
        public Workflow[] Update(Workflow[] workflows)
        {
            return _WorkflowDA.UpdateWorkflows(workflows);
        }

        /// <summary>
        /// Delete Workflow
        /// </summary>
        /// <param name="id">Workflow id</param>
        /// <returns>Array of Workflow</returns>
        public Workflow[] Delete(string id)
        {
            return _WorkflowDA.DeleteWorkflows(id);
        }
    }
}
