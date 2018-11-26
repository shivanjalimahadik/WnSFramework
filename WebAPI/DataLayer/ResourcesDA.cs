//-----------------------------------------------------------------------
// <copyright file="ResourcesDA.cs" company="SA Technology">
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
    /// ResourcesDA class holds method implementation for database operations
    /// </summary>
    public class ResourcesDA : DataAccessBase<Resources>, IResourcesDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public ResourcesDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add Resources to database
        /// </summary>
        /// <param name="resources">Array of Resources</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddResourcesAsync(Resources[] resources)
        {
            await this.AddAsync(resources);
        }

        /// <summary>
        /// Add Resources to database
        /// </summary>
        /// <param name="resources">Array of Resources</param>
        /// <returns>Resources collection</returns>
        public Resources[] AddResourcess(Resources[] resources)
        {
            return this.Add(resources);
        }

        /// <summary>
        /// Get Resources
        /// </summary>
        /// <param name="id">Resources id</param>
        /// <returns>Resources proces</returns>
        public Resources GetResources(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get Resources
        /// </summary>
        /// <param name="ids">Resources ids</param>
        /// <returns>Dictionary based collection of Resourcess</returns>
        public Dictionary<string, Resources> GetResourcess(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get Resourcess
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Resources</returns>
        public Resources[] GetResourcess(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all Resourcess
        /// </summary>
        /// <returns>Array of Resources</returns>
        public Resources[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        /// <summary>
        /// Get Resourcess
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Resources</returns>
        public Resources[] GetByIds(IEnumerable<Guid> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsDeleted = 0", this.GetTableName());
            return this.FindByTempTableIds(sql, ids).ToArray();
        }

        /// <summary>
        /// Get table name
        /// </summary>
        /// <returns>Resources table name</returns>
        public string GetResourcesName()
        {
            return this.GetTableName();
        }

        /// <summary>
        /// Get column names
        /// </summary>
        /// <returns>Column names</returns>
        public string[] GetColumns()
        {
            PropertyInfo[] props = this.Mapping(new Resources()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update Resources
        /// </summary>
        /// <param name="resources">Array of Resources</param>
        /// <returns>Resources collection</returns>
        public Resources[] UpdateResourcess(Resources[] resources)
        {
            if (resources.Any())
            {
                this.Update(resources);
            }

            return resources;
        }

        /// <summary>
        /// Delete Resources
        /// </summary>
        /// <param name="id">Resources id</param>
        /// <returns>Array of Resources</returns>
        public Resources[] DeleteResourcess(string id)
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
            return TableNameConstants.Resources;
        }

        /// <summary>
        /// Map Resources item properties
        /// </summary>
        /// <param name="item">Resources item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(Resources item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.ResourceName,
                item.ResourceCenterID,

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
