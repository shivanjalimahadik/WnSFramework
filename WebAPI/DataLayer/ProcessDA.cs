//-----------------------------------------------------------------------
// <copyright file="ProcessDA.cs" company="SA Technology">
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
    /// ProcessDA class holds method implementation for database operations
    /// </summary>
    public class ProcessDA : DataAccessBase<Process>, IProcessDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public ProcessDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add Process to database
        /// </summary>
        /// <param name="process">Array of Process</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddProcessAsync(Process[] process)
        {
            await this.AddAsync(process);
        }

        /// <summary>
        /// Add Process to database
        /// </summary>
        /// <param name="process">Array of Process</param>
        /// <returns>Process collection</returns>
        public Process[] AddProcesss(Process[] process)
        {
            DynamicParameters parameters = new DynamicParameters();

            for (int i = 0; i < process.Count(); i++)
            {
                parameters.Add("Id", Guid.NewGuid(), dbType: System.Data.DbType.Guid);
                parameters.Add("ProcessName", process[i].ProcessName, dbType: System.Data.DbType.String);
                parameters.Add("ResourcesID", process[i].ResourcesID, dbType: System.Data.DbType.Guid);
                parameters.Add("UDF1", process[i].UDF1, dbType: System.Data.DbType.String);
                parameters.Add("UDF2", process[i].UDF2, dbType: System.Data.DbType.String);
                parameters.Add("UDF3", process[i].UDF3, dbType: System.Data.DbType.String);
                parameters.Add("UDF4", process[i].UDF4, dbType: System.Data.DbType.String);
                parameters.Add("UDF5", process[i].UDF5, dbType: System.Data.DbType.String);
                parameters.Add("PortalID", process[i].PortalID, dbType: System.Data.DbType.String);
                parameters.Add("AppID", process[i].AppID, dbType: System.Data.DbType.String);
                parameters.Add("PrimaryIPAdd", process[i].PrimaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("SecondaryIPAdd", process[i].SecondaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("AzureRegion", process[i].AzureRegion, dbType: System.Data.DbType.String);
                parameters.Add("CreatedOn", process[i].CreatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("CreatedBy", process[i].CreatedBy, dbType: System.Data.DbType.String);
                parameters.Add("UpdatedOn", process[i].UpdatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("UpdatedBy", process[i].UpdatedBy, dbType: System.Data.DbType.String);
                parameters.Add("IsActive", process[i].IsActive, dbType: System.Data.DbType.Boolean);
            }

            this.ExecuteStoredProcedure("InsertProcess", parameters);
            return null;
        }

        /// <summary>
        /// Get Process
        /// </summary>
        /// <param name="id">Process id</param>
        /// <returns>Process proces</returns>
        public Process GetProcess(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get Process
        /// </summary>
        /// <param name="ids">Process ids</param>
        /// <returns>Dictionary based collection of Processs</returns>
        public Dictionary<string, Process> GetProcesss(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get Processs
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Process</returns>
        public Process[] GetProcesss(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all Processs
        /// </summary>
        /// <returns>Array of Process</returns>
        public Process[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        public ProcessWrapper[] GetAllProcess()
        {
            List<ProcessWrapper> pWrapper = new List<ProcessWrapper>();
            var sql = string.Format("SELECT P.Id, P.ProcessName, R.ResourceName FROM {0} P INNER JOIN {1} R ON " +
                " P.ResourcesID = R.Id WHERE P.IsActive = 1 AND R.IsActive = 1 ", GetTableName(), TableNameConstants.Resources);

            var dynamicP = base.FindDynamic(sql, new { });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(ProcessWrapper), new List<string> { "Id" });
            pWrapper = (Slapper.AutoMapper.MapDynamic<ProcessWrapper>(dynamicP) as IEnumerable<ProcessWrapper>).ToList();

            return pWrapper.ToArray();
        }

        /// <summary>
        /// Get Processs
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Process</returns>
        public Process[] GetByIds(IEnumerable<Guid> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsDeleted = 0", this.GetTableName());
            return this.FindByTempTableIds(sql, ids).ToArray();
        }

        /// <summary>
        /// Get table name
        /// </summary>
        /// <returns>Process table name</returns>
        public string GetProcessName()
        {
            return this.GetTableName();
        }

        /// <summary>
        /// Get column names
        /// </summary>
        /// <returns>Column names</returns>
        public string[] GetColumns()
        {
            PropertyInfo[] props = this.Mapping(new Process()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update Process
        /// </summary>
        /// <param name="process">Array of Process</param>
        /// <returns>Process collection</returns>
        public Process[] UpdateProcesss(Process[] process)
        {
            if (process.Any())
            {
                DynamicParameters parameters = new DynamicParameters();

                for (int i = 0; i < process.Count(); i++)
                {
                    parameters.Add("Id", process[i].Id, dbType: System.Data.DbType.Guid);
                    parameters.Add("ProcessName", process[i].ProcessName, dbType: System.Data.DbType.String);
                    parameters.Add("ResourcesID", process[i].ResourcesID, dbType: System.Data.DbType.Guid);
                }
                this.ExecuteStoredProcedure("UpdateProcess", parameters);
            }

            return process;
        }

        /// <summary>
        /// Delete Process
        /// </summary>
        /// <param name="id">Process id</param>
        /// <returns>Array of Process</returns>
        public Process[] DeleteProcesss(string id)
        {
            if (id != null)
            {
                //string[] ids = { id };
                //this.DeleteByDbId(ids);
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", new Guid(id), dbType: System.Data.DbType.Guid);

                this.ExecuteStoredProcedure("DeleteProcess", parameters);
            }

            return null;
        }

        /// <summary>
        /// Returns table name
        /// </summary>
        /// <returns>Table name</returns>
        internal override string GetTableName()
        {
            return TableNameConstants.Process;
        }

        /// <summary>
        /// Map Process item properties
        /// </summary>
        /// <param name="item">Process item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(Process item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.ProcessName,
                item.ResourcesID,

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
