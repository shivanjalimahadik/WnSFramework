//-----------------------------------------------------------------------
// <copyright file="IBusinessRuleRepository.cs" company="SA Technology">
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
    /// BusinessRule interface 
    /// </summary>
    public interface IBusinessRuleRepository
    {
        /// <summary>
        /// Add BusinessRule
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule</param>
        /// <returns></returns>
        Task AddAsync(BusinessRule[] businessRules);

        /// <summary>
        /// Add BusinessRule
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule</param>
        /// <returns>Array of BusinessRule</returns>
        BusinessRule[] Add(BusinessRule[] businessRules);

        /// <summary>
        /// Get BusinessRule
        /// </summary>
        /// <param name="id">BusinessRule id</param>
        /// <returns>BusinessRule entity</returns>
        BusinessRule Get(string id);

        /// <summary>
        /// Get BusinessRule collection
        /// </summary>
        /// <param name="ids">Array of BusinessRule id</param>
        /// <returns>Dictionary based BusinessRule collection</returns>
        Dictionary<string, BusinessRule> Get(string[] ids);

        /// <summary>
        /// Get BusinessRule
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of BusinessRule</returns>
        BusinessRule[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of BusinessRule</returns>
        BusinessRule[] GetAll();

        /// <summary>
        /// Get BusinessRule
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of BusinessRule</returns>
        BusinessRule[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update BusinessRule
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule</param>
        /// <returns>Array of BusinessRule</returns>
        BusinessRule[] Update(BusinessRule[] businessRules);

        /// <summary>
        /// Delete BusinessRule
        /// </summary>
        /// <param name="id">BusinessRule id</param>
        /// <returns>Array of BusinessRule</returns>
        BusinessRule[] Delete(string id);
    }
}
