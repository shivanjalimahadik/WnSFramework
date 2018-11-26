//-----------------------------------------------------------------------
// <copyright file="WorkflowDA.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using DataAccess.Interface;
    using DataAccess.Util;
    using Entities;

    /// <summary>
    /// WorkflowDA class holds method implementation for database operations
    /// </summary>
    public class WorkflowDA : DataAccessBase<Workflow>, IWorkflowDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public WorkflowDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add Workflow to database
        /// </summary>
        /// <param name="workflows">Array of Workflow</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddWorkflowAsync(Workflow[] workflows)
        {
            await this.AddAsync(workflows);
        }

        /// <summary>
        /// Add Workflow to database
        /// </summary>
        /// <param name="workflows">Array of Workflow</param>
        /// <returns>Workflow collection</returns>
        public Workflow[] AddWorkflows(Workflow[] workflows)
        {
            return this.Add(workflows);
        }

        /// <summary>
        /// Get Workflow
        /// </summary>
        /// <param name="id">Workflow id</param>
        /// <returns>Workflow proces</returns>
        public Workflow GetWorkflow(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get Workflow
        /// </summary>
        /// <param name="ids">Workflow ids</param>
        /// <returns>Dictionary based collection of Workflows</returns>
        public Dictionary<string, Workflow> GetWorkflows(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get Workflows
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Workflow</returns>
        public Workflow[] GetWorkflows(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all Workflows
        /// </summary>
        /// <returns>Array of Workflow</returns>
        public Workflow[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        /// <summary>
        /// Get Workflows
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Workflow</returns>
        public Workflow[] GetByIds(IEnumerable<Guid> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsDeleted = 0", this.GetTableName());
            return this.FindByTempTableIds(sql, ids).ToArray();
        }

        /// <summary>
        /// Get table name
        /// </summary>
        /// <returns>Workflow table name</returns>
        public string GetWorkflowName()
        {
            return this.GetTableName();
        }

        /// <summary>
        /// Get column names
        /// </summary>
        /// <returns>Column names</returns>
        public string[] GetColumns()
        {
            PropertyInfo[] props = this.Mapping(new Workflow()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update Workflow
        /// </summary>
        /// <param name="workflows">Array of Workflow</param>
        /// <returns>Workflow collection</returns>
        public Workflow[] UpdateWorkflows(Workflow[] workflows)
        {
            if (workflows.Any())
            {
                this.Update(workflows);
            }

            return workflows;
        }

        /// <summary>
        /// Delete Workflow
        /// </summary>
        /// <param name="id">Workflow id</param>
        /// <returns>Array of Workflow</returns>
        public Workflow[] DeleteWorkflows(string id)
        {
            if (id != null)
            {
                string[] ids = { id };
                this.DeleteByDbId(ids);
            }

            return null;
        }

        /// <summary>
        /// Returns table name
        /// </summary>
        /// <returns>Table name</returns>
        internal override string GetTableName()
        {
            return TableNameConstants.Workflow;
        }

        /// <summary>
        /// Map Workflow item properties
        /// </summary>
        /// <param name="item">Workflow item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(Workflow item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.EntityID,
                item.WorkflowNumber,
                item.WorkflowDescription,

                item.UDF1,
                item.UDF2,
                item.UDF3,
                item.UDF4,
                item.UDF5,
                item.PortalID,
                item.AppID,
                item.PrimaryIPAdd,
                item.SecondaryIPAdd,
                item.AzureRegion,
                item.CreatedOn,
                item.UpdatedOn,
                item.IsActive,
                item.CreatedBy,
                item.UpdatedBy
            };
        }
    }
}
