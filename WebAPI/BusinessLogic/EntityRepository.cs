//-----------------------------------------------------------------------
// <copyright file="EntityRepository.cs" company="SA Technology">
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
    public class EntityRepository : IEntityRepository
    {
        /// <summary>
        /// IEntityDA variable
        /// </summary>
        private IEntityDA _EntityDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public EntityRepository(IEntityDA entityDA)
        {
            _EntityDA = entityDA;
        }

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entitys">Array of Entity</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(Entity[] entitys)
        {
            await _EntityDA.AddEntityAsync(entitys);
        }

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entitys">Array of Entity</param>
        /// <returns>Array of Entity</returns>
        public Entity[] Add(Entity[] entitys)
        {
            return _EntityDA.AddEntitys(entitys);
        }

        /// <summary>
        /// Get Entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity entity</returns>
        public Entity Get(string id)
        {
            return _EntityDA.GetEntity(id);
        }

        /// <summary>
        /// Get Entity collection
        /// </summary>
        /// <param name="ids">Array of Entity id</param>
        /// <returns>Dictionary based Entity collection</returns>
        public Dictionary<string, Entity> Get(string[] ids)
        {
            return _EntityDA.GetEntitys(ids);
        }

        /// <summary>
        /// Get Entity
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Entity</returns>
        public Entity[] Get(IEnumerable<Guid?> ids)
        {
            return _EntityDA.GetEntitys(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of Entity</returns>
        public Entity[] GetAll()
        {
            return _EntityDA.GetAll();
        }

        /// <summary>
        /// Get Entity
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Entity</returns>
        public Entity[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _EntityDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entitys">Array of Entity</param>
        /// <returns>Array of Entity</returns>
        public Entity[] Update(Entity[] entitys)
        {
            return _EntityDA.UpdateEntitys(entitys);
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Array of Entity</returns>
        public Entity[] Delete(string id)
        {
            return _EntityDA.DeleteEntitys(id);
        }
    }
}
