//-----------------------------------------------------------------------
// <copyright file="ILegalEntityDA.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    /// <summary>
    /// ILegalEntity interface. Used to define all abstract methods of LegalEntity legalEntity.
    /// </summary>
    public interface ILegalEntityDA
    {
        /// <summary>
        /// Adds LegalEntity legalEntity to database asynchronously.
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddLegalEntityAsync(LegalEntity[] legalEntitys);

        /// <summary>
        /// Adds LegalEntity legalEntity to database.
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity</param>
        /// <returns>Added array of LegalEntity</returns>
        LegalEntity[] AddLegalEntitys(LegalEntity[] legalEntitys);

        /// <summary>
        /// Gets a single LegalEntity based on id.
        /// </summary>
        /// <param name="id">LegalEntity Id</param>
        /// <returns>LegalEntity legalEntity.</returns>
        LegalEntity GetLegalEntity(string id);

        /// <summary>
        /// Gets a LegalEntity in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of LegalEntity id</param>
        /// <returns>Dictionary of LegalEntity legalEntity</returns>
        Dictionary<string, LegalEntity> GetLegalEntitys(string[] ids);

        /// <summary>
        /// Gets a LegalEntity collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of LegalEntity id</param>
        /// <returns>Array of LegalEntity legalEntity</returns>
        LegalEntity[] GetLegalEntitys(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all LegalEntitys
        /// </summary>
        /// <returns>Array of LegalEntity legalEntity</returns>
        LegalEntity[] GetAll();

        /// <summary>
        /// Gets a LegalEntity collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of LegalEntity id</param>
        /// <returns>Array of LegalEntity legalEntity</returns>
        LegalEntity[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a LegalEntity legalEntity in database
        /// </summary>
        /// <param name="legalEntitys">Array of LegalEntity</param>
        /// <returns>Updated array of LegalEntity legalEntity</returns>
        LegalEntity[] UpdateLegalEntitys(LegalEntity[] legalEntitys);

        /// <summary>
        /// Deletes a LegalEntity from database.
        /// </summary>
        /// <param name="id">Guid representing LegalEntity id</param>
        /// <returns>Array of LegalEntity legalEntity</returns>
        LegalEntity[] DeleteLegalEntitys(string id);
    }
}
