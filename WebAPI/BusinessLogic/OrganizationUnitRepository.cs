//-----------------------------------------------------------------------
// <copyright file="OrganizationUnitRepository.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLogic.Interface;
    using DataAccess.Interface;
    using Entities;
    public class OrganizationUnitRepository : IOrganizationUnitRepository
    {
        /// <summary>
        /// IOrganizationUnitDA variable
        /// </summary>
        private IOrganizationUnitDA _OrganizationUnitDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationUnitRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public OrganizationUnitRepository(IOrganizationUnitDA organizationUnitDA)
        {
            _OrganizationUnitDA = organizationUnitDA;
        }

        /// <summary>
        /// Add OrganizationUnit
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(OrganizationUnit[] organizationUnits)
        {
            await _OrganizationUnitDA.AddOrganizationUnitAsync(organizationUnits);
        }

        /// <summary>
        /// Add OrganizationUnit
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit</param>
        /// <returns>Array of OrganizationUnit</returns>
        public OrganizationUnit[] Add(OrganizationUnit[] organizationUnits)
        {
            return _OrganizationUnitDA.AddOrganizationUnits(organizationUnits);
        }

        /// <summary>
        /// Get OrganizationUnit
        /// </summary>
        /// <param name="id">OrganizationUnit id</param>
        /// <returns>OrganizationUnit organizationUnit</returns>
        public OrganizationUnit Get(string id)
        {
            return _OrganizationUnitDA.GetOrganizationUnit(id);
        }

        /// <summary>
        /// Get OrganizationUnit collection
        /// </summary>
        /// <param name="ids">Array of OrganizationUnit id</param>
        /// <returns>Dictionary based OrganizationUnit collection</returns>
        public Dictionary<string, OrganizationUnit> Get(string[] ids)
        {
            return _OrganizationUnitDA.GetOrganizationUnits(ids);
        }

        /// <summary>
        /// Get OrganizationUnit
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of OrganizationUnit</returns>
        public OrganizationUnit[] Get(IEnumerable<Guid?> ids)
        {
            return _OrganizationUnitDA.GetOrganizationUnits(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of OrganizationUnit</returns>
        public OrganizationUnit[] GetAll()
        {
            return _OrganizationUnitDA.GetAll();
        }

        /// <summary>
        /// Get OrganizationUnit
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of OrganizationUnit</returns>
        public OrganizationUnit[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _OrganizationUnitDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update OrganizationUnit
        /// </summary>
        /// <param name="organizationUnits">Array of OrganizationUnit</param>
        /// <returns>Array of OrganizationUnit</returns>
        public OrganizationUnit[] Update(OrganizationUnit[] organizationUnits)
        {
            return _OrganizationUnitDA.UpdateOrganizationUnits(organizationUnits);
        }

        /// <summary>
        /// Delete OrganizationUnit
        /// </summary>
        /// <param name="id">OrganizationUnit id</param>
        /// <returns>Array of OrganizationUnit</returns>
        public OrganizationUnit[] Delete(string id)
        {
            return _OrganizationUnitDA.DeleteOrganizationUnits(id);
        }
    }
}
