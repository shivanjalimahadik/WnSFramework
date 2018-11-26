//-----------------------------------------------------------------------
// <copyright file="ILegalEntityRepository.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BusinessLogic.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    /// <summary>
    /// LegalEntity interface 
    /// </summary>
    public interface ILegalEntityRepository
    {
        /// <summary>
        /// Add LegalEntity
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity</param>
        /// <returns></returns>
        Task AddAsync(LegalEntity[] legalEntitys);

        /// <summary>
        /// Add LegalEntity
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity</param>
        /// <returns>Array of LegalEntity</returns>
        LegalEntity[] Add(LegalEntity[] legalEntitys);

        /// <summary>
        /// Get LegalEntity
        /// </summary>
        /// <param name="id">LegalEntity id</param>
        /// <returns>LegalEntity legalEntity</returns>
        LegalEntity Get(string id);

        /// <summary>
        /// Get LegalEntity collection
        /// </summary>
        /// <param name="ids">Array of LegalEntity id</param>
        /// <returns>Dictionary based LegalEntity collection</returns>
        Dictionary<string, LegalEntity> Get(string[] ids);

        /// <summary>
        /// Get LegalEntity
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of LegalEntity</returns>
        LegalEntity[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of LegalEntity</returns>
        LegalEntity[] GetAll();

        /// <summary>
        /// Get LegalEntity
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of LegalEntity</returns>
        LegalEntity[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update LegalEntity
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity</param>
        /// <returns>Array of LegalEntity</returns>
        LegalEntity[] Update(LegalEntity[] legalEntitys);

        /// <summary>
        /// Delete LegalEntity
        /// </summary>
        /// <param name="id">LegalEntity id</param>
        /// <returns>Array of LegalEntity</returns>
        LegalEntity[] Delete(string id);
    }
}
