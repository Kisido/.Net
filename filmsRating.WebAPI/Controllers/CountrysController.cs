using AutoMapper;
using filmsRating.Services.Abstract;
using filmsRating.Services.Models;
using filmsRating.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmsRating.Controllers
{
    /// <summary>
    /// Countrys endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CountrysController : ControllerBase
    {
        private readonly ICountryService countryService;
        private readonly IMapper mapper;

        /// <summary>
        /// Countrys controller
        /// </summary>
        public CountrysController(ICountryService countryService, IMapper mapper)
        {
            this.countryService = countryService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get countrys by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCountrys([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = countryService.GetCountrys(limit, offset);
            return Ok(mapper.Map<PageResponse<CountryResponse>>(pageModel));
        }

        /// <summary>
        /// Delete country
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCountry([FromRoute] Guid id)
        {
            try
            {
                countryService.DeleteCountry(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Add Country
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCountry([FromBody] CountryModel country)
        {
            var response = countryService.AddCountry(country);
            return Ok(response);
        }

        /// <summary>
        /// Get country
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCountry([FromRoute] Guid id)
        {
            try
            {
                var countryModel = countryService.GetCountry(id);
                return Ok(mapper.Map<GenreResponse>(countryModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }   
}