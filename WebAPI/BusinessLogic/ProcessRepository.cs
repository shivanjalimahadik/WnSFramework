//-----------------------------------------------------------------------
// <copyright file="ProcessRepository.cs" company="SA Technology">
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
    using Entities.Wrappers;

    public class ProcessRepository : IProcessRepository
    {
        /// <summary>
        /// IProcessDA variable
        /// </summary>
        private IProcessDA _ProcessDA;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessRepository" /> class.
        /// </summary>
        /// <param name="sqlDataBaseSettings">SQL database settings</param>
        public ProcessRepository(IProcessDA procesDA)
        {
            _ProcessDA = procesDA;
        }

        /// <summary>
        /// Add Process
        /// </summary>
        /// <param name="process">Array of Process</param>
        /// <returns>Asynchronous task</returns>
        public async Task AddAsync(Process[] process)
        {
            await _ProcessDA.AddProcessAsync(process);
        }

        /// <summary>
        /// Add Process
        /// </summary>
        /// <param name="process">Array of Process</param>
        /// <returns>Array of Process</returns>
        public Process[] Add(Process[] process)
        {
            return _ProcessDA.AddProcesss(process);
        }

        /// <summary>
        /// Get Process
        /// </summary>
        /// <param name="id">Process id</param>
        /// <returns>Process proces</returns>
        public Process Get(string id)
        {
            return _ProcessDA.GetProcess(id);
        }

        /// <summary>
        /// Get Process collection
        /// </summary>
        /// <param name="ids">Array of Process id</param>
        /// <returns>Dictionary based Process collection</returns>
        public Dictionary<string, Process> Get(string[] ids)
        {
            return _ProcessDA.GetProcesss(ids);
        }

        /// <summary>
        /// Get Process
        /// </summary>
        /// <param name="ids">IEnumerable collection of nullable Guids</param>
        /// <returns>Array of Process</returns>
        public Process[] Get(IEnumerable<Guid?> ids)
        {
            return _ProcessDA.GetProcesss(ids);
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>Array of Process</returns>
        public Process[] GetAll()
        {
            return _ProcessDA.GetAll();
        }

        /// <summary>
        /// Get Process
        /// </summary>
        /// <param name="Ids">IEnumerable collection of Guids</param>
        /// <returns>Array of Process</returns>
        public Process[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _ProcessDA.GetByIds(Ids);
        }

        /// <summary>
        /// Update Process
        /// </summary>
        /// <param name="process">Array of Process</param>
        /// <returns>Array of Process</returns>
        public Process[] Update(Process[] process)
        {
            return _ProcessDA.UpdateProcesss(process);
        }

        /// <summary>
        /// Delete Process
        /// </summary>
        /// <param name="id">Process id</param>
        /// <returns>Array of Process</returns>
        public Process[] Delete(string id)
        {
            return _ProcessDA.DeleteProcesss(id);
        }

        public ProcessWrapper[] GetAllProcess()
        {
            return _ProcessDA.GetAllProcess();
        }
    }
}
