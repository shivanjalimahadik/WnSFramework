//-----------------------------------------------------------------------
// <copyright file="IOrganizationUnitRepository.cs" company="SA Technology">
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
    /// OrganizationUnit interface 
    /// </summary>
    public interface IOrganizationUnitRepository
    {
        /// <summary>
        /// Add OrganizationUnit
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit</param>
        /// <returns></returns>
        Task AddAsync(OrganizationUnit[] organizationUnits);

        /// <summary>
        /// Add OrganizationUnit
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit</param>
        /// <returns>Array of OrganizationUnit</returns>
        OrganizationUnit[] Add(OrganizationUnit[] organizationUnits);

        /// <summary>
        /// Get OrganizationUnit
        /// </summary>
        /// <param name="id">OrganizationUnit id</param>
        /// <returns>OrganizationUnit organizationUnit</returns>
        OrganizationUnit Get(string id);

        /// <summary>
        /// Get OrganizationUnit collection
        /// </summary>
        /// <param name="ids">Array of OrganizationUnit id</param>
        /// <returns>Dictionary based OrganizationUnit collection</returns>
        Dictionary<string, OrganizationUnit> Get(string[] ids);

        /// <summary>
        /// Get OrganizationUnit
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of OrganizationUnit</returns>
        OrganizationUnit[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of OrganizationUnit</returns>
        OrganizationUnit[] GetAll();

        /// <summary>
        /// Get OrganizationUnit
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of OrganizationUnit</returns>
        OrganizationUnit[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update OrganizationUnit
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit</param>
        /// <returns>Array of OrganizationUnit</returns>
        OrganizationUnit[] Update(OrganizationUnit[] organizationUnits);

        /// <summary>
        /// Delete OrganizationUnit
        /// </summary>
        /// <param name="id">OrganizationUnit id</param>
        /// <returns>Array of OrganizationUnit</returns>
        OrganizationUnit[] Delete(string id);
    }
}
