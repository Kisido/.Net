using AutoMapper;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;
using filmsRating.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmsRating.Controllers
{
    /// <summary>
    /// MovieActors endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MovieActorsController : ControllerBase
    {
        private readonly IMovieActorService movieActorService;
        private readonly IMapper mapper;

        /// <summary>
        /// MovieActors controller
        /// </summary>
        public MovieActorsController(IMovieActorService movieActorService, IMapper mapper)
        {
            this.movieActorService = movieActorService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get movieActors by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMovieActors([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = movieActorService.GetMovieActors(limit, offset);
            return Ok(mapper.Map<PageResponse<MovieActorResponse>>(pageModel));
        }

        /// <summary>
        /// Get movieActor
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMovieActor([FromRoute] Guid id)
        {
            try
            {
                var movieActorModel = movieActorService.GetMovieActor(id);
                return Ok(mapper.Map<MovieActorResponse>(movieActorModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }   
}