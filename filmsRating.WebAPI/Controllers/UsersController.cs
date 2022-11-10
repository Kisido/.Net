using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using filmsRating.Entities.Models;
using filmsRating.Repository;
using Microsoft.AspNetCore.Mvc;

namespace filmsRating.WebAPI.Controller
{
    /// <summary>
    /// Users endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepository<User> _repository;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get users
        /// </summary>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Get user
        /// </summary>
        [HttpGet]
        public IActionResult GetUser(Guid id)
        {
            var result = _repository.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// Save user
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public IActionResult SaveUser(User user)
        {
            var result = _repository.Save(user);
            return Ok(result);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="user"></param>
        [HttpDelete]
        public IActionResult DeleteUser(User user)
        {
            _repository.Delete(user);
            return Ok();
        }

        /// <summary>
        /// Replace user
        /// </summary>
        /// <param name="user"></param>
        [HttpPut]
        public IActionResult ReplaceUser(User user)
        {
            return SaveUser(user);
        }
}
}