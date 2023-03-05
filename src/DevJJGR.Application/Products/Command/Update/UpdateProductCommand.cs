using DevJJGR.Application.Dto;
using DevJJGRCore.Common.Models;
using MediatR;

namespace DevJJGR.Application.Products.Command.Update
{
    public class UpdateProductCommand : IRequest<ResponseDto<ProductsDTO>>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
