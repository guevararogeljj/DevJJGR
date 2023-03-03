using FluentValidation;

namespace DevJJGR.Application.Products.Command.Delete
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
