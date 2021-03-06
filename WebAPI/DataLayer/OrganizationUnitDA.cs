﻿//-----------------------------------------------------------------------
// <copyright file="OrganizationUnitDA.cs" company="SA Technology">
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
    /// OrganizationUnitDA class holds method implementation for database operations
    /// </summary>
    public class OrganizationUnitDA : DataAccessBase<OrganizationUnit>, IOrganizationUnitDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationUnitDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public OrganizationUnitDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add OrganizationUnit to database
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddOrganizationUnitAsync(OrganizationUnit[] organizationUnits)
        {
            await this.AddAsync(organizationUnits);
        }

        /// <summary>
        /// Add OrganizationUnit to database
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit</param>
        /// <returns>OrganizationUnit collection</returns>
        public OrganizationUnit[] AddOrganizationUnits(OrganizationUnit[] organizationUnits)
        {
            DynamicParameters parameters = new DynamicParameters();

            for (int i = 0; i < organizationUnits.Count(); i++)
            {
                parameters.Add("Id", Guid.NewGuid(), dbType: System.Data.DbType.Guid);
                parameters.Add("OrganizationUnitName", organizationUnits[i].OrganizationUnitName, dbType: System.Data.DbType.String);
                parameters.Add("OrganizationUnitDescription", organizationUnits[i].OrganizationUnitDescription, dbType: System.Data.DbType.String);
                parameters.Add("BusinessUnitID", organizationUnits[i].BusinessUnitID, dbType: System.Data.DbType.Guid);
                parameters.Add("UDF1", organizationUnits[i].UDF1, dbType: System.Data.DbType.String);
                parameters.Add("UDF2", organizationUnits[i].UDF2, dbType: System.Data.DbType.String);
                parameters.Add("UDF3", organizationUnits[i].UDF3, dbType: System.Data.DbType.String);
                parameters.Add("UDF4", organizationUnits[i].UDF4, dbType: System.Data.DbType.String);
                parameters.Add("UDF5", organizationUnits[i].UDF5, dbType: System.Data.DbType.String);
                parameters.Add("PortalID", organizationUnits[i].PortalID, dbType: System.Data.DbType.String);
                parameters.Add("AppID", organizationUnits[i].AppID, dbType: System.Data.DbType.String);
                parameters.Add("PrimaryIPAdd", organizationUnits[i].PrimaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("SecondaryIPAdd", organizationUnits[i].SecondaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("AzureRegion", organizationUnits[i].AzureRegion, dbType: System.Data.DbType.String);
                parameters.Add("CreatedOn", organizationUnits[i].CreatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("CreatedBy", organizationUnits[i].CreatedBy, dbType: System.Data.DbType.String);
                parameters.Add("UpdatedOn", organizationUnits[i].UpdatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("UpdatedBy", organizationUnits[i].UpdatedBy, dbType: System.Data.DbType.String);
                parameters.Add("IsActive", organizationUnits[i].IsActive, dbType: System.Data.DbType.Boolean);
            }

            this.ExecuteStoredProcedure("InsertOUDetails", parameters);
            return null;
        }

        /// <summary>
        /// Get OrganizationUnit
        /// </summary>
        /// <param name="id">OrganizationUnit id</param>
        /// <returns>OrganizationUnit organizationUnit</returns>
        public OrganizationUnit GetOrganizationUnit(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get OrganizationUnit
        /// </summary>
        /// <param name="ids">OrganizationUnit ids</param>
        /// <returns>Dictionary based collection of OrganizationUnits</returns>
        public Dictionary<string, OrganizationUnit> GetOrganizationUnits(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get OrganizationUnits
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of OrganizationUnit</returns>
        public OrganizationUnit[] GetOrganizationUnits(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all OrganizationUnits
        /// </summary>
        /// <returns>Array of OrganizationUnit</returns>
        public OrganizationUnit[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        public OUWrapper[] GetAllOrganizationUnits()
        {
            List<OUWrapper> ouWrapper = new List<OUWrapper>();
            var sql = string.Format("SELECT OU.Id, OU.OrganizationUnitName, OU.OrganizationUnitDescription, BU.BusinessUnitName FROM {0} OU INNER JOIN {1} BU ON " +
                " OU.BusinessUnitID = BU.Id WHERE OU.IsActive = 1 AND BU.IsActive = 1 ", GetTableName(), TableNameConstants.BusinessUnit);

            var dynamicOU = base.FindDynamic(sql, new { });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(OUWrapper), new List<string> { "Id" });
            ouWrapper = (Slapper.AutoMapper.MapDynamic<OUWrapper>(dynamicOU) as IEnumerable<OUWrapper>).ToList();

            return ouWrapper.ToArray();
        }

        /// <summary>
        /// Get OrganizationUnits
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of OrganizationUnit</returns>
        public OrganizationUnit[] GetByIds(IEnumerable<Guid> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsDeleted = 0", this.GetTableName());
            return this.FindByTempTableIds(sql, ids).ToArray();
        }

        /// <summary>
        /// Get table name
        /// </summary>
        /// <returns>OrganizationUnit table name</returns>
        public string GetOrganizationUnitName()
        {
            return this.GetTableName();
        }

        /// <summary>
        /// Get column names
        /// </summary>
        /// <returns>Column names</returns>
        public string[] GetColumns()
        {
            PropertyInfo[] props = this.Mapping(new OrganizationUnit()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update OrganizationUnit
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit</param>
        /// <returns>OrganizationUnit collection</returns>
        public OrganizationUnit[] UpdateOrganizationUnits(OrganizationUnit[] organizationUnits)
        {
            if (organizationUnits.Any())
            {
                DynamicParameters parameters = new DynamicParameters();

                for (int i = 0; i < organizationUnits.Count(); i++)
                {
                    parameters.Add("Id", organizationUnits[i].Id, dbType: System.Data.DbType.Guid);
                    parameters.Add("OrganizationUnitName", organizationUnits[i].OrganizationUnitName, dbType: System.Data.DbType.String);
                    parameters.Add("OrganizationUnitDescription", organizationUnits[i].OrganizationUnitDescription, dbType: System.Data.DbType.String);
                    parameters.Add("BusinessUnitID", organizationUnits[i].BusinessUnitID, dbType: System.Data.DbType.Guid);

                }
                this.ExecuteStoredProcedure("UpdateOU", parameters);
            }

            return organizationUnits;
        }

        /// <summary>
        /// Delete OrganizationUnit
        /// </summary>
        /// <param name="id">OrganizationUnit id</param>
        /// <returns>Array of OrganizationUnit</returns>
        public OrganizationUnit[] DeleteOrganizationUnits(string id)
        {
            if (id != null)
            {
                //string[] ids = { id };
                //this.DeleteByDbId(ids);
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", new Guid(id), dbType: System.Data.DbType.Guid);

                this.ExecuteStoredProcedure("DeleteOU", parameters);
            }

            return null;
        }

        /// <summary>
        /// Returns table name
        /// </summary>
        /// <returns>Table name</returns>
        internal override string GetTableName()
        {
            return TableNameConstants.OrganizationUnit;
        }

        /// <summary>
        /// Map OrganizationUnit item properties
        /// </summary>
        /// <param name="item">OrganizationUnit item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(OrganizationUnit item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.OrganizationUnitName,
                item.OrganizationUnitDescription,

                item.BusinessUnitID,
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
