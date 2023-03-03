using AutoMapper;
using DevJJGR.Application.Common.Interfaces;
using DevJJGR.Application.Dto;
using DevJJGR.Application.Products.Command.Save;
using DevJJGRCore.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevJJGR.Application.Products.Command.Update
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ResponseDto<ProductsDTO>>
    {
        private readonly ILogger<SaveProductHandler> _logger;
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly ICategoriesRepository _categoriesRepository;
        public UpdateProductHandler(ILogger<SaveProductHandler> logger, IProductsRepository productsRepository, IMapper mapper, ICategoriesRepository categoriesRepository)
        {
            this._logger = logger;
            this._productsRepository = productsRepository;
            this._mapper = mapper;
            this._categoriesRepository = categoriesRepository;
        }

        public async Task<ResponseDto<ProductsDTO>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<ProductsDTO>();
            try
            {
                var categoeries = await this._categoriesRepository.FirstOrDefaultAsync(x => x.CategoryId.Equals(request.Products.Categories.CategoryId));
                if (categoeries == null)
                    return new ResponseDto<ProductsDTO>("La categoria no existe.", StatusCode.BAD_REQUEST);

                var product = new DevJJGR.Domain.Entities.Products();
                product = (await this._productsRepository.FirstOrDefaultAsync(x => x.ProductId.Equals(request.Products.ProductId)));
                if (product is null)
                    return new ResponseDto<ProductsDTO>("Producto no existente.", StatusCode.BAD_REQUEST);

                product.ProductName = request.Products.ProductName;
                this._productsRepository.Update(product);
                await this._productsRepository.SaveChangesAsync();
                response.Data = request.Products;
                response.SetStatusCode(StatusCode.OK);
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
