//-----------------------------------------------------------------------
// <copyright file="IBusinessRuleDA.cs" company="SA Technology">
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
    /// IBusinessRule interface. Used to define all abstract methods of BusinessRule entity.
    /// </summary>
    public interface IBusinessRuleDA
    {
        /// <summary>
        /// Adds BusinessRule entity to database asynchronously.
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddBusinessRuleAsync(BusinessRule[] businessRules);

        /// <summary>
        /// Adds BusinessRule entity to database.
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule</param>
        /// <returns>Added array of BusinessRule</returns>
        BusinessRule[] AddBusinessRules(BusinessRule[] businessRules);

        /// <summary>
        /// Gets a single BusinessRule based on id.
        /// </summary>
        /// <param name="id">BusinessRule Id</param>
        /// <returns>BusinessRule entity.</returns>
        BusinessRule GetBusinessRule(string id);

        /// <summary>
        /// Gets a BusinessRule in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of BusinessRule id</param>
        /// <returns>Dictionary of BusinessRule entity</returns>
        Dictionary<string, BusinessRule> GetBusinessRules(string[] ids);

        /// <summary>
        /// Gets a BusinessRule collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of BusinessRule id</param>
        /// <returns>Array of BusinessRule entity</returns>
        BusinessRule[] GetBusinessRules(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all BusinessRules
        /// </summary>
        /// <returns>Array of BusinessRule entity</returns>
        BusinessRule[] GetAll();

        /// <summary>
        /// Gets a BusinessRule collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of BusinessRule id</param>
        /// <returns>Array of BusinessRule entity</returns>
        BusinessRule[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a BusinessRule entity in database
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule</param>
        /// <returns>Updated array of BusinessRule entity</returns>
        BusinessRule[] UpdateBusinessRules(BusinessRule[] businessRules);

        /// <summary>
        /// Deletes a BusinessRule from database.
        /// </summary>
        /// <param name="id">Guid representing BusinessRule id</param>
        /// <returns>Array of BusinessRule entity</returns>
        BusinessRule[] DeleteBusinessRules(string id);
    }
}
