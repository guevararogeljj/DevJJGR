using DevJJGR.Application.Dto;
using DevJJGRCore.Common.Models;
using MediatR;

namespace DevJJGR.Application.Products.Queries.GetAll
{
    public class GetAllProductsCommand : IRequest<ResponseDto<List<ProductsDTO>>>
    {
    }
}
