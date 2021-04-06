using CygnetHRD.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CygnetHRD.Application.Interfaces
{
    /// <summary>
    /// Create IUserRepository interface using IGenericRepository for User entity.
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
