//-----------------------------------------------------------------------
// <copyright file="IWorkflowRepository.cs" company="SA Technology">
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
    /// Workflow interface 
    /// </summary>
    public interface IWorkflowRepository
    {
        /// <summary>
        /// Add Workflow
        /// </summary>
        /// <param name="workflows">Array of Workflow</param>
        /// <returns></returns>
        Task AddAsync(Workflow[] workflows);

        /// <summary>
        /// Add Workflow
        /// </summary>
        /// <param name="workflows">Array of Workflow</param>
        /// <returns>Array of Workflow</returns>
        Workflow[] Add(Workflow[] workflows);

        /// <summary>
        /// Get Workflow
        /// </summary>
        /// <param name="id">Workflow id</param>
        /// <returns>Workflow proces</returns>
        Workflow Get(string id);

        /// <summary>
        /// Get Workflow collection
        /// </summary>
        /// <param name="ids">Array of Workflow id</param>
        /// <returns>Dictionary based Workflow collection</returns>
        Dictionary<string, Workflow> Get(string[] ids);

        /// <summary>
        /// Get Workflow
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Workflow</returns>
        Workflow[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of Workflow</returns>
        Workflow[] GetAll();

        /// <summary>
        /// Get Workflow
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Workflow</returns>
        Workflow[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update Workflow
        /// </summary>
        /// <param name="workflows">Array of Workflow</param>
        /// <returns>Array of Workflow</returns>
        Workflow[] Update(Workflow[] workflows);

        /// <summary>
        /// Delete Workflow
        /// </summary>
        /// <param name="id">Workflow id</param>
        /// <returns>Array of Workflow</returns>
        Workflow[] Delete(string id);
    }
}
