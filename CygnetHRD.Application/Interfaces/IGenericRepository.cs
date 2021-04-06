using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CygnetHRD.Application.Interfaces
{
    /// <summary>
    /// This is the generic repository interface for define common method for implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Get entity object by id.
        /// </summary>
        /// <param name="id">object</param>
        /// <returns>Entity object</returns>
        Task<T> GetByIdAsync(object id);

        /// <summary>
        /// Get list of all entity objects.
        /// </summary>
        /// <returns>IReadOnlyList<T></returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Add new entity object into database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entity object</returns>
        Task<int?> AddAsync(T entity);

        /// <summary>
        /// Update entity into database.
        /// </summary>
        /// <param name="id">object</param>
        /// <param name="entity">T</param>
        /// <returns>int</returns>
        Task<int?> UpdateAsync(T entity);

        /// <summary>
        /// Delete entity from database as per given id.
        /// </summary>
        /// <param name="id">object</param>
        /// <returns>int</returns>
        Task<int?> DeleteAsync(object id);
    }
}
