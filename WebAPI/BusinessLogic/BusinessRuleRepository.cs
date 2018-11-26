//-----------------------------------------------------------------------
// <copyright file="BusinessRuleRepository.cs" company="SA Technology">
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
    public class BusinessRuleRepository : IBusinessRuleRepository
    {
        /// <summary>
        /// IBusinessRuleDA variable
        /// </summary>
        private IBusinessRuleDA _BusinessRuleDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRuleRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public BusinessRuleRepository(IBusinessRuleDA businessRuleDA)
        {
            _BusinessRuleDA = businessRuleDA;
        }

        /// <summary>
        /// Add BusinessRule
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(BusinessRule[] businessRules)
        {
            await _BusinessRuleDA.AddBusinessRuleAsync(businessRules);
        }

        /// <summary>
        /// Add BusinessRule
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule</param>
        /// <returns>Array of BusinessRule</returns>
        public BusinessRule[] Add(BusinessRule[] businessRules)
        {
            return _BusinessRuleDA.AddBusinessRules(businessRules);
        }

        /// <summary>
        /// Get BusinessRule
        /// </summary>
        /// <param name="id">BusinessRule id</param>
        /// <returns>BusinessRule entity</returns>
        public BusinessRule Get(string id)
        {
            return _BusinessRuleDA.GetBusinessRule(id);
        }

        /// <summary>
        /// Get BusinessRule collection
        /// </summary>
        /// <param name="ids">Array of BusinessRule id</param>
        /// <returns>Dictionary based BusinessRule collection</returns>
        public Dictionary<string, BusinessRule> Get(string[] ids)
        {
            return _BusinessRuleDA.GetBusinessRules(ids);
        }

        /// <summary>
        /// Get BusinessRule
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of BusinessRule</returns>
        public BusinessRule[] Get(IEnumerable<Guid?> ids)
        {
            return _BusinessRuleDA.GetBusinessRules(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of BusinessRule</returns>
        public BusinessRule[] GetAll()
        {
            return _BusinessRuleDA.GetAll();
        }

        /// <summary>
        /// Get BusinessRule
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of BusinessRule</returns>
        public BusinessRule[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _BusinessRuleDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update BusinessRule
        /// </summary>
        /// <param name="businessRules">Array of BusinessRule</param>
        /// <returns>Array of BusinessRule</returns>
        public BusinessRule[] Update(BusinessRule[] businessRules)
        {
            return _BusinessRuleDA.UpdateBusinessRules(businessRules);
        }

        /// <summary>
        /// Delete BusinessRule
        /// </summary>
        /// <param name="id">BusinessRule id</param>
        /// <returns>Array of BusinessRule</returns>
        public BusinessRule[] Delete(string id)
        {
            return _BusinessRuleDA.DeleteBusinessRules(id);
        }
    }
}
