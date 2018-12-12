//-----------------------------------------------------------------------
// <copyright file="ResourceCenterDA.cs" company="SA Technology">
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
    using Entities.Wrappers;
    using Dapper;

    /// <summary>
    /// ResourceCenterDA class holds method implementation for database operations
    /// </summary>
    public class ResourceCenterDA : DataAccessBase<ResourceCenter>, IResourceCenterDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceCenterDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public ResourceCenterDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add ResourceCenter to database
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddResourceCenterAsync(ResourceCenter[] resourceCenters)
        {
            await this.AddAsync(resourceCenters);
        }

        /// <summary>
        /// Add ResourceCenter to database
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter</param>
        /// <returns>ResourceCenter collection</returns>
        public ResourceCenter[] AddResourceCenters(ResourceCenter[] resourceCenters)
        {
            DynamicParameters parameters = new DynamicParameters();

            for (int i = 0; i < resourceCenters.Count(); i++)
            {
                parameters.Add("Id", Guid.NewGuid(), dbType: System.Data.DbType.Guid);
                parameters.Add("ResourceCenterName", resourceCenters[i].ResourceCenterName, dbType: System.Data.DbType.String);
                parameters.Add("CostCenterID", resourceCenters[i].CostCenterID, dbType: System.Data.DbType.Guid);
                parameters.Add("UDF1", resourceCenters[i].UDF1, dbType: System.Data.DbType.String);
                parameters.Add("UDF2", resourceCenters[i].UDF2, dbType: System.Data.DbType.String);
                parameters.Add("UDF3", resourceCenters[i].UDF3, dbType: System.Data.DbType.String);
                parameters.Add("UDF4", resourceCenters[i].UDF4, dbType: System.Data.DbType.String);
                parameters.Add("UDF5", resourceCenters[i].UDF5, dbType: System.Data.DbType.String);
                parameters.Add("PortalID", resourceCenters[i].PortalID, dbType: System.Data.DbType.String);
                parameters.Add("AppID", resourceCenters[i].AppID, dbType: System.Data.DbType.String);
                parameters.Add("PrimaryIPAdd", resourceCenters[i].PrimaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("SecondaryIPAdd", resourceCenters[i].SecondaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("AzureRegion", resourceCenters[i].AzureRegion, dbType: System.Data.DbType.String);
                parameters.Add("CreatedOn", resourceCenters[i].CreatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("CreatedBy", resourceCenters[i].CreatedBy, dbType: System.Data.DbType.String);
                parameters.Add("UpdatedOn", resourceCenters[i].UpdatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("UpdatedBy", resourceCenters[i].UpdatedBy, dbType: System.Data.DbType.String);
                parameters.Add("IsActive", resourceCenters[i].IsActive, dbType: System.Data.DbType.Boolean);
            }

            this.ExecuteStoredProcedure("InsertResourceCenter", parameters);

            return null;
        }

        /// <summary>
        /// Get ResourceCenter
        /// </summary>
        /// <param name="id">ResourceCenter id</param>
        /// <returns>ResourceCenter proces</returns>
        public ResourceCenter GetResourceCenter(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get ResourceCenter
        /// </summary>
        /// <param name="ids">ResourceCenter ids</param>
        /// <returns>Dictionary based collection of ResourceCenters</returns>
        public Dictionary<string, ResourceCenter> GetResourceCenters(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get ResourceCenters
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of ResourceCenter</returns>
        public ResourceCenter[] GetResourceCenters(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all ResourceCenters
        /// </summary>
        /// <returns>Array of ResourceCenter</returns>
        public ResourceCenter[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        public ResourceCenterWrapper[] GetAllResourceCenters()
        {
            List<ResourceCenterWrapper> rcWrapper = new List<ResourceCenterWrapper>();
            var sql = string.Format("SELECT RC.Id, RC.ResourceCenterName, CC.CostCenterName FROM {0} RC INNER JOIN {1} CC ON " +
                " RC.CostCenterID = CC.Id WHERE RC.IsActive = 1 AND CC.IsActive = 1 ", GetTableName(), TableNameConstants.CostCenter);

            var dynamicRC = base.FindDynamic(sql, new { });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(ResourceCenterWrapper), new List<string> { "Id" });
            rcWrapper = (Slapper.AutoMapper.MapDynamic<ResourceCenterWrapper>(dynamicRC) as IEnumerable<ResourceCenterWrapper>).ToList();

            return rcWrapper.ToArray();
        }

        /// <summary>
        /// Get ResourceCenters
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of ResourceCenter</returns>
        public ResourceCenter[] GetByIds(IEnumerable<Guid> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsDeleted = 0", this.GetTableName());
            return this.FindByTempTableIds(sql, ids).ToArray();
        }

        /// <summary>
        /// Get table name
        /// </summary>
        /// <returns>ResourceCenter table name</returns>
        public string GetResourceCenterName()
        {
            return this.GetTableName();
        }

        /// <summary>
        /// Get column names
        /// </summary>
        /// <returns>Column names</returns>
        public string[] GetColumns()
        {
            PropertyInfo[] props = this.Mapping(new ResourceCenter()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update ResourceCenter
        /// </summary>
        /// <param name="resourceCenters">Array of ResourceCenter</param>
        /// <returns>ResourceCenter collection</returns>
        public ResourceCenter[] UpdateResourceCenters(ResourceCenter[] resourceCenters)
        {
            if (resourceCenters.Any())
            {
                DynamicParameters parameters = new DynamicParameters();

                for (int i = 0; i < resourceCenters.Count(); i++)
                {
                    parameters.Add("Id", resourceCenters[i].Id, dbType: System.Data.DbType.Guid);
                    parameters.Add("ResourceCenterName", resourceCenters[i].ResourceCenterName, dbType: System.Data.DbType.String);
                    parameters.Add("CostCenterID", resourceCenters[i].CostCenterID, dbType: System.Data.DbType.Guid);
                }
                this.ExecuteStoredProcedure("UpdateResourceCenter", parameters);
            }

            return resourceCenters;
        }

        /// <summary>
        /// Delete ResourceCenter
        /// </summary>
        /// <param name="id">ResourceCenter id</param>
        /// <returns>Array of ResourceCenter</returns>
        public ResourceCenter[] DeleteResourceCenters(string id)
        {
            if (id != null)
            {
                //string[] ids = { id };
                //this.DeleteByDbId(ids);
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", new Guid(id), dbType: System.Data.DbType.Guid);

                this.ExecuteStoredProcedure("DeleteResourceCenter", parameters);
            }

            return null;
        }

        /// <summary>
        /// Returns table name
        /// </summary>
        /// <returns>Table name</returns>
        internal override string GetTableName()
        {
            return TableNameConstants.ResourceCenter;
        }

        /// <summary>
        /// Map ResourceCenter item properties
        /// </summary>
        /// <param name="item">ResourceCenter item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(ResourceCenter item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.ResourceCenterName,
                item.CostCenterID,

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
