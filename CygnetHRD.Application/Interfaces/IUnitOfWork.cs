using System;
using System.Collections.Generic;
using System.Text;

namespace CygnetHRD.Application.Interfaces
{
    /// <summary>
    /// This is the Unit of Work interface for define common method for access.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        IUserRepository Users { get; }
    }
}
