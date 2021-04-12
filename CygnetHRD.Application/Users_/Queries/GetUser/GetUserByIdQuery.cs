using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CygnetHRD.Application.Interfaces;
using CygnetHRD.Domain.DBModel;
using MediatR;

namespace CygnetHRD.Application.Users_.Queries.GetUser
{
    /// <summary>
 /// This class define request input and output object which send to the handler for process.
 /// </summary>
    public class GetUserByIdQuery : IRequest<Users>
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// This class use for handle Get User By Id request.
    /// The send method of MediatR sends the object to this class for process.
    /// </summary>
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Users>
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Public constructor to initialize UnitOfWork instance.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// Method to handle the request.
        /// </summary>
        /// <param name="request">CreateUserCommand</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public async Task<Users> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await Task.Run(() => this.unitOfWork.Users.GetById(request.Id));
            return (Users)data;
        }
    }
}
