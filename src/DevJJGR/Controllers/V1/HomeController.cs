using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevJJGR.Controllers.V1
{
    [ApiVersion("1.0")]
    //[Authorize]
    public class HomeController : BaseApiController
    {

        //[HttpGet("Autorizado")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult> Autorizado(string name)
        //{
        //    var response = await this.Mediator.Send(new SampleTestCommand(name));
        //    return StatusCode((int)response.Code, response);
        //}

        //[HttpGet("Sample")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult> Sample(Guid Id)
        //{
        //    var response = await this.Mediator.Send(new CoreDevJJGR.Common.Sample.SampleCommand { Id = null });
        //    return StatusCode((int)response.Code, response);
        //}
    }
}

