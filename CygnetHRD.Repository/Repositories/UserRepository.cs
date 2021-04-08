using CygnetHRD.Application.Interfaces;
using CygnetHRD.Entity.DBModel;
using Dapper;
using CygnetHRD.Persistence;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygnetHRD.Repositories
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
        public object Add(Users entity)
        {
            var result = this.connection.Insert(entity);
            return result;
        }

        /// <summary>
        /// Method for delete User endity by id.
        /// </summary>
        /// <param name="id">object</param>
        /// <returns>int</returns>
        public bool Delete(object id)
        {
            Users users = this.connection.Get<Users>(id);
            var result = this.connection.Delete<Users>(users);
            return result;
        }

        /// <summary>
        /// Method for get all User entities.
        /// </summary>
        /// <returns>List of User</returns>
        public IReadOnlyList<Users> GetAll()
        {
            var result = this.connection.GetList<Users>();
            return result.ToList();
        }

        /// <summary>
        /// Method for get User entity by it's id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>User</returns>
        public Users GetById(object id)
        {
            var result = this.connection.Get<Users>(id);
            return result;
        }

        /// <summary>
        /// Method for update User entity.
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns>int</returns>
        public bool Update(Users entity)
        {
            var result = this.connection.Update(entity);
            return result;
        }
    }
}


