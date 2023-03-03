using DevJJGR.Application.Dto;
using DevJJGRCore.Common.Models;
using MediatR;

namespace DevJJGR.Application.Products.Command.Save
{
    public class SaveProductCommand : IRequest<ResponseDto<Guid>>
    {
        public ProductsDTO Products { get; set; }
    }
}
