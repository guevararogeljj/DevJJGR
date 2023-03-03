using DevJJGR.Application.Dto;
using DevJJGRCore.Common.Models;
using MediatR;

namespace DevJJGR.Application.SampleTest.queries.GetAll
{
    public class SampleTestGetAllCommand : IRequest<ResponseDto<List<SampleDTO>>>
    {
    }
}
