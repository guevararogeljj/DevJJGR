using DevJJGR.Application.Dto;
using DevJJGR.Application.Products.Command.Delete;
using DevJJGR.Application.Products.Command.Save;
using DevJJGR.Application.Products.Command.Update;
using DevJJGR.Application.Products.Queries.GetAll;
using DevJJGR.Application.Products.Queries.GetById;
using DevJJGR.Controllers;
using DevJJGRCore.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevJJGR.Presentation.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            var response = await this.Mediator.Send(new GetAllProductsCommand());
            return StatusCode((int)response.Code, response);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var response = await this.Mediator.Send(new GetByIdProductsCommand { Id = Id });
            return StatusCode((int)response.Code, response);
        }

        [HttpPut]
        [Route("SaveProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDto<ProductsDTO>>> SaveProduct(SaveProductCommand request)
        {
            var result = await Mediator.Send(request);
            return StatusCode((int)result.Code, result);
        }

        [HttpPost]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDto<ProductsDTO>>> Update(UpdateProductCommand request)
        {
            var result = await Mediator.Send(request);
            return StatusCode((int)result.Code, result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(DeleteProductCommand request)
        {
            var response = await this.Mediator.Send(request);
            return StatusCode((int)response.Code, response);
        }
    }
}
