using Microsoft.AspNetCore.Mvc;

namespace DevJJGR.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version}/[controller]")]
    public class HomeController : BaseApiController
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll(string name)
        {
            return Ok();
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(string name)
        {
            return Ok();
        }
    }
}
