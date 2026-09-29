using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace DemoOpenAPI.DTO.Reserva.Request
{
    public class ListReservaRequest
    {
        public DateTime? Fecha { get; set; }
    }

    public class ListReservaRequestValidator : AbstractValidator<ListReservaRequest>
    {
        public ListReservaRequestValidator()
        {
            RuleFor(x => x.Fecha)
                .Must(BeAValidDate)
                .WithMessage("La fecha no es válida.");
        }
        private bool BeAValidDate(DateTime? date)
        {
            if (date is null)
                return true;

            return date.HasValue && date.Value != default(DateTime);
        }
    }
}
