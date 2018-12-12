//-----------------------------------------------------------------------
// <copyright file="RolesDA.cs" company="SA Technology">
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
    /// RolesDA class holds method implementation for database operations
    /// </summary>
    public class RolesDA : DataAccessBase<Roles>, IRolesDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolesDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public RolesDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add Roles to database
        /// </summary>
        /// <param name="roles">Array of Roles</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddRolesAsync(Roles[] roles)
        {
            await this.AddAsync(roles);
        }

        /// <summary>
        /// Add Roles to database
        /// </summary>
        /// <param name="roles">Array of Roles</param>
        /// <returns>Roles collection</returns>
        public Roles[] AddRoless(Roles[] roles)
        {
            DynamicParameters parameters = new DynamicParameters();

            for (int i = 0; i < roles.Count(); i++)
            {
                parameters.Add("Id", Guid.NewGuid(), dbType: System.Data.DbType.Guid);
                parameters.Add("RoleName", roles[i].RoleName, dbType: System.Data.DbType.String);
                parameters.Add("UDF1", roles[i].UDF1, dbType: System.Data.DbType.String);
                parameters.Add("UDF2", roles[i].UDF2, dbType: System.Data.DbType.String);
                parameters.Add("UDF3", roles[i].UDF3, dbType: System.Data.DbType.String);
                parameters.Add("UDF4", roles[i].UDF4, dbType: System.Data.DbType.String);
                parameters.Add("UDF5", roles[i].UDF5, dbType: System.Data.DbType.String);
                parameters.Add("PortalID", roles[i].PortalID, dbType: System.Data.DbType.String);
                parameters.Add("OrganizationUnitID", roles[i].OrganizationUnitID, dbType: System.Data.DbType.Guid);
                parameters.Add("BusinessUnitID", roles[i].BusinessUnitID, dbType: System.Data.DbType.Guid);
                parameters.Add("AppID", roles[i].AppID, dbType: System.Data.DbType.String);
                parameters.Add("PrimaryIPAdd", roles[i].PrimaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("SecondaryIPAdd", roles[i].SecondaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("AzureRegion", roles[i].AzureRegion, dbType: System.Data.DbType.String);
                parameters.Add("CreatedOn", roles[i].CreatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("CreatedBy", roles[i].CreatedBy, dbType: System.Data.DbType.String);
                parameters.Add("UpdatedOn", roles[i].UpdatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("UpdatedBy", roles[i].UpdatedBy, dbType: System.Data.DbType.String);
                parameters.Add("IsActive", roles[i].IsActive, dbType: System.Data.DbType.Boolean);
            }

            this.ExecuteStoredProcedure("InsertRoles", parameters);
            return null;
        }

        /// <summary>
        /// Get Roles
        /// </summary>
        /// <param name="id">Roles id</param>
        /// <returns>Roles proces</returns>
        public Roles GetRoles(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get Roles
        /// </summary>
        /// <param name="ids">Roles ids</param>
        /// <returns>Dictionary based collection of Roless</returns>
        public Dictionary<string, Roles> GetRoless(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get Roless
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Roles</returns>
        public Roles[] GetRoless(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all Roless
        /// </summary>
        /// <returns>Array of Roles</returns>
        public Roles[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        /// <summary>
        /// Get Roless
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Roles</returns>
        public Roles[] GetByIds(IEnumerable<Guid> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsDeleted = 0", this.GetTableName());
            return this.FindByTempTableIds(sql, ids).ToArray();
        }

        /// <summary>
        /// Get table name
        /// </summary>
        /// <returns>Roles table name</returns>
        public string GetRolesName()
        {
            return this.GetTableName();
        }

        /// <summary>
        /// Get column names
        /// </summary>
        /// <returns>Column names</returns>
        public string[] GetColumns()
        {
            PropertyInfo[] props = this.Mapping(new Roles()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update Roles
        /// </summary>
        /// <param name="roles">Array of Roles</param>
        /// <returns>Roles collection</returns>
        public Roles[] UpdateRoless(Roles[] roles)
        {
            if (roles.Any())
            {
                DynamicParameters parameters = new DynamicParameters();

                for (int i = 0; i < roles.Count(); i++)
                {
                    parameters.Add("Id", roles[i].Id, dbType: System.Data.DbType.Guid);
                    parameters.Add("RoleName", roles[i].RoleName, dbType: System.Data.DbType.String);

                }

                this.ExecuteStoredProcedure("UpdateRoles", parameters);
            }

            return roles;
        }

        /// <summary>
        /// Delete Roles
        /// </summary>
        /// <param name="id">Roles id</param>
        /// <returns>Array of Roles</returns>
        public Roles[] DeleteRoless(string id)
        {
            if (id != null)
            {
                //string[] ids = { id };
                //this.DeleteByDbId(ids);
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", new Guid(id), dbType: System.Data.DbType.Guid);

                this.ExecuteStoredProcedure("DeleteRoles", parameters);
            }

            return null;
        }

        /// <summary>
        /// Returns table name
        /// </summary>
        /// <returns>Table name</returns>
        internal override string GetTableName()
        {
            return TableNameConstants.Roles;
        }

        /// <summary>
        /// Map Roles item properties
        /// </summary>
        /// <param name="item">Roles item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(Roles item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.RoleName,

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
