using DevJJGR.Application.Dto;
using DevJJGRCore.Common.Models;
using MediatR;

namespace DevJJGR.Application.Products.Command.Delete
{
    public class DeleteProductCommand : IRequest<ResponseDto<ProductsDTO>>
    {
        public Guid Id { get; set; }
    }
}
