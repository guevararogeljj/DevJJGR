using AutoMapper;
using DevJJGR.Application.Common.Interfaces;
using DevJJGR.Application.Dto;
using DevJJGRCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevJJGR.Application.Products.Queries.GetById
{
    public class GetByIdProductsHandler : IRequestHandler<GetByIdProductsCommand, ResponseDto<ProductsDTO>>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetByIdProductsCommand> _logger;
        public GetByIdProductsHandler(IProductsRepository productsRepository, IMapper mapper, ILogger<GetByIdProductsCommand> logger)
        {
            this._productsRepository = productsRepository;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<ResponseDto<ProductsDTO>> Handle(GetByIdProductsCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<ProductsDTO>();
            try
            {
                var product = await _productsRepository.FirstOrDefaultAsync(x => x.ProductId.Equals(request.Id));
                if (product is null)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var productRespose = _mapper.Map<ProductsDTO>(product);
                responseDto.Data = productRespose;
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
