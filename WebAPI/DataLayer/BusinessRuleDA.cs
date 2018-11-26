//-----------------------------------------------------------------------
// <copyright file="BusinessRuleDA.cs" company="SA Technology">
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
    /// BusinessRuleDA class holds method implementation for database operations
    /// </summary>
    public class BusinessRuleDA : DataAccessBase<BusinessRule>, IBusinessRuleDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRuleDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public BusinessRuleDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add BusinessRule to database
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddBusinessRuleAsync(BusinessRule[] businessRules)
        {
            await this.AddAsync(businessRules);
        }

        /// <summary>
        /// Add BusinessRule to database
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule</param>
        /// <returns>BusinessRule collection</returns>
        public BusinessRule[] AddBusinessRules(BusinessRule[] businessRules)
        {
            return this.Add(businessRules);
        }

        /// <summary>
        /// Get BusinessRule
        /// </summary>
        /// <param name="id">BusinessRule id</param>
        /// <returns>BusinessRule entity</returns>
        public BusinessRule GetBusinessRule(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get BusinessRule
        /// </summary>
        /// <param name="ids">BusinessRule ids</param>
        /// <returns>Dictionary based collection of BusinessRules</returns>
        public Dictionary<string, BusinessRule> GetBusinessRules(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get BusinessRules
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of BusinessRule</returns>
        public BusinessRule[] GetBusinessRules(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all BusinessRules
        /// </summary>
        /// <returns>Array of BusinessRule</returns>
        public BusinessRule[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        /// <summary>
        /// Get BusinessRules
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of BusinessRule</returns>
        public BusinessRule[] GetByIds(IEnumerable<Guid> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsDeleted = 0", this.GetTableName());
            return this.FindByTempTableIds(sql, ids).ToArray();
        }

        /// <summary>
        /// Get table name
        /// </summary>
        /// <returns>Entity table name</returns>
        public string GetEntityName()
        {
            return this.GetTableName();
        }

        /// <summary>
        /// Get column names
        /// </summary>
        /// <returns>Column names</returns>
        public string[] GetColumns()
        {
            PropertyInfo[] props = this.Mapping(new BusinessRule()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update BusinessRule
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule</param>
        /// <returns>BusinessRule collection</returns>
        public BusinessRule[] UpdateBusinessRules(BusinessRule[] businessRules)
        {
            if (businessRules.Any())
            {
                this.Update(businessRules);
            }

            return businessRules;
        }

        /// <summary>
        /// Delete BusinessRule
        /// </summary>
        /// <param name="id">BusinessRule id</param>
        /// <returns>Array of BusinessRule</returns>
        public BusinessRule[] DeleteBusinessRules(string id)
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
            return TableNameConstants.BusinessRule;
        }

        /// <summary>
        /// Map BusinessRule item properties
        /// </summary>
        /// <param name="item">BusinessRule item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(BusinessRule item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.TableName,
                item.SelectedField,
                item.Operator,
                item.Value,
                item.IsEscalation,
                item.ActionDateFrom,
                item.ActionDateTo,
                item.IsApproved,
                item.EscalateTo,
                item.EscalateOperator,
                item.EscalateValue,
                item.ActionPoint,
                item.ForwardTo,

                item.UDF1,
                item.UDF2,
                item.UDF3,
                item.UDF4,
                item.UDF5,
                item.PortalID,
                item.OrganizationUnitID,
                item.BusinessUnitID,
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
