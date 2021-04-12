using CygnetHRD.Application.Interfaces;
using CygnetHRD.Domain.DBModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CygnetHRD.Application.Users_.Commands.CreateUser
{
    /// <summary>
    /// This class define request input and output object which send to the handler for process.
    /// </summary>
    public class CreateUserCommand : IRequest<object>
    {
        /// <summary>
        /// Get or Set User object.
        /// </summary>
        public Users Users { get; set; }
    }

    /// <summary>
    /// This class use for handle Create User request.
    /// The send method of MediatR sends the object to this class for process.
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, object>
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Public constructor to initialize UnitOfWork instance.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Method to handle the request.
        /// </summary>
        /// <param name="request">CreateUserCommand</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public async Task<object> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await Task.Run(() => this.unitOfWork.Users.Add(request.Users));
            return result;
        }
    }
}
