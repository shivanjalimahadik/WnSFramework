//-----------------------------------------------------------------------
// <copyright file="BusinessUnitRepository.cs" company="SA Technology">
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
    public class BusinessUnitRepository : IBusinessUnitRepository
    {
        /// <summary>
        /// IBusinessUnitDA variable
        /// </summary>
        private IBusinessUnitDA _BusinessUnitDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public BusinessUnitRepository(IBusinessUnitDA businessUnitDA)
        {
            _BusinessUnitDA = businessUnitDA;
        }

        /// <summary>
        /// Add BusinessUnit
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(BusinessUnit[] businessUnits)
        {
            await _BusinessUnitDA.AddBusinessUnitAsync(businessUnits);
        }

        /// <summary>
        /// Add BusinessUnit
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit</param>
        /// <returns>Array of BusinessUnit</returns>
        public BusinessUnit[] Add(BusinessUnit[] businessUnits)
        {
            return _BusinessUnitDA.AddBusinessUnits(businessUnits);
        }

        /// <summary>
        /// Get BusinessUnit
        /// </summary>
        /// <param name="id">BusinessUnit id</param>
        /// <returns>BusinessUnit entity</returns>
        public BusinessUnit Get(string id)
        {
            return _BusinessUnitDA.GetBusinessUnit(id);
        }

        /// <summary>
        /// Get BusinessUnit collection
        /// </summary>
        /// <param name="ids">Array of BusinessUnit id</param>
        /// <returns>Dictionary based BusinessUnit collection</returns>
        public Dictionary<string, BusinessUnit> Get(string[] ids)
        {
            return _BusinessUnitDA.GetBusinessUnits(ids);
        }

        /// <summary>
        /// Get BusinessUnit
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of BusinessUnit</returns>
        public BusinessUnit[] Get(IEnumerable<Guid?> ids)
        {
            return _BusinessUnitDA.GetBusinessUnits(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of BusinessUnit</returns>
        public BusinessUnit[] GetAll()
        {
            return _BusinessUnitDA.GetAll();
        }

        /// <summary>
        /// Get BusinessUnit
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of BusinessUnit</returns>
        public BusinessUnit[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _BusinessUnitDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update BusinessUnit
        /// </summary>
        /// <param name="businessUnits">Array of BusinessUnit</param>
        /// <returns>Array of BusinessUnit</returns>
        public BusinessUnit[] Update(BusinessUnit[] businessUnits)
        {
            return _BusinessUnitDA.UpdateBusinessUnits(businessUnits);
        }

        /// <summary>
        /// Delete BusinessUnit
        /// </summary>
        /// <param name="id">BusinessUnit id</param>
        /// <returns>Array of BusinessUnit</returns>
        public BusinessUnit[] Delete(string id)
        {
            return _BusinessUnitDA.DeleteBusinessUnits(id);
        }
    }
}
