using System;
using System.Collections.Generic;
using System.Text;

namespace CygnetHRD.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}
