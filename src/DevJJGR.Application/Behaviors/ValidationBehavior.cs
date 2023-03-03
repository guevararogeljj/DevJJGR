using FluentValidation;
using MediatR;

namespace DevJJGR.Application.Behaviors;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (_validators.Any())
        {
            var context = new FluentValidation.ValidationContext<TRequest>(request);
            FluentValidation.Results.ValidationResult[] result = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
            var failures = result.SelectMany(x => x.Errors).Where(x => x != null).ToList();
            if (failures.Count > 0)
            {
                throw new Domain.Exceptions.ValidationException(failures);
            }
        }
        return await next();
    }
}
