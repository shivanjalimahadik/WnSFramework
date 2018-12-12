//-----------------------------------------------------------------------
// <copyright file="CostCenterDA.cs" company="SA Technology">
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
    using Dapper;

    /// <summary>
    /// CostCenterDA class holds method implementation for database operations
    /// </summary>
    public class CostCenterDA : DataAccessBase<CostCenter>, ICostCenterDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CostCenterDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public CostCenterDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add CostCenter to database
        /// </summary>
        /// <param name="costCenters">Array of CostCenter</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddCostCenterAsync(CostCenter[] costCenters)
        {
            await this.AddAsync(costCenters);
        }

        /// <summary>
        /// Add CostCenter to database
        /// </summary>
        /// <param name="costCenters">Array of CostCenter</param>
        /// <returns>CostCenter collection</returns>
        public CostCenter[] AddCostCenters(CostCenter[] costCenters)
        {
            DynamicParameters parameters = new DynamicParameters();

            for (int i = 0; i < costCenters.Count(); i++)
            {
                parameters.Add("Id", Guid.NewGuid(), dbType: System.Data.DbType.Guid);
                parameters.Add("CostCenterName", costCenters[i].CostCenterName, dbType: System.Data.DbType.String);
                parameters.Add("OrganizationUnitID", costCenters[i].OrganizationUnitID, dbType: System.Data.DbType.Guid);
                parameters.Add("UDF1", costCenters[i].UDF1, dbType: System.Data.DbType.String);
                parameters.Add("UDF2", costCenters[i].UDF2, dbType: System.Data.DbType.String);
                parameters.Add("UDF3", costCenters[i].UDF3, dbType: System.Data.DbType.String);
                parameters.Add("UDF4", costCenters[i].UDF4, dbType: System.Data.DbType.String);
                parameters.Add("UDF5", costCenters[i].UDF5, dbType: System.Data.DbType.String);
                parameters.Add("PortalID", costCenters[i].PortalID, dbType: System.Data.DbType.String);
                parameters.Add("AppID", costCenters[i].AppID, dbType: System.Data.DbType.String);
                parameters.Add("PrimaryIPAdd", costCenters[i].PrimaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("SecondaryIPAdd", costCenters[i].SecondaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("AzureRegion", costCenters[i].AzureRegion, dbType: System.Data.DbType.String);
                parameters.Add("CreatedOn", costCenters[i].CreatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("CreatedBy", costCenters[i].CreatedBy, dbType: System.Data.DbType.String);
                parameters.Add("UpdatedOn", costCenters[i].UpdatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("UpdatedBy", costCenters[i].UpdatedBy, dbType: System.Data.DbType.String);
                parameters.Add("IsActive", costCenters[i].IsActive, dbType: System.Data.DbType.Boolean);
            }

            this.ExecuteStoredProcedure("InsertCostCenter", parameters);

            return costCenters;
        }

        /// <summary>
        /// Get CostCenter
        /// </summary>
        /// <param name="id">CostCenter id</param>
        /// <returns>CostCenter entity</returns>
        public CostCenter GetCostCenter(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get CostCenter
        /// </summary>
        /// <param name="ids">CostCenter ids</param>
        /// <returns>Dictionary based collection of CostCenters</returns>
        public Dictionary<string, CostCenter> GetCostCenters(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get CostCenters
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of CostCenter</returns>
        public CostCenter[] GetCostCenters(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all CostCenters
        /// </summary>
        /// <returns>Array of CostCenter</returns>
        public CostCenter[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        /// <summary>
        /// Get CostCenters
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of CostCenter</returns>
        public CostCenter[] GetByIds(IEnumerable<Guid> ids)
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
            PropertyInfo[] props = this.Mapping(new CostCenter()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update CostCenter
        /// </summary>
        /// <param name="costCenters">Array of CostCenter</param>
        /// <returns>CostCenter collection</returns>
        public CostCenter[] UpdateCostCenters(CostCenter[] costCenters)
        {
            if (costCenters.Any())
            {
                //this.Update(costCenters);
                DynamicParameters parameters = new DynamicParameters();

                for (int i = 0; i < costCenters.Count(); i++)
                {
                    parameters.Add("Id", costCenters[i].Id, dbType: System.Data.DbType.Guid);
                    parameters.Add("CostCenterName", costCenters[i].CostCenterName, dbType: System.Data.DbType.String);
                }
                this.ExecuteStoredProcedure("UpdateCostCenter", parameters);
            }
            return costCenters;
        }

        /// <summary>
        /// Delete CostCenter
        /// </summary>
        /// <param name="id">CostCenter id</param>
        /// <returns>Array of CostCenter</returns>
        public CostCenter[] DeleteCostCenters(string id)
        {
            if (id != null)
            {
                //string[] ids = { id };
                //this.DeleteByDbId(ids);
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", new Guid(id), dbType: System.Data.DbType.Guid);

                this.ExecuteStoredProcedure("DeleteCostCenter", parameters);
            }
            return null;
        }

        /// <summary>
        /// Returns table name
        /// </summary>
        /// <returns>Table name</returns>
        internal override string GetTableName()
        {
            return TableNameConstants.CostCenter;
        }

        /// <summary>
        /// Map CostCenter item properties
        /// </summary>
        /// <param name="item">CostCenter item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(CostCenter item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.CostCenterName,


                item.UDF1,
                item.UDF2,
                item.UDF3,
                item.UDF4,
                item.UDF5,
                item.PortalID,
                item.OrganizationUnitID,
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
