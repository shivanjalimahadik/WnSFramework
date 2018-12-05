//-----------------------------------------------------------------------
// <copyright file="IBusinessUnitDA.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    using Entities.Wrappers;

    /// <summary>
    /// IBusinessUnit interface. Used to define all abstract methods of BusinessUnit entity.
    /// </summary>
    public interface IBusinessUnitDA
    {
        /// <summary>
        /// Adds BusinessUnit entity to database asynchronously.
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddBusinessUnitAsync(BusinessUnit[] businessUnits);

        /// <summary>
        /// Adds BusinessUnit entity to database.
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit</param>
        /// <returns>Added array of BusinessUnit</returns>
        BusinessUnit[] AddBusinessUnits(BusinessUnit[] businessUnits);

        /// <summary>
        /// Gets a single BusinessUnit based on id.
        /// </summary>
        /// <param name="id">BusinessUnit Id</param>
        /// <returns>BusinessUnit entity.</returns>
        BusinessUnit GetBusinessUnit(string id);

        /// <summary>
        /// Gets a BusinessUnit in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of BusinessUnit id</param>
        /// <returns>Dictionary of BusinessUnit entity</returns>
        Dictionary<string, BusinessUnit> GetBusinessUnits(string[] ids);

        /// <summary>
        /// Gets a BusinessUnit collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of BusinessUnit id</param>
        /// <returns>Array of BusinessUnit entity</returns>
        BusinessUnit[] GetBusinessUnits(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all BusinessUnits
        /// </summary>
        /// <returns>Array of BusinessUnit entity</returns>
        BusinessUnit[] GetAll();

        /// <summary>
        /// Gets a BusinessUnit collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of BusinessUnit id</param>
        /// <returns>Array of BusinessUnit entity</returns>
        BusinessUnit[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a BusinessUnit entity in database
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit</param>
        /// <returns>Updated array of BusinessUnit entity</returns>
        BusinessUnit[] UpdateBusinessUnits(BusinessUnit[] businessUnits);

        /// <summary>
        /// Deletes a BusinessUnit from database.
        /// </summary>
        /// <param name="id">Guid representing BusinessUnit id</param>
        /// <returns>Array of BusinessUnit entity</returns>
        BusinessUnit[] DeleteBusinessUnits(string id);

        /// <summary>
        /// Get all Business Units
        /// </summary>
        /// <returns></returns>
        BUWrapper[] GetAllBusinessUnits();
    }
}
