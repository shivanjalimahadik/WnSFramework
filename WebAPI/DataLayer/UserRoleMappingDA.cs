//-----------------------------------------------------------------------
// <copyright file="UserRoleMappingDA.cs" company="SA Technology">
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
    /// UserRoleMappingDA class holds method implementation for database operations
    /// </summary>
    public class UserRoleMappingDA : DataAccessBase<UserRoleMapping>, IUserRoleMappingDA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleMappingDA" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public UserRoleMappingDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        /// <summary>
        /// Add UserRoleMapping to database
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddUserRoleMappingAsync(UserRoleMapping[] userRoleMappings)
        {
            await this.AddAsync(userRoleMappings);
        }

        /// <summary>
        /// Add UserRoleMapping to database
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping</param>
        /// <returns>UserRoleMapping collection</returns>
        public UserRoleMapping[] AddUserRoleMappings(UserRoleMapping[] userRoleMappings)
        {
            string roleId = string.Empty;

            for (int i = 0; i < userRoleMappings.Count(); i++)
            {
                roleId += userRoleMappings[i].RoleID.ToString() + ',';
            }

            roleId = roleId.Remove(roleId.LastIndexOf(','));

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserID", userRoleMappings[0].UserID, dbType: System.Data.DbType.Guid);
            parameters.Add("@RoleID", roleId, dbType: System.Data.DbType.String);

            this.ExecuteStoredProcedure("usp_InsertUserRoleMapping", parameters);

            //return this.Add(userRoleMappings);
            return userRoleMappings;
        }

        /// <summary>
        /// Get UserRoleMapping
        /// </summary>
        /// <param name="id">UserRoleMapping id</param>
        /// <returns>UserRoleMapping proces</returns>
        public UserRoleMapping GetUserRoleMapping(string id)
        {
            return this.FindById(id);
        }

        /// <summary>
        /// Get UserRoleMapping
        /// </summary>
        /// <param name="ids">UserRoleMapping ids</param>
        /// <returns>Dictionary based collection of UserRoleMappings</returns>
        public Dictionary<string, UserRoleMapping> GetUserRoleMappings(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        /// <summary>
        /// Get UserRoleMappings
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleMapping[] GetUserRoleMappings(IEnumerable<Guid?> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE UserId IN @ids AND IsActive = 1", this.GetTableName());
            return this.Find(sql, new { ids }).ToArray();
        }

        /// <summary>
        /// Get all UserRoleMappings
        /// </summary>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleMapping[] GetAll()
        {
            return this.FindAll().ToArray();
        }

        /// <summary>
        /// Get all UserRoleMappings
        /// </summary>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleWrapper[] GetAllUserRoleMapping()
        {
            List<UserRoleWrapper> userRoleWrapper = new List<UserRoleWrapper>();
            var sql = string.Format("SELECT DISTINCT map.UserID, users.UserName, Users.FirstName, users.LastName, " +
                " dbo.fn_GetRoleList(map.UserID) AS AssignedRoles from {0} map inner join Roles  on map.RoleID = roles.id  " +
                " inner join Users on map.UserID = users.Id where map.IsActive = 1 ", GetTableName());

            var dynamicUR = base.FindDynamic(sql, new { });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(UserRoleWrapper), new List<string> { "UserID" });
            userRoleWrapper = (Slapper.AutoMapper.MapDynamic<UserRoleWrapper>(dynamicUR) as IEnumerable<UserRoleWrapper>).ToList();

            return userRoleWrapper.ToArray();
        }

        /// <summary>
        /// Get UserRoleMappings
        /// </summary>
        /// <param name="ids">IEnumerable collection of Guids</param>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleMapping[] GetByIds(IEnumerable<Guid> ids)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsDeleted = 0", this.GetTableName());
            return this.FindByTempTableIds(sql, ids).ToArray();
        }

        /// <summary>
        /// Get table name
        /// </summary>
        /// <returns>UserRoleMapping table name</returns>
        public string GetUserRoleMappingName()
        {
            return this.GetTableName();
        }

        /// <summary>
        /// Get column names
        /// </summary>
        /// <returns>Column names</returns>
        public string[] GetColumns()
        {
            PropertyInfo[] props = this.Mapping(new UserRoleMapping()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        /// <summary>
        /// Update UserRoleMapping
        /// </summary>
        /// <param name="userRoleMappings">Array of UserRoleMapping</param>
        /// <returns>UserRoleMapping collection</returns>
        public UserRoleMapping[] UpdateUserRoleMappings(UserRoleMapping[] userRoleMappings)
        {
            if (userRoleMappings.Any())
            {
                //this.Update(userRoleMappings);

                string roleId = string.Empty;

                for (int i = 0; i < userRoleMappings.Count(); i++)
                {
                    roleId += userRoleMappings[i].RoleID.ToString() + ',';
                }

                roleId = roleId.Remove(roleId.LastIndexOf(','));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserID", userRoleMappings[0].UserID, dbType: System.Data.DbType.Guid);
                parameters.Add("@RoleID", roleId, dbType: System.Data.DbType.String);

                this.ExecuteStoredProcedure("usp_UpdateUserRoleMapping", parameters);
            }

            return userRoleMappings;
        }

        /// <summary>
        /// Delete UserRoleMapping
        /// </summary>
        /// <param name="id">UserRoleMapping id</param>
        /// <returns>Array of UserRoleMapping</returns>
        public UserRoleMapping[] DeleteUserRoleMappings(string id)
        {
            if (id != null)
            {
                //string[] ids = { id };
                //this.DeleteByDbId(ids);

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserID", new Guid(id), dbType: System.Data.DbType.Guid);

                this.ExecuteStoredProcedure("usp_DeleteUserRoleMapping", parameters);
            }

            return null;
        }

        /// <summary>
        /// Returns table name
        /// </summary>
        /// <returns>Table name</returns>
        internal override string GetTableName()
        {
            return TableNameConstants.UserRoleMapping;
        }

        /// <summary>
        /// Map UserRoleMapping item properties
        /// </summary>
        /// <param name="item">UserRoleMapping item</param>
        /// <returns>Dynamic object</returns>
        internal override dynamic Mapping(UserRoleMapping item)
        {
            if (string.IsNullOrEmpty(Convert.ToString(item.Id)) || string.Equals(Convert.ToString(item.Id), "00000000-0000-0000-0000-000000000000"))
            {
                item.Id = Guid.NewGuid();
            }

            return new
            {
                item.Id,
                item.UserID,
                item.RoleID,

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
