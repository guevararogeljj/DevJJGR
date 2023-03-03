using AutoMapper;
using DevJJGR.Application.Common.Interfaces;
using DevJJGR.Application.Dto;
using DevJJGRCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevJJGR.Application.Products.Queries.GetAll
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsCommand, ResponseDto<List<ProductsDTO>>>
    {
        private readonly ILogger<GetAllProductsHandler> _logger;
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly IRabbitMQService _rabbitMQService;
        public GetAllProductsHandler(ILogger<GetAllProductsHandler> logger, IProductsRepository productsRepository, IMapper mapper, IRabbitMQService rabbitMQService)
        {
            this._logger = logger;
            this._productsRepository = productsRepository;
            this._mapper = mapper;
            this._rabbitMQService = rabbitMQService;
        }

        public async Task<ResponseDto<List<ProductsDTO>>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            var responseDto = new ResponseDto<List<ProductsDTO>>();
            try
            {
                var listProducts = await _productsRepository.GetAllProductsAllCatalogs();
                if (listProducts.Count() <= 0)
                {
                    responseDto.SetStatusError("No hay registros", StatusCode.NO_CONTENT);

                    return responseDto;
                }
                var products = _mapper.Map<List<ProductsDTO>>(listProducts);
                responseDto.Data = products;
                responseDto.SetStatusCode(StatusCode.OK);
                responseDto.Message = "Transacción exitosa";
                this._rabbitMQService.SendMessage("se hizo una consulta de todos los registros");
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
