using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CygnetHRD.Application.Interfaces;
using CygnetHRD.Application.Users_.Commands.CreateUser;
using CygnetHRD.Application.Users_.Commands.DeleteUser;
using CygnetHRD.Application.Users_.Commands.UpdateUser;
using CygnetHRD.Application.Users_.Queries.GetAllUser;
using CygnetHRD.Application.Users_.Queries.GetUser;
using CygnetHRD.Entity.DBModel;
using CygnetHRD.Entity.Entities;
using KendoGridParameterParser;
using KendoGridParameterParser.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CygnetHRD.WebAPI.Controllers
{
    /// <summary>
    /// This is the User controller class which having all CRUD method related to User entity.
    /// </summary>
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// Public constructor to initialize UnitOfWork instance.
        /// </summary>
        /// <param name="mapper">IMapper</param>
        /// <param name="mediator">IMediator</param>
        public UserController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        //[HttpGet]
        //public ActionResult Index(DataSourceRequest request)
        //{
        //    var expression = DataSourceFilterMapHelper.RecursiveFilterExpressionBuilder(request.Filter);
        //    var sorter = DataSourceSortMapHelper.SortExpressionBuilder(request.Sort);
        //    AggregateResult aggr = DataSourceAggregateMapHelper.AggregateExpressionBuilder(request.Aggregate);

        //    var data = this.unitOfWork.Users.GetAll();
        //    if (data.Count() > 0)
        //        return this.Ok(mapper.Map<List<User>>(data));
        //    else
        //        return this.NotFound("User doesn't exist.");
        //}

        /// <summary>
        /// This method use for featching all Users.
        /// </summary>
        /// <returns>List of User.</returns>
        /// <example>GET ../api/user</example>
        /// <example>GET ../api/user/all</example>
        [HttpGet(Name = "GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var data = await Task.Run(() => mediator.Send(new GetAllUserQuery() { }));
            if (data.Count() > 0)
                return this.Ok(mapper.Map<List<User>>(data));
            else
                return this.NotFound("User doesn't exist.");
        }

        /// <summary>
        /// API call for get User entity by ID.
        /// </summary>
        /// <param name="id">int : User id.</param>
        /// <returns>User : User entity object.</returns>
        /// <example>GET ../api/user/2 .</example>
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await mediator.Send(new GetUserByIdQuery() { Id = id });
            if (data == null)
            {
                return this.NotFound("User doesn't exist.");
            }

            return this.Ok(mapper.Map<User>(data));
        }

        /// <summary>
        /// API call for add new User entity.
        /// </summary>
        /// <param name="user">User : User enity object.</param>
        /// <returns>int : 1 for success and 0 for fail add status.</returns>
        /// <example>POST ../api/user</example>
        /// <example>POST ../api/user/create</example>
        /// <example>POST ../api/user/register</example>
        [HttpPost(Name = "Add")]
        [HttpPost("create", Name = "Create")]
        [HttpPost("register", Name = "Register")]
        public async Task<IActionResult> Add(User user)
        {
            if (user != null)
            {
                var data = await mediator.Send(new CreateUserCommand() { Users = mapper.Map<Users>(user) });
                return this.Ok(data);
            }
            else
                return this.BadRequest();
        }

        /// <summary>
        /// API call for delete User entity by ID.
        /// </summary>
        /// <param name="id">int : User id.</param>
        /// <returns>int : 1 for success and 0 for fail delete status.</returns>
        /// <example>DELETE ../api/user/1</example>
        /// <example>DELETE ../api/user/remove/1</example>
        [HttpDelete("{id}", Name = "Delete")]
        [HttpDelete("remove/{id}", Name = "Remove")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var data = await mediator.Send(new DeleteUserCommand() { Id = id});
                return this.Ok(data);
            }
            else
                return this.NotFound();
        }

        /// <summary>
        /// API call for update User entity.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="user">User</param>
        /// <returns>int : 1 for success and 0 for fail update status.</returns>
        /// <example>PUT ../api/user</example>
        /// <example>PUT ../api/user/modify</example>
        [HttpPut("{id}", Name = "Update")]
        [HttpPut("modify/{id}", Name = "Modify")]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id > 0 && user != null)
            {
                var currentUser = mapper.Map<Users>(user);
                if (currentUser != null)
                {
                    currentUser.Id = id;

                    var data = await mediator.Send(new UpdateUserCommand() { Users = currentUser });
                    return this.Ok(data);
                }
                else
                    return this.BadRequest();
            }
            else
                return this.BadRequest();
        }
    }
}
