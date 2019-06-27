using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GuanatosSoft.Api.Data.Entities;
using GuanatosSoft.Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GuanatosSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantService service;
        private const string CORS_POLICYNAME = "GuanatosSoftApiCorsPolicy";

        public RestaurantController(IRestaurantService service)
        {
            this.service = service;
        }

        // GET api/index
        [HttpGet("index")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> Get()
        {
            return await Task.FromResult(Ok("GuanatosSoft Api Index"));
        }

        // GET api/restaurant
        [HttpGet]
        // [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [EnableCors(CORS_POLICYNAME)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<IEnumerable<Restaurant>>> Get([FromQuery] string text)
        {
            try
            {
                // We could add more logic, like error catching, authorization or data validation if applies
                if (string.IsNullOrWhiteSpace(text)) { return BadRequest(); }

                var list = await service.SearchPattern(text);
                if (list.Any()) { return Ok(list); }

                return NoContent(); ;
            }
            catch (System.Exception)
            {
                // Use logging strategy 
                throw;
            }
        }
    }
}
