using DevJJGR.Application.SampleTest.queries.GetAll;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevJJGR.Controllers.V1
{
    [ApiVersion("1.0")]
    //[Authorize]
    public class HomeController : BaseApiController
    {

        [HttpGet("GeAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GeAll()
        {
            var response = await this.Mediator.Send(new SampleTestGetAllCommand());
            return StatusCode((int)response.Code, response);
        }
    }
}

