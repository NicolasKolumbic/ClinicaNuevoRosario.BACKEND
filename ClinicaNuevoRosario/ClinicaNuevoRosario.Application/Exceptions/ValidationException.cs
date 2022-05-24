using FluentValidation.Results;

namespace ClinicaNuevoRosario.Application.Exceptions
{
    public class ValidationException: ApplicationException
    {
        public Dictionary<string, string[]> Errors { get; }

        public ValidationException() : base("One or more validation errors have occurred")
        {
            this.Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            this.Errors = failures
                            .GroupBy(x => x.PropertyName, q => q.ErrorMessage)
                            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
