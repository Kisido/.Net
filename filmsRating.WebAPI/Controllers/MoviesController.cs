using AutoMapper;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;
using filmsRating.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmsRating.Controllers
{
    /// <summary>
    /// Movies endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;
        private readonly IMapper mapper;

        /// <summary>
        /// Movies controller
        /// </summary>
        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            this.movieService = movieService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get movies by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMovies([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = movieService.GetMovies(limit, offset);
            return Ok(mapper.Map<PageResponse<MoviePreviewResponse>>(pageModel));
        }

        /// <summary>
        /// Update movie
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateMovie([FromRoute] Guid id, [FromBody] UpdateMovieRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = movieService.UpdateMovie(id, mapper.Map<UpdateMovieModel>(model));

                return Ok(mapper.Map<MovieResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete movie
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteMovie([FromRoute] Guid id)
        {
            try
            {
                movieService.DeleteMovie(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Add movie
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieModel movie)
        {
            var response = movieService.AddMovie(movie);
            return Ok(response);
        }

        /// <summary>
        /// Get movie
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMovie([FromRoute] Guid id)
        {
            try
            {
                var movieModel = movieService.GetMovie(id);
                return Ok(mapper.Map<MovieResponse>(movieModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }   
}