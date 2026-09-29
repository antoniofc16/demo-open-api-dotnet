using System.ComponentModel.DataAnnotations;

namespace DemoOpenAPI.Configuration.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; }

        public ValidationException() : base("Errores de validación.")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

        public ValidationException(List<string> errors) : this()
        {
            Errors = errors;
        }
    }

}
