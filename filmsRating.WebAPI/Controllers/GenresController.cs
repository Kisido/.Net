using AutoMapper;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;
using filmsRating.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmsRating.Controllers
{
    /// <summary>
    /// Genres endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService genreService;
        private readonly IMapper mapper;

        /// <summary>
        /// Genres controller
        /// </summary>
        public GenresController(IGenreService genreService, IMapper mapper)
        {
            this.genreService = genreService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get genres by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetGenres([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = genreService.GetGenres(limit, offset);
            return Ok(mapper.Map<PageResponse<GenreResponse>>(pageModel));
        }

        /// <summary>
        /// Delete genre
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteGenre([FromRoute] Guid id)
        {
            try
            {
                genreService.DeleteGenre(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Add genre
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddGenre([FromBody] GenreModel genre)
        {
            var response = genreService.AddGenre(genre);
            return Ok(response);
        }

        /// <summary>
        /// Get genre
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGenre([FromRoute] Guid id)
        {
            try
            {
                var genreModel = genreService.GetGenre(id);
                return Ok(mapper.Map<GenreResponse>(genreModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }   
}