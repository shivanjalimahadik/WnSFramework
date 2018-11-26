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
            return this.Add(legalEntitys);
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
                this.Update(legalEntitys);
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
