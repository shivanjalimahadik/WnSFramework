//-----------------------------------------------------------------------
// <copyright file="UsersDA.cs" company="SA Technology">
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
    /// UsersDA class holds method implementation for database operations
    /// </summary>
    public class UsersDA : DataAccessBase<Users>, IUsersDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public UsersDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add Users to database
        /// </summary>
        /// <param name="users">Array of Users</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddUsersAsync(Users[] users)
        {
            await this.AddAsync(users);
        }

        /// <summary>
        /// Add Users to database
        /// </summary>
        /// <param name="users">Array of Users</param>
        /// <returns>Users collection</returns>
        public Users[] AddUserss(Users[] users)
        {
            DynamicParameters parameters = new DynamicParameters();

            for (int i = 0; i < users.Count(); i++)
            {
                parameters.Add("Id", Guid.NewGuid(), dbType: System.Data.DbType.Guid);
                parameters.Add("UserName", users[i].UserName, dbType: System.Data.DbType.String);
                parameters.Add("FirstName", users[i].FirstName, dbType: System.Data.DbType.String);
                parameters.Add("LastName", users[i].LastName, dbType: System.Data.DbType.String);
                parameters.Add("Email", users[i].Email, dbType: System.Data.DbType.String);
                parameters.Add("Password", users[i].Password, dbType: System.Data.DbType.String);
                parameters.Add("PasswordExpiry", users[i].PasswordExpiry, dbType: System.Data.DbType.String);
                parameters.Add("ContactNo", users[i].ContactNo, dbType: System.Data.DbType.String);
                parameters.Add("UDF1", users[i].UDF1, dbType: System.Data.DbType.String);
                parameters.Add("UDF2", users[i].UDF2, dbType: System.Data.DbType.String);
                parameters.Add("UDF3", users[i].UDF3, dbType: System.Data.DbType.String);
                parameters.Add("UDF4", users[i].UDF4, dbType: System.Data.DbType.String);
                parameters.Add("UDF5", users[i].UDF5, dbType: System.Data.DbType.String);
                parameters.Add("PortalID", users[i].PortalID, dbType: System.Data.DbType.String);
                parameters.Add("OrganizationUnitID", users[i].OrganizationUnitID, dbType: System.Data.DbType.Guid);
                parameters.Add("BusinessUnitID", users[i].BusinessUnitID, dbType: System.Data.DbType.Guid);
                parameters.Add("AppID", users[i].AppID, dbType: System.Data.DbType.String);
                parameters.Add("PrimaryIPAdd", users[i].PrimaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("SecondaryIPAdd", users[i].SecondaryIPAdd, dbType: System.Data.DbType.String);
                parameters.Add("AzureRegion", users[i].AzureRegion, dbType: System.Data.DbType.String);
                parameters.Add("CreatedOn", users[i].CreatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("CreatedBy", users[i].CreatedBy, dbType: System.Data.DbType.String);
                parameters.Add("UpdatedOn", users[i].UpdatedOn, dbType: System.Data.DbType.DateTime);
                parameters.Add("UpdatedBy", users[i].UpdatedBy, dbType: System.Data.DbType.String);
                parameters.Add("IsActive", users[i].IsActive, dbType: System.Data.DbType.Boolean);
            }

            this.ExecuteStoredProcedure("InsertUser", parameters);

            return null;
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="id">Users id</param>
        /// <returns>Users entity</returns>
        public Users GetUsers(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="ids">Users ids</param>
        /// <returns>Dictionary based collection of Userss</returns>
        public Dictionary<string, Users> GetUserss(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get Userss
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Users</returns>
        public Users[] GetUserss(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsDeleted = 0", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all Userss
        /// </summary>
        /// <returns>Array of Users</returns>
        public Users[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        /// <summary>
        /// Get all Userss
        /// </summary>
        /// <returns>Array of Users</returns>
        public UsersWrapper[] GetAllUsers()
        {
            List<UsersWrapper> userWrapper = new List<UsersWrapper>();
            var sql = string.Format("SELECT U.Id, U.UserName, U.FirstName, U.LastName, U.Email, U.Password, U.PasswordExpiry, U.ContactNo, OU.OrganizationUnitName, BU.BusinessUnitName " +
                " FROM {0} U INNER JOIN {1} OU ON U.OrganizationUnitID = OU.Id INNER JOIN {2} BU ON U.BusinessUnitID = BU.Id " +
                " WHERE U.IsActive = 1 ", GetTableName(), TableNameConstants.OrganizationUnit, TableNameConstants.BusinessUnit);

            var dynamicUser = base.FindDynamic(sql, new { });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(UsersWrapper), new List<string> { "Id" });
            userWrapper = (Slapper.AutoMapper.MapDynamic<UsersWrapper>(dynamicUser) as IEnumerable<UsersWrapper>).ToList();

            return userWrapper.ToArray();
        }

        /// <summary>
        /// Get Userss
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Users</returns>
        public Users[] GetByIds(IEnumerable<Guid> ids)
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
            PropertyInfo[] props = this.Mapping(new Users()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update Users
        /// </summary>
        /// <param name="users">Array of Users</param>
        /// <returns>Users collection</returns>
        public Users[] UpdateUserss(Users[] users)
        {
            if (users.Any())
            {
                DynamicParameters parameters = new DynamicParameters();

                for (int i = 0; i < users.Count(); i++)
                {
                    parameters.Add("Id", users[i].Id, dbType: System.Data.DbType.Guid);
                    parameters.Add("UserName", users[i].UserName, dbType: System.Data.DbType.String);
                    parameters.Add("FirstName", users[i].FirstName, dbType: System.Data.DbType.String);
                    parameters.Add("LastName", users[i].LastName, dbType: System.Data.DbType.String);
                    parameters.Add("Email", users[i].Email, dbType: System.Data.DbType.String);
                    parameters.Add("OrganizationUnitID", users[i].OrganizationUnitID, dbType: System.Data.DbType.Guid);
                    parameters.Add("BusinessUnitID", users[i].BusinessUnitID, dbType: System.Data.DbType.Guid);
                }
                this.ExecuteStoredProcedure("UpdateUser", parameters);
            }
            return users;
        }

        /// <summary>
        /// Delete Users
        /// </summary>
        /// <param name="id">Users id</param>
        /// <returns>Array of Users</returns>
        public Users[] DeleteUserss(string id)
        {
            if (id != null)
            {
                //string[] ids = { id };
                //this.DeleteByDbId(ids);

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", new Guid(id), dbType: System.Data.DbType.Guid);

                this.ExecuteStoredProcedure("DeleteUser", parameters);
            }
            return null;
        }

        /// <summary>
        /// Returns table name
        /// </summary>
        /// <returns>Table name</returns>
        internal override string GetTableName()
        {
            return TableNameConstants.Users;
        }

        /// <summary>
        /// Map Users item properties
        /// </summary>
        /// <param name="item">Users item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(Users item)
        {
            if(string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.UserName,
                item.FirstName,
                item.LastName,
                item.Email,
                item.ContactNo,
                item.PasswordExpiry,
                item.Password,
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
