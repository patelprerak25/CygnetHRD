using CygnetHRD.Application.Interfaces;
using CygnetHRD.Entity.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        private readonly IConfiguration configuration;

        /// <summary>
        /// UserRepository constructor with IConfiguration parameter.
        /// </summary>
        /// <param name="_configuration">IConfiguration</param>
        public UserRepository(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        /// <summary>
        /// Method for add User entity.
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns>int</returns>
        public async Task<int?> AddAsync(User entity)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.InsertAsync(entity);
                return result;
            }
        }

        /// <summary>
        /// Method for delete User endity by id.
        /// </summary>
        /// <param name="id">object</param>
        /// <returns>int</returns>
        public async Task<int?> DeleteAsync(object id)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.DeleteAsync<User>(id);
                return result;
            }
        }

        /// <summary>
        /// Method for get all User entities.
        /// </summary>
        /// <returns>List of User</returns>
        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.GetListAsync<User>();
                return result.ToList();
            }
        }

        /// <summary>
        /// Method for get User entity by it's id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>User</returns>
        public async Task<User> GetByIdAsync(object id)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.GetAsync<User>(id);
                return result;
            }
        }

        /// <summary>
        /// Method for update User entity.
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns>int</returns>
        public async Task<int?> UpdateAsync(User entity)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.UpdateAsync(entity);
                return result;
            }
        }
    }
}
