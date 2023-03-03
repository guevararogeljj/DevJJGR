using FluentValidation;

namespace DevJJGR.Application.Products.Command.Update
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Products.ProductName).NotEmpty();
            RuleFor(x => x.Products.Categories.CategoryId).NotEmpty();
        }
    }
}
