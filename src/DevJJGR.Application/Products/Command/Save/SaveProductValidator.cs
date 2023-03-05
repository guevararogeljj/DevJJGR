using FluentValidation;

namespace DevJJGR.Application.Products.Command.Save
{
    public class SaveProductValidator : AbstractValidator<SaveProductCommand>
    {
        public SaveProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }
}
