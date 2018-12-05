//-----------------------------------------------------------------------
// <copyright file="IProcessRepository.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BusinessLogic.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    using Entities.Wrappers;

    /// <summary>
    /// Process interface 
    /// </summary>
    public interface IProcessRepository
    {
        /// <summary>
        /// Add Process
        /// </summary>
        /// <param name="process">Array of Process</param>
        /// <returns></returns>
        Task AddAsync(Process[] process);

        /// <summary>
        /// Add Process
        /// </summary>
        /// <param name="process">Array of Process</param>
        /// <returns>Array of Process</returns>
        Process[] Add(Process[] process);

        /// <summary>
        /// Get Process
        /// </summary>
        /// <param name="id">Process id</param>
        /// <returns>Process proces</returns>
        Process Get(string id);

        /// <summary>
        /// Get Process collection
        /// </summary>
        /// <param name="ids">Array of Process id</param>
        /// <returns>Dictionary based Process collection</returns>
        Dictionary<string, Process> Get(string[] ids);

        /// <summary>
        /// Get Process
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Process</returns>
        Process[] Get(IEnumerable<Guid?> ids);

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of Process</returns>
        Process[] GetAll();

        /// <summary>
        /// Get Process
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Process</returns>
        Process[] GetByIds(IEnumerable<Guid> Ids);

        /// <summary>
        /// Update Process
        /// </summary>
        /// <param name="process">Array of Process</param>
        /// <returns>Array of Process</returns>
        Process[] Update(Process[] process);

        /// <summary>
        /// Delete Process
        /// </summary>
        /// <param name="id">Process id</param>
        /// <returns>Array of Process</returns>
        Process[] Delete(string id);

        /// <summary>
        /// Get all Process
        /// </summary>
        /// <returns></returns>
        ProcessWrapper[] GetAllProcess();
    }
}
