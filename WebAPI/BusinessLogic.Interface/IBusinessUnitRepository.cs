//-----------------------------------------------------------------------
// <copyright file="IBusinessUnitRepository.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BusinessLogic.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    using Entities.Wrappers;

    /// <summary>
    /// BusinessUnit interface 
    /// </summary>
    public interface IBusinessUnitRepository
    {
        /// <summary>
        /// Add BusinessUnit
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit</param>
        /// <returns></returns>
        Task AddAsync(BusinessUnit[] businessUnits);

        /// <summary>
        /// Add BusinessUnit
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit</param>
        /// <returns>Array of BusinessUnit</returns>
        BusinessUnit[] Add(BusinessUnit[] businessUnits);

        /// <summary>
        /// Get BusinessUnit
        /// </summary>
        /// <param name="id">BusinessUnit id</param>
        /// <returns>BusinessUnit entity</returns>
        BusinessUnit Get(string id);

        /// <summary>
        /// Get BusinessUnit collection
        /// </summary>
        /// <param name="ids">Array of BusinessUnit id</param>
        /// <returns>Dictionary based BusinessUnit collection</returns>
        Dictionary<string, BusinessUnit> Get(string[] ids);

        /// <summary>
        /// Get BusinessUnit
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of BusinessUnit</returns>
        BusinessUnit[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of BusinessUnit</returns>
        BusinessUnit[] GetAll();

        /// <summary>
        /// Get BusinessUnit
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of BusinessUnit</returns>
        BusinessUnit[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update BusinessUnit
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit</param>
        /// <returns>Array of BusinessUnit</returns>
        BusinessUnit[] Update(BusinessUnit[] businessUnits);

        /// <summary>
        /// Delete BusinessUnit
        /// </summary>
        /// <param name="id">BusinessUnit id</param>
        /// <returns>Array of BusinessUnit</returns>
        BusinessUnit[] Delete(string id);

        /// <summary>
        /// Get all Organization units
        /// </summary>
        /// <returns></returns>
        BUWrapper[] GetAllBusinessUnits();
    }
}
