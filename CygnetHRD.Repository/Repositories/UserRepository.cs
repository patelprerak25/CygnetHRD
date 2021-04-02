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
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;

        public UserRepository(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        public async Task<int?> AddAsync(User entity)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.InsertAsync(entity);
                return result;
            }
        }

        public async Task<int?> DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.DeleteAsync<User>(id);
                return result;
            }
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.GetListAsync<User>();
                return result.ToList();
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.GetAsync<User>(id);
                return result;
            }
        }

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
