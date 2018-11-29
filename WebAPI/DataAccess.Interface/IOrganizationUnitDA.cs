//-----------------------------------------------------------------------
// <copyright file="IOrganizationUnitDA.cs" company="SA Technology">
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
    /// IOrganizationUnit interface. Used to define all abstract methods of OrganizationUnit organizationUnit.
    /// </summary>
    public interface IOrganizationUnitDA
    {
        /// <summary>
        /// Adds OrganizationUnit organizationUnit to database asynchronously.
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit.</param>
        /// <returns>Asynchronous Task</returns>
        Task AddOrganizationUnitAsync(OrganizationUnit[] organizationUnits);

        /// <summary>
        /// Adds OrganizationUnit organizationUnit to database.
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit</param>
        /// <returns>Added array of OrganizationUnit</returns>
        OrganizationUnit[] AddOrganizationUnits(OrganizationUnit[] organizationUnits);

        /// <summary>
        /// Gets a single OrganizationUnit based on id.
        /// </summary>
        /// <param name="id">OrganizationUnit Id</param>
        /// <returns>OrganizationUnit organizationUnit.</returns>
        OrganizationUnit GetOrganizationUnit(string id);

        /// <summary>
        /// Gets a OrganizationUnit in Key-Value dictionary collection
        /// </summary>
        /// <param name="ids">Array of OrganizationUnit id</param>
        /// <returns>Dictionary of OrganizationUnit organizationUnit</returns>
        Dictionary<string, OrganizationUnit> GetOrganizationUnits(string[] ids);

        /// <summary>
        /// Gets a OrganizationUnit collection based on ids. Ids can be nullable Guid
        /// </summary>
        /// <param name="ids">IEnumerable collection of OrganizationUnit id</param>
        /// <returns>Array of OrganizationUnit organizationUnit</returns>
        OrganizationUnit[] GetOrganizationUnits(IEnumerable<Guid?> ids);

        /// <summary>
        /// Gets all OrganizationUnits
        /// </summary>
        /// <returns>Array of OrganizationUnit organizationUnit</returns>
        OrganizationUnit[] GetAll();

        /// <summary>
        /// Gets a OrganizationUnit collection based on ids
        /// </summary>
        /// <param name="ids">IEnumerable collection of OrganizationUnit id</param>
        /// <returns>Array of OrganizationUnit organizationUnit</returns>
        OrganizationUnit[] GetByIds(IEnumerable<Guid> ids);

        /// <summary>
        /// Updates a OrganizationUnit organizationUnit in database
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit</param>
        /// <returns>Updated array of OrganizationUnit organizationUnit</returns>
        OrganizationUnit[] UpdateOrganizationUnits(OrganizationUnit[] organizationUnits);

        /// <summary>
        /// Deletes a OrganizationUnit from database.
        /// </summary>
        /// <param name="id">Guid representing OrganizationUnit id</param>
        /// <returns>Array of OrganizationUnit organizationUnit</returns>
        OrganizationUnit[] DeleteOrganizationUnits(string id);

        /// <summary>
        /// Get all Organization Units
        /// </summary>
        /// <returns></returns>
        OUWrapper[] GetAllOrganizationUnits();
    }
}
