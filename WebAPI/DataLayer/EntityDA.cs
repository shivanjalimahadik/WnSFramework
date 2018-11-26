//-----------------------------------------------------------------------
// <copyright file="EntityDA.cs" company="SA Technology">
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
    /// EntityDA class holds method implementation for database operations
    /// </summary>
    public class EntityDA : DataAccessBase<Entity>, IEntityDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public EntityDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add Entity to database
        /// </summary>
        /// <param name="entitys">Array of Entity</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddEntityAsync(Entity[] entitys)
        {
            await this.AddAsync(entitys);
        }

        /// <summary>
        /// Add Entity to database
        /// </summary>
        /// <param name="entitys">Array of Entity</param>
        /// <returns>Entity collection</returns>
        public Entity[] AddEntitys(Entity[] entitys)
        {
            return this.Add(entitys);
        }

        /// <summary>
        /// Get Entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity entity</returns>
        public Entity GetEntity(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get Entity
        /// </summary>
        /// <param name="ids">Entity ids</param>
        /// <returns>Dictionary based collection of Entitys</returns>
        public Dictionary<string, Entity> GetEntitys(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get Entitys
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Entity</returns>
        public Entity[] GetEntitys(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all Entitys
        /// </summary>
        /// <returns>Array of Entity</returns>
        public Entity[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        /// <summary>
        /// Get Entitys
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Entity</returns>
        public Entity[] GetByIds(IEnumerable<Guid> ids)
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
            PropertyInfo[] props = this.Mapping(new Entity()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entitys">Array of Entity</param>
        /// <returns>Entity collection</returns>
        public Entity[] UpdateEntitys(Entity[] entitys)
        {
            if (entitys.Any())
            {
                this.Update(entitys);
            }

            return entitys;
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Array of Entity</returns>
        public Entity[] DeleteEntitys(string id)
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
            return TableNameConstants.Entity;
        }

        /// <summary>
        /// Map Entity item properties
        /// </summary>
        /// <param name="item">Entity item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(Entity item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.EntityName,


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
