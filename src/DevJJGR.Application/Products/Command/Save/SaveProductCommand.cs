using DevJJGR.Application.Dto;
using DevJJGRCore.Common.Models;
using MediatR;

namespace DevJJGR.Application.Products.Command.Save
{
    public class SaveProductCommand : IRequest<ResponseDto<Guid>>
    {
        public string ProductName { get; set; }
        public Guid CategoryId { get; set; }
    }
}
