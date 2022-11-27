using AutoMapper;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;
using filmsRating.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmsRating.Controllers
{
    /// <summary>
    /// MovieGenres endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MovieGenresController : ControllerBase
    {
        private readonly IMovieGenreService movieGenreService;
        private readonly IMapper mapper;

        /// <summary>
        /// MovieGenres controller
        /// </summary>
        public MovieGenresController(IMovieGenreService movieGenreService, IMapper mapper)
        {
            this.movieGenreService = movieGenreService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get movieGenres by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMovieGenres([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = movieGenreService.GetMovieGenres(limit, offset);
            return Ok(mapper.Map<PageResponse<MovieGenreResponse>>(pageModel));
        }

        /// <summary>
        /// Get movieGenre
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMovieGenre([FromRoute] Guid id)
        {
            try
            {
                var movieGenreModel = movieGenreService.GetMovieGenre(id);
                return Ok(mapper.Map<MovieGenreResponse>(movieGenreModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }   
}