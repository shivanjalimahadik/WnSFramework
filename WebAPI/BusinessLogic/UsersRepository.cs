//-----------------------------------------------------------------------
// <copyright file="UsersRepository.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLogic.Interface;
    using DataAccess.Interface;
    using Entities;
    using Entities.Wrappers;

    public class UsersRepository : IUsersRepository
    {
        /// <summary>
        /// IUsersDA variable
        /// </summary>
        private IUsersDA _userDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public UsersRepository(IUsersDA userDA)
        {
            _userDA = userDA;
        }

        /// <summary>
        /// Add Users
        /// </summary>
        /// <param name="users">Array of Users</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(Users[] users)
        {
            await _userDA.AddUsersAsync(users);
        }

        /// <summary>
        /// Add Users
        /// </summary>
        /// <param name="users">Array of Users</param>
        /// <returns>Array of Users</returns>
        public Users[] Add(Users[] users)
        {
            return _userDA.AddUserss(users);
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="id">Users id</param>
        /// <returns>Users entity</returns>
        public Users Get(string id)
        {
            return _userDA.GetUsers(id);
        }

        /// <summary>
        /// Get Users collection
        /// </summary>
        /// <param name="ids">Array of Users id</param>
        /// <returns>Dictionary based Users collection</returns>
        public Dictionary<string, Users> Get(string[] ids)
        {
            return _userDA.GetUserss(ids);
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Users</returns>
        public Users[] Get(IEnumerable<Guid?> ids)
        {
            return _userDA.GetUserss(ids);
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>Array of Users</returns>
        public Users[] GetAll()
        {
            return _userDA.GetAll();
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Users</returns>
        public Users[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _userDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update Users
        /// </summary>
        /// <param name="users">Array of Users</param>
        /// <returns>Array of Users</returns>
        public Users[] Update(Users[] users)
        {
            return _userDA.UpdateUserss(users);
        }

        /// <summary>
        /// Delete Users
        /// </summary>
        /// <param name="id">Users id</param>
        /// <returns>Array of Users</returns>
        public Users[] Delete(string id)
        {
            return _userDA.DeleteUserss(id);
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>Array of Users</returns>
        public UsersWrapper[] GetAllUsers()
        {
            return _userDA.GetAllUsers();
        }
    }
}
