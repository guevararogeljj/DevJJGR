using FluentValidation;

namespace DevJJGR.Application.Products.Queries.GetById
{
    public class GetByIdProductsValidator : AbstractValidator<GetByIdProductsCommand>
    {
        public GetByIdProductsValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
