using DevJJGR.Application.Dto;
using DevJJGRCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevJJGR.Application.SampleTest.queries.GetAll
{
    public class SampleTestGetAllHandler : IRequestHandler<SampleTestGetAllCommand, ResponseDto<List<SampleDTO>>>
    {
        private readonly ILogger<SampleTestGetAllHandler> _logger;
        public SampleTestGetAllHandler(ILogger<SampleTestGetAllHandler> logger)
        {
            this._logger = logger;
        }

        public async Task<ResponseDto<List<SampleDTO>>> Handle(SampleTestGetAllCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<List<SampleDTO>>();
            try
            {
                var listSample = new List<SampleDTO>();
                listSample.Add(new SampleDTO { Id = Guid.NewGuid(), Name = "Uno" });
                listSample.Add(new SampleDTO { Id = Guid.NewGuid(), Name = "Dos" });
                //List<SampleDTO> menus = _map.Map<List<SampleDTO>>(listSample);
                responseDto.Data = listSample.ToList();
                responseDto.SetStatusCode(StatusCode.OK);
                responseDto.Message = "Transacción exitosa";

                return responseDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error.");
                responseDto.SetStatusError("Error interno en el servidor", StatusCode.INTERNAL_SERVER_ERROR);

                return responseDto;
            }
        }
    }
}
