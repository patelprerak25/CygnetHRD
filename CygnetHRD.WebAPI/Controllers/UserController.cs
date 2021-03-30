﻿namespace CygnetHRD.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CygnetHRD.Application.Interfaces;
    using CygnetHRD.Core.Entities;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This is the User controller class which having all CRUD method related to User entity.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// Public constructor to initialize UnitOfWork instance.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// This method use for featching all Users.
        /// </summary>
        /// <returns>List of User.</returns>
        /// <example>GET ../api/user</example>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await this.unitOfWork.Users.GetAllAsync();
            if (data.Count > 0)
                return this.Ok(data);
            else
                return this.NotFound("User doesn't exist.");

        }

        /// <summary>
        /// API call for get User entity by ID.
        /// </summary>
        /// <param name="id">int : User id.</param>
        /// <returns>User : User entity object.</returns>
        /// <example>GET ../api/user/2 .</example>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await this.unitOfWork.Users.GetByIdAsync(id);
            if (data == null)
            {
                return this.NotFound("User doesn't exist.");
            }

            return this.Ok(data);
        }

        /// <summary>
        /// API call for add new User entity.
        /// </summary>
        /// <param name="user">User : User enity object.</param>
        /// <returns>int : 1 for success and 0 for fail add status.</returns>
        /// <example>POST ../api/user .</example>
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            var data = await this.unitOfWork.Users.AddAsync(user);
            return this.Ok(data);
        }

        /// <summary>
        /// API call for delete User entity by ID.
        /// </summary>
        /// <param name="id">int : User id.</param>
        /// <returns>int : 1 for success and 0 for fail delete status.</returns>
        /// <example>DELETE ../api/user .</example>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await this.unitOfWork.Users.DeleteAsync(id);
            return this.Ok(data);
        }

        /// <summary>
        /// API call for update User entity.
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>int : 1 for success and 0 for fail update status.</returns>
        /// <example>PUT ../api/user .</example>
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            var data = await this.unitOfWork.Users.UpdateAsync(user);
            return this.Ok(data);
        }
    }
}