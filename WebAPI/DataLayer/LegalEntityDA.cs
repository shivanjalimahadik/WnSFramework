//-----------------------------------------------------------------------
// <copyright file="LegalEntityDA.cs" company="SA Technology">
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
    /// LegalEntityDA class holds method implementation for database operations
    /// </summary>
    public class LegalEntityDA : DataAccessBase<LegalEntity>, ILegalEntityDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegalEntityDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public LegalEntityDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add LegalEntity to database
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddLegalEntityAsync(LegalEntity[] legalEntitys)
        {
            await this.AddAsync(legalEntitys);
        }

        /// <summary>
        /// Add LegalEntity to database
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity</param>
        /// <returns>LegalEntity collection</returns>
        public LegalEntity[] AddLegalEntitys(LegalEntity[] legalEntitys)
        {
            DynamicParameters parameters = new DynamicParameters();

            for (int i = 0; i < legalEntitys.Count(); i++)
            {
                parameters.Add("Id", Guid.NewGuid(), dbType: System.Data.DbType.Guid);
                parameters.Add("LegalEntityName", legalEntitys[i].LegalEntityName, dbType: System.Data.DbType.String);
                parameters.Add("OrganizationUnitID", legalEntitys[i].OrganizationUnitID, dbType: System.Data.DbType.Guid);
                parameters.Add("BusinessUnitID", legalEntitys[i].BusinessUnitID, dbType: System.Data.DbType.Guid);
                parameters.Add("UDF1", legalEntitys[i].UDF1, dbType: System.Data.DbType.String);
                parameters.Add("UDF2", legalEntitys[i].UDF2, dbType: System.Data.DbType.String);
                parameters.Add("UDF3", legalEntitys[i].UDF3, dbType: System.Data.DbType.String);
                parameters.Add("UDF4", legalEntitys[i].UDF4, dbType: System.Data.DbType.String);
                parameters.Add("UDF5", legalEntitys[i].UDF5, dbType: System.Data.DbType.String);
                parameters.Add("PortalID", legalEntitys[i].PortalID, dbType: System.Data.DbType.String);
                parameters.Add("AppID", legalEntitys[i].AppID, dbType: System.Data.DbType.String);
                parameters.Add("PrimaryIPAdd", legalEntitys[i].PrimaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("SecondaryIPAdd", legalEntitys[i].SecondaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("AzureRegion", legalEntitys[i].AzureRegion, dbType: System.Data.DbType.String);
                parameters.Add("CreatedOn", legalEntitys[i].CreatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("CreatedBy", legalEntitys[i].CreatedBy, dbType: System.Data.DbType.String);
                parameters.Add("UpdatedOn", legalEntitys[i].UpdatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("UpdatedBy", legalEntitys[i].UpdatedBy, dbType: System.Data.DbType.String);
                parameters.Add("IsActive", legalEntitys[i].IsActive, dbType: System.Data.DbType.Boolean);
            }

            this.ExecuteStoredProcedure("InsertLegalEntity", parameters);

            return legalEntitys;

            //return this.Add(legalEntitys);
        }

        /// <summary>
        /// Get LegalEntity
        /// </summary>
        /// <param name="id">LegalEntity id</param>
        /// <returns>LegalEntity legalEntity</returns>
        public LegalEntity GetLegalEntity(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get LegalEntity
        /// </summary>
        /// <param name="ids">LegalEntity ids</param>
        /// <returns>Dictionary based collection of LegalEntitys</returns>
        public Dictionary<string, LegalEntity> GetLegalEntitys(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get LegalEntitys
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of LegalEntity</returns>
        public LegalEntity[] GetLegalEntitys(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all LegalEntitys
        /// </summary>
        /// <returns>Array of LegalEntity</returns>
        public LegalEntity[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        /// <summary>
        /// Get LegalEntitys
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of LegalEntity</returns>
        public LegalEntity[] GetByIds(IEnumerable<Guid> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsDeleted = 0", this.GetTableName());
            return this.FindByTempTableIds(sql, ids).ToArray();
        }

        /// <summary>
        /// Get table name
        /// </summary>
        /// <returns>LegalEntity table name</returns>
        public string GetLegalEntityName()
        {
            return this.GetTableName();
        }

        /// <summary>
        /// Get column names
        /// </summary>
        /// <returns>Column names</returns>
        public string[] GetColumns()
        {
            PropertyInfo[] props = this.Mapping(new LegalEntity()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update LegalEntity
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity</param>
        /// <returns>LegalEntity collection</returns>
        public LegalEntity[] UpdateLegalEntitys(LegalEntity[] legalEntitys)
        {
            if (legalEntitys.Any())
            {
                //this.Update(legalEntitys);
                DynamicParameters parameters = new DynamicParameters();

                for (int i = 0; i < legalEntitys.Count(); i++)
                {
                    parameters.Add("Id", legalEntitys[i].Id, dbType: System.Data.DbType.Guid);
                    parameters.Add("LegalEntityName", legalEntitys[i].LegalEntityName, dbType: System.Data.DbType.String);

                }

                this.ExecuteStoredProcedure("UpdateLegalEntity", parameters);
            }

            return legalEntitys;
        }

        /// <summary>
        /// Delete LegalEntity
        /// </summary>
        /// <param name="id">LegalEntity id</param>
        /// <returns>Array of LegalEntity</returns>
        public LegalEntity[] DeleteLegalEntitys(string id)
        {
            if (id != null)
            {
                //string[] ids = { id };
                //this.DeleteByDbId(ids);
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", new Guid(id), dbType: System.Data.DbType.Guid);

                this.ExecuteStoredProcedure("DeleteLegalEntity", parameters);
            }

            return null;
        }

        /// <summary>
        /// Returns table name
        /// </summary>
        /// <returns>Table name</returns>
        internal override string GetTableName()
        {
            return TableNameConstants.LegalEntity;
        }

        /// <summary>
        /// Map LegalEntity item properties
        /// </summary>
        /// <param name="item">LegalEntity item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(LegalEntity item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.LegalEntityName,


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
