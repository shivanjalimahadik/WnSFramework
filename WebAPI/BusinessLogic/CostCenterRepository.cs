//-----------------------------------------------------------------------
// <copyright file="CostCenterRepository.cs" company="SA Technology">
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
    public class CostCenterRepository : ICostCenterRepository
    {
        /// <summary>
        /// ICostCenterDA variable
        /// </summary>
        private ICostCenterDA _CostCenterDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="CostCenterRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public CostCenterRepository(ICostCenterDA costCenterDA)
        {
            _CostCenterDA = costCenterDA;
        }

        /// <summary>
        /// Add CostCenter
        /// </summary>
        /// <param name="costCenters">Array of CostCenter</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(CostCenter[] costCenters)
        {
            await _CostCenterDA.AddCostCenterAsync(costCenters);
        }

        /// <summary>
        /// Add CostCenter
        /// </summary>
        /// <param name="costCenters">Array of CostCenter</param>
        /// <returns>Array of CostCenter</returns>
        public CostCenter[] Add(CostCenter[] costCenters)
        {
            return _CostCenterDA.AddCostCenters(costCenters);
        }

        /// <summary>
        /// Get CostCenter
        /// </summary>
        /// <param name="id">CostCenter id</param>
        /// <returns>CostCenter entity</returns>
        public CostCenter Get(string id)
        {
            return _CostCenterDA.GetCostCenter(id);
        }

        /// <summary>
        /// Get CostCenter collection
        /// </summary>
        /// <param name="ids">Array of CostCenter id</param>
        /// <returns>Dictionary based CostCenter collection</returns>
        public Dictionary<string, CostCenter> Get(string[] ids)
        {
            return _CostCenterDA.GetCostCenters(ids);
        }

        /// <summary>
        /// Get CostCenter
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of CostCenter</returns>
        public CostCenter[] Get(IEnumerable<Guid?> ids)
        {
            return _CostCenterDA.GetCostCenters(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of CostCenter</returns>
        public CostCenter[] GetAll()
        {
            return _CostCenterDA.GetAll();
        }

        /// <summary>
        /// Get CostCenter
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of CostCenter</returns>
        public CostCenter[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _CostCenterDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update CostCenter
        /// </summary>
        /// <param name="costCenters">Array of CostCenter</param>
        /// <returns>Array of CostCenter</returns>
        public CostCenter[] Update(CostCenter[] costCenters)
        {
            return _CostCenterDA.UpdateCostCenters(costCenters);
        }

        /// <summary>
        /// Delete CostCenter
        /// </summary>
        /// <param name="id">CostCenter id</param>
        /// <returns>Array of CostCenter</returns>
        public CostCenter[] Delete(string id)
        {
            return _CostCenterDA.DeleteCostCenters(id);
        }
    }
}
