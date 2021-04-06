using CygnetHRD.Application.Interfaces;
using CygnetHRD.Entity.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CygnetHRD.Infrastructure.Repositories
{
    /// <summary>
    /// Class for User repository implemenation having CRUD opration using Dapper.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection connection;

        /// <summary>
        /// UserRepository constructor with IConfiguration parameter.
        /// </summary>
        /// <param name="_connection">IDbConnection</param>
        public UserRepository(IDbConnection _connection)
        {
            this.connection = _connection;
        }

        /// <summary>
        /// Method for add User entity.
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns>int</returns>
        public async Task<int?> AddAsync(User entity)
        {
            var result = await this.connection.InsertAsync(entity);
            return result;
        }

        /// <summary>
        /// Method for delete User endity by id.
        /// </summary>
        /// <param name="id">object</param>
        /// <returns>int</returns>
        public async Task<int?> DeleteAsync(object id)
        {
            var result = await this.connection.DeleteAsync<User>(id);
            return result;
        }

        /// <summary>
        /// Method for get all User entities.
        /// </summary>
        /// <returns>List of User</returns>
        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var result = await this.connection.GetListAsync<User>();
            return result.ToList();
        }

        /// <summary>
        /// Method for get User entity by it's id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>User</returns>
        public async Task<User> GetByIdAsync(object id)
        {
            var result = await this.connection.GetAsync<User>(id);
            return result;
        }

        /// <summary>
        /// Method for update User entity.
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns>int</returns>
        public async Task<int?> UpdateAsync(User entity)
        {
            var result = await this.connection.UpdateAsync(entity);
            return result;
        }
    }
}


