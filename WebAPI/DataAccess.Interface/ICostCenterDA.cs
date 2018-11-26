//-----------------------------------------------------------------------
// <copyright file="ICostCenterDA.cs" company="SA Technology">
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
    /// ICostCenter interface. Used to define all abstract methods of CostCenter entity.
    /// </summary>
    public interface ICostCenterDA
    {
        /// <summary>
        /// Adds CostCenter entity to database asynchronously.
        /// </summary>
        /// <param name="costCenters">Array of CostCenter.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddCostCenterAsync(CostCenter[] costCenters);

        /// <summary>
        /// Adds CostCenter entity to database.
        /// </summary>
        /// <param name="costCenters">Array of CostCenter</param>
        /// <returns>Added array of CostCenter</returns>
        CostCenter[] AddCostCenters(CostCenter[] costCenters);

        /// <summary>
        /// Gets a single CostCenter based on id.
        /// </summary>
        /// <param name="id">CostCenter Id</param>
        /// <returns>CostCenter entity.</returns>
        CostCenter GetCostCenter(string id);

        /// <summary>
        /// Gets a CostCenter in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of CostCenter id</param>
        /// <returns>Dictionary of CostCenter entity</returns>
        Dictionary<string, CostCenter> GetCostCenters(string[] ids);

        /// <summary>
        /// Gets a CostCenter collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of CostCenter id</param>
        /// <returns>Array of CostCenter entity</returns>
        CostCenter[] GetCostCenters(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all CostCenters
        /// </summary>
        /// <returns>Array of CostCenter entity</returns>
        CostCenter[] GetAll();

        /// <summary>
        /// Gets a CostCenter collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of CostCenter id</param>
        /// <returns>Array of CostCenter entity</returns>
        CostCenter[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a CostCenter entity in database
        /// </summary>
        /// <param name="costCenters">Array of CostCenter</param>
        /// <returns>Updated array of CostCenter entity</returns>
        CostCenter[] UpdateCostCenters(CostCenter[] costCenters);

        /// <summary>
        /// Deletes a CostCenter from database.
        /// </summary>
        /// <param name="id">Guid representing CostCenter id</param>
        /// <returns>Array of CostCenter entity</returns>
        CostCenter[] DeleteCostCenters(string id);
    }
}
