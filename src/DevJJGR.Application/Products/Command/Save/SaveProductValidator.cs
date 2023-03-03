using FluentValidation;

namespace DevJJGR.Application.Products.Command.Save
{
    public class SaveProductValidator : AbstractValidator<SaveProductCommand>
    {
        public SaveProductValidator()
        {
            RuleFor(x => x.Products.ProductName).NotEmpty();
            RuleFor(x => x.Products.Categories.CategoryId).NotEmpty();
        }
    }
}
