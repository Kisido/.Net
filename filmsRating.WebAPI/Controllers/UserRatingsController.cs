using AutoMapper;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;
using filmsRating.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmsRating.Controllers
{
    /// <summary>
    /// UserRatings endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersRatingsController : ControllerBase
    {
        private readonly IUserRatingService userRatingService;
        private readonly IMapper mapper;

        /// <summary>
        /// UserRatings controller
        /// </summary>
        public UsersRatingsController(IUserRatingService userRatingService, IMapper mapper)
        {
            this.userRatingService = userRatingService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get userRatings by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserRatings([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = userRatingService.GetUserRatings(limit, offset);
            return Ok(mapper.Map<PageResponse<UserRatingPreviewResponse>>(pageModel));
        }

        /// <summary>
        /// Update userRating
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUserRating([FromRoute] Guid id, [FromBody] UpdateUserRatingRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = userRatingService.UpdateUserRating(id, mapper.Map<UpdateUserRatingModel>(model));

                return Ok(mapper.Map<UserRatingResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete userRating
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUserRating([FromRoute] Guid id)
        {
            try
            {
                userRatingService.DeleteUserRating(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Add userRating
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUserRating([FromBody] UserRatingModel userRating)
        {
            var response = userRatingService.AddUserRating(userRating);
            return Ok(response);
        }

        /// <summary>
        /// Get userRating
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserRating([FromRoute] Guid id)
        {
            try
            {
                var userRatingModel = userRatingService.GetUserRating(id);
                return Ok(mapper.Map<UserRatingResponse>(userRatingModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }   
}