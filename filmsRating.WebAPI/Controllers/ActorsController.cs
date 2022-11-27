using AutoMapper;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;
using filmsRating.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmsRating.Controllers
{
    /// <summary>
    /// Actors endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService actorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Actors controller
        /// </summary>
        public ActorsController(IActorService actorService, IMapper mapper)
        {
            this.actorService = actorService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get actors by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetActors([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = actorService.GetActors(limit, offset);
            return Ok(mapper.Map<PageResponse<ActorResponse>>(pageModel));
        }

        /// <summary>
        /// Delete actor
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteActor([FromRoute] Guid id)
        {
            try
            {
                actorService.DeleteActor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Add Actor
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddActor([FromBody] ActorModel actor)
        {
            var response = actorService.AddActor(actor);
            return Ok(response);
        }

        /// <summary>
        /// Get actor
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetActor([FromRoute] Guid id)
        {
            try
            {
                var actorModel = actorService.GetActor(id);
                return Ok(mapper.Map<ActorResponse>(actorModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }   
}