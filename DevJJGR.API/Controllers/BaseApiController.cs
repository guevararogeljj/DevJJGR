using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevJJGR.API.Controllers
{
    [ApiController]
    [Route("api/v{version}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}

