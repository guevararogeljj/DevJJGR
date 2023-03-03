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
        public SaveProductHandler(ILogger<SaveProductHandler> logger,
            IProductsRepository productsRepository, IMapper mapper, ICategoriesRepository categoriesRepository)
        {
            this._logger = logger;
            this._productsRepository = productsRepository;
            this._mapper = mapper;
            this._categoriesRepository = categoriesRepository;
        }

        public async Task<ResponseDto<Guid>> Handle(SaveProductCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<Guid>();
            try
            {
                var categoeries = await this._categoriesRepository.FirstOrDefaultAsync(x => x.CategoryId.Equals(request.Products.Categories.CategoryId));
                if (categoeries == null)
                    return new ResponseDto<Guid>("La categoria no existe.", StatusCode.BAD_REQUEST);

                var product = new DevJJGR.Domain.Entities.Products();
                product = (await this._productsRepository.FirstOrDefaultAsync(x => x.ProductId.Equals(request.Products.ProductId)));
                if (product != null)
                    return new ResponseDto<Guid>("Producto ya existente.", StatusCode.BAD_REQUEST);
                else
                    product = new DevJJGR.Domain.Entities.Products();

                product.ProductName = request.Products.ProductName;
                product.CategoryId = categoeries.CategoryId;
                await this._productsRepository.AddAsync(product);
                await this._productsRepository.SaveChangesAsync();
                response.Data = product.ProductId;
                response.SetStatusCode(StatusCode.CREATED);
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
