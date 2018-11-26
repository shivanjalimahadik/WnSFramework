//-----------------------------------------------------------------------
// <copyright file="BusinessUnitDA.cs" company="SA Technology">
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
    /// BusinessUnitDA class holds method implementation for database operations
    /// </summary>
    public class BusinessUnitDA : DataAccessBase<BusinessUnit>, IBusinessUnitDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public BusinessUnitDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add BusinessUnit to database
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddBusinessUnitAsync(BusinessUnit[] businessUnits)
        {
            await this.AddAsync(businessUnits);
        }

        /// <summary>
        /// Add BusinessUnit to database
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit</param>
        /// <returns>BusinessUnit collection</returns>
        public BusinessUnit[] AddBusinessUnits(BusinessUnit[] businessUnits)
        {
            return this.Add(businessUnits);
        }

        /// <summary>
        /// Get BusinessUnit
        /// </summary>
        /// <param name="id">BusinessUnit id</param>
        /// <returns>BusinessUnit entity</returns>
        public BusinessUnit GetBusinessUnit(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get BusinessUnit
        /// </summary>
        /// <param name="ids">BusinessUnit ids</param>
        /// <returns>Dictionary based collection of BusinessUnits</returns>
        public Dictionary<string, BusinessUnit> GetBusinessUnits(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get BusinessUnits
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of BusinessUnit</returns>
        public BusinessUnit[] GetBusinessUnits(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all BusinessUnits
        /// </summary>
        /// <returns>Array of BusinessUnit</returns>
        public BusinessUnit[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        /// <summary>
        /// Get BusinessUnits
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of BusinessUnit</returns>
        public BusinessUnit[] GetByIds(IEnumerable<Guid> ids)
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
            PropertyInfo[] props = this.Mapping(new BusinessUnit()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update BusinessUnit
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit</param>
        /// <returns>BusinessUnit collection</returns>
        public BusinessUnit[] UpdateBusinessUnits(BusinessUnit[] businessUnits)
        {
            if (businessUnits.Any())
            {
                this.Update(businessUnits);
            }

            return businessUnits;
        }

        /// <summary>
        /// Delete BusinessUnit
        /// </summary>
        /// <param name="id">BusinessUnit id</param>
        /// <returns>Array of BusinessUnit</returns>
        public BusinessUnit[] DeleteBusinessUnits(string id)
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
            return TableNameConstants.BusinessUnit;
        }

        /// <summary>
        /// Map BusinessUnit item properties
        /// </summary>
        /// <param name="item">BusinessUnit item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(BusinessUnit item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.BusinessUnitName,
                item.BusinessUnitDescription,

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
