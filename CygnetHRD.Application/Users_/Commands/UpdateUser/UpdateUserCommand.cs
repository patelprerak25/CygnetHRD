using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CygnetHRD.Application.Interfaces;
using CygnetHRD.Domain.DBModel;
using MediatR;

namespace CygnetHRD.Application.Users_.Commands.UpdateUser
{
    /// <summary>
    /// This class define request input and output object which send to the handler for process.
    /// </summary>
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public Users Users { get; set; }
    }

    /// <summary>
    /// This class use for handle Update User request.
    /// The send method of MediatR sends the object to this class for process.
    /// </summary>
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Public constructor to initialize UnitOfWork instance.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Method to handle the request.
        /// </summary>
        /// <param name="request">CreateUserCommand</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {          
            return await Task.Run(() => this.unitOfWork.Users.Update(request.Users));           
        }
    }
}
