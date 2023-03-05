using AutoMapper;
using DevJJGR.Application.Common.Interfaces;
using DevJJGRCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevJJGR.Application.Products.Command.Save
{
    public class SaveProductHandler : IRequestHandler<SaveProductCommand, ResponseDto<Guid>>
    {
        private readonly ILogger<SaveProductHandler> _logger;
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IRabbitMQService _rabbitMQService;
        public SaveProductHandler(ILogger<SaveProductHandler> logger,
            IProductsRepository productsRepository, IMapper mapper, ICategoriesRepository categoriesRepository, IRabbitMQService rabbitMQService)
        {
            this._logger = logger;
            this._productsRepository = productsRepository;
            this._mapper = mapper;
            this._categoriesRepository = categoriesRepository;
            this._rabbitMQService = rabbitMQService;
        }

        public async Task<ResponseDto<Guid>> Handle(SaveProductCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<Guid>();
            try
            {
                var categoeries = await this._categoriesRepository.FirstOrDefaultAsync(x => x.CategoryId.Equals(request.CategoryId));
                if (categoeries == null)
                    return new ResponseDto<Guid>("La categoria no existe.", StatusCode.BAD_REQUEST);

                var product = new DevJJGR.Domain.Entities.Products();

                product.ProductName = request.ProductName;
                product.CategoryId = categoeries.CategoryId;
                await this._productsRepository.AddAsync(product);
                await this._productsRepository.SaveChangesAsync();
                response.Data = product.ProductId;
                response.SetStatusCode(StatusCode.CREATED);
                this._rabbitMQService.SendMessage($"Se guardó exitosamente el producto {product.ProductName}");
                return response;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Error.");
                return new ResponseDto<Guid>("Surgio un error.", StatusCode.INTERNAL_SERVER_ERROR);
            }
        }
    }
}
