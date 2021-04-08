using CygnetHRD.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygnetHRD.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository) // need to implement collection for repository
        {
            Users = userRepository;
        }

        public IUserRepository Users { get; }
    }
}
