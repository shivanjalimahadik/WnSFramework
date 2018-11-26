//-----------------------------------------------------------------------
// <copyright file="ICostCenterRepository.cs" company="SA Technology">
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
    /// CostCenter interface 
    /// </summary>
    public interface ICostCenterRepository
    {
        /// <summary>
        /// Add CostCenter
        /// </summary>
        /// <param name="costCenters">Array of CostCenter</param>
        /// <returns></returns>
        Task AddAsync(CostCenter[] costCenters);

        /// <summary>
        /// Add CostCenter
        /// </summary>
        /// <param name="costCenters">Array of CostCenter</param>
        /// <returns>Array of CostCenter</returns>
        CostCenter[] Add(CostCenter[] costCenters);

        /// <summary>
        /// Get CostCenter
        /// </summary>
        /// <param name="id">CostCenter id</param>
        /// <returns>CostCenter entity</returns>
        CostCenter Get(string id);

        /// <summary>
        /// Get CostCenter collection
        /// </summary>
        /// <param name="ids">Array of CostCenter id</param>
        /// <returns>Dictionary based CostCenter collection</returns>
        Dictionary<string, CostCenter> Get(string[] ids);

        /// <summary>
        /// Get CostCenter
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of CostCenter</returns>
        CostCenter[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of CostCenter</returns>
        CostCenter[] GetAll();

        /// <summary>
        /// Get CostCenter
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of CostCenter</returns>
        CostCenter[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update CostCenter
        /// </summary>
        /// <param name="costCenters">Array of CostCenter</param>
        /// <returns>Array of CostCenter</returns>
        CostCenter[] Update(CostCenter[] costCenters);

        /// <summary>
        /// Delete CostCenter
        /// </summary>
        /// <param name="id">CostCenter id</param>
        /// <returns>Array of CostCenter</returns>
        CostCenter[] Delete(string id);
    }
}
