//-----------------------------------------------------------------------
// <copyright file="WorkflowStepsDA.cs" company="SA Technology">
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
    /// WorkflowStepsDA class holds method implementation for database operations
    /// </summary>
    public class WorkflowStepsDA : DataAccessBase<WorkflowSteps>, IWorkflowStepsDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowStepsDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public WorkflowStepsDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add WorkflowSteps to database
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddWorkflowStepsAsync(WorkflowSteps[] workflowSteps)
        {
            await this.AddAsync(workflowSteps);
        }

        /// <summary>
        /// Add WorkflowSteps to database
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps</param>
        /// <returns>WorkflowSteps collection</returns>
        public WorkflowSteps[] AddWorkflowStepss(WorkflowSteps[] workflowSteps)
        {
            return this.Add(workflowSteps);
        }

        /// <summary>
        /// Get WorkflowSteps
        /// </summary>
        /// <param name="id">WorkflowSteps id</param>
        /// <returns>WorkflowSteps proces</returns>
        public WorkflowSteps GetWorkflowSteps(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get WorkflowSteps
        /// </summary>
        /// <param name="ids">WorkflowSteps ids</param>
        /// <returns>Dictionary based collection of WorkflowStepss</returns>
        public Dictionary<string, WorkflowSteps> GetWorkflowStepss(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get WorkflowStepss
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of WorkflowSteps</returns>
        public WorkflowSteps[] GetWorkflowStepss(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all WorkflowStepss
        /// </summary>
        /// <returns>Array of WorkflowSteps</returns>
        public WorkflowSteps[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        /// <summary>
        /// Get WorkflowStepss
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of WorkflowSteps</returns>
        public WorkflowSteps[] GetByIds(IEnumerable<Guid> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsDeleted = 0", this.GetTableName());
            return this.FindByTempTableIds(sql, ids).ToArray();
        }

        /// <summary>
        /// Get table name
        /// </summary>
        /// <returns>WorkflowSteps table name</returns>
        public string GetWorkflowStepsName()
        {
            return this.GetTableName();
        }

        /// <summary>
        /// Get column names
        /// </summary>
        /// <returns>Column names</returns>
        public string[] GetColumns()
        {
            PropertyInfo[] props = this.Mapping(new WorkflowSteps()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update WorkflowSteps
        /// </summary>
        /// <param name="workflowSteps">Array of WorkflowSteps</param>
        /// <returns>WorkflowSteps collection</returns>
        public WorkflowSteps[] UpdateWorkflowStepss(WorkflowSteps[] workflowSteps)
        {
            if (workflowSteps.Any())
            {
                this.Update(workflowSteps);
            }

            return workflowSteps;
        }

        /// <summary>
        /// Delete WorkflowSteps
        /// </summary>
        /// <param name="id">WorkflowSteps id</param>
        /// <returns>Array of WorkflowSteps</returns>
        public WorkflowSteps[] DeleteWorkflowStepss(string id)
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
            return TableNameConstants.WorkflowSteps;
        }

        /// <summary>
        /// Map WorkflowSteps item properties
        /// </summary>
        /// <param name="item">WorkflowSteps item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(WorkflowSteps item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.StepNumber,
                item.UserID,
                item.RoleID,
                item.WorkflowBusinessRuleID,

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
