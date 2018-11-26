//-----------------------------------------------------------------------
// <copyright file="LegalEntityRepository.cs" company="SA Technology">
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
    public class LegalEntityRepository : ILegalEntityRepository
    {
        /// <summary>
        /// ILegalEntityDA variable
        /// </summary>
        private ILegalEntityDA _LegalEntityDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="LegalEntityRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public LegalEntityRepository(ILegalEntityDA legalEntityDA)
        {
            _LegalEntityDA = legalEntityDA;
        }

        /// <summary>
        /// Add LegalEntity
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(LegalEntity[] legalEntitys)
        {
            await _LegalEntityDA.AddLegalEntityAsync(legalEntitys);
        }

        /// <summary>
        /// Add LegalEntity
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity</param>
        /// <returns>Array of LegalEntity</returns>
        public LegalEntity[] Add(LegalEntity[] legalEntitys)
        {
            return _LegalEntityDA.AddLegalEntitys(legalEntitys);
        }

        /// <summary>
        /// Get LegalEntity
        /// </summary>
        /// <param name="id">LegalEntity id</param>
        /// <returns>LegalEntity legalEntity</returns>
        public LegalEntity Get(string id)
        {
            return _LegalEntityDA.GetLegalEntity(id);
        }

        /// <summary>
        /// Get LegalEntity collection
        /// </summary>
        /// <param name="ids">Array of LegalEntity id</param>
        /// <returns>Dictionary based LegalEntity collection</returns>
        public Dictionary<string, LegalEntity> Get(string[] ids)
        {
            return _LegalEntityDA.GetLegalEntitys(ids);
        }

        /// <summary>
        /// Get LegalEntity
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of LegalEntity</returns>
        public LegalEntity[] Get(IEnumerable<Guid?> ids)
        {
            return _LegalEntityDA.GetLegalEntitys(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of LegalEntity</returns>
        public LegalEntity[] GetAll()
        {
            return _LegalEntityDA.GetAll();
        }

        /// <summary>
        /// Get LegalEntity
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of LegalEntity</returns>
        public LegalEntity[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _LegalEntityDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update LegalEntity
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity</param>
        /// <returns>Array of LegalEntity</returns>
        public LegalEntity[] Update(LegalEntity[] legalEntitys)
        {
            return _LegalEntityDA.UpdateLegalEntitys(legalEntitys);
        }

        /// <summary>
        /// Delete LegalEntity
        /// </summary>
        /// <param name="id">LegalEntity id</param>
        /// <returns>Array of LegalEntity</returns>
        public LegalEntity[] Delete(string id)
        {
            return _LegalEntityDA.DeleteLegalEntitys(id);
        }
    }
}
