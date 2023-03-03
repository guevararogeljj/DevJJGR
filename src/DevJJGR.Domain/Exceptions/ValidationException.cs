namespace DevJJGR.Domain.Exceptions;
public class ValidationException : Exception
{
    public ValidationException() : base("Se han producido uno o más errores de validación.") => Errors = new List<string>();
    public List<string> Errors { get; }
    public ValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> exceptions) : this()
    {
        foreach (FluentValidation.Results.ValidationFailure item in exceptions)
        {
            Errors.Add(item.ErrorMessage);
        }
    }
}
