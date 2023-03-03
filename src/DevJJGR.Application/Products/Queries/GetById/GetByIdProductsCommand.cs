using DevJJGR.Application.Dto;
using DevJJGRCore.Common.Models;
using MediatR;

namespace DevJJGR.Application.Products.Queries.GetById
{
    public class GetByIdProductsCommand : IRequest<ResponseDto<ProductsDTO>>
    {
        public Guid Id { get; set; }
    }
}
