using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CygnetHRD.Application.Interfaces;
using CygnetHRD.Entity.DBModel;
using MediatR;

namespace CygnetHRD.Application.Users_.Queries.GetAllUser
{
    /// <summary>
    /// This class define request input and output object which send to the handler for process.
    /// </summary>
    public class GetAllUserQuery : IRequest<IReadOnlyList<Users>>
    {
    }

    /// <summary>
    /// This class use for handle Get All User request.
    /// The send method of MediatR sends the object to this class for process.
    /// </summary>
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IReadOnlyList<Users>>
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Public constructor to initialize UnitOfWork instance.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        /// <summary>
        public GetAllUserQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
             
        /// Method to handle the request.
        /// </summary>
        /// <param name="request">CreateUserCommand</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public async Task<IReadOnlyList<Users>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var data = await Task.Run(() => this.unitOfWork.Users.GetAll());
            return (IReadOnlyList<Users>)data;
        }
    }
}
