using CygnetHRD.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CygnetHRD.Application.Users_.Commands.DeleteUser
{
    /// <summary>
    /// This class define request input and output object which send to the handler for process.
    /// </summary>
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// This class use for handle Delete User request.
    /// The send method of MediatR sends the object to this class for process.
    /// </summary>
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Public constructor to initialize UnitOfWork instance.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Method to handle the request.
        /// </summary>
        /// <param name="request">CreateUserCommand</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => this.unitOfWork.Users.Delete(request.Id)); ;
        }
    }
}
