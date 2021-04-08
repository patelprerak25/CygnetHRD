using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CygnetHRD.Application.Interfaces;
using CygnetHRD.Entity.DBModel;
using CygnetHRD.Entity.Entities;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// Public constructor to initialize UnitOfWork instance.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

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
            var data = await Task.Run(() => this.unitOfWork.Users.GetAll());
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
            var data = await Task.Run(() => this.unitOfWork.Users.GetById(id));
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
                var data = await Task.Run(() => this.unitOfWork.Users.Add(mapper.Map<Users>(user)));
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
        /// <example>DELETE ../api/user/delete/1</example>
        [HttpDelete("{id}", Name = "Delete")]
        [HttpDelete("remove/{id}", Name = "Remove")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var data = await Task.Run(() => this.unitOfWork.Users.Delete(id));
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
        /// <example>PUT ../api/user/update</example>
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

                    var data = await Task.Run(() => this.unitOfWork.Users.Update(currentUser));
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
