using AutoMapper;
using DevJJGR.Application.Common.Interfaces;
using DevJJGR.Application.Dto;
using DevJJGRCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevJJGR.Application.Products.Command.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ResponseDto<ProductsDTO>>
    {
        private readonly ILogger<DeleteProductHandler> _logger;
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly IRabbitMQService rabbitMQService;
        public DeleteProductHandler(ILogger<DeleteProductHandler> logger, IProductsRepository productsRepository, IMapper mapper, IRabbitMQService rabbitMQService)
        {
            this._logger = logger;
            this._productsRepository = productsRepository;
            this._mapper = mapper;
            this.rabbitMQService = rabbitMQService;
        }

        public async Task<ResponseDto<ProductsDTO>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<ProductsDTO>();
            try
            {
                var product = (await this._productsRepository.FirstOrDefaultAsync(x => x.ProductId.Equals(request.Id)));
                if (product == null)
                    return new ResponseDto<ProductsDTO>("Producto no existente.", StatusCode.BAD_REQUEST);
                this._productsRepository.Delete(product);
                await this._productsRepository.SaveChangesAsync();
                response.Data = null;
                response.SetStatusCode(StatusCode.OK);
                this.rabbitMQService.SendMessage($"Se elimino el producto {product.ProductId}");
                return response;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Error.");
                return new ResponseDto<ProductsDTO>("Surgio un error.", StatusCode.INTERNAL_SERVER_ERROR);
            }
        }
    }
}
