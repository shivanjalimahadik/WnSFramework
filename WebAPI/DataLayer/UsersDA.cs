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
            return this.Add(users);
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
                this.Update(users);
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
