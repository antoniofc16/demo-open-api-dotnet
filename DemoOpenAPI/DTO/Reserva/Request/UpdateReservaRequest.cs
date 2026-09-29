using DemoOpenAPI.Data;
using FluentValidation;

namespace DemoOpenAPI.DTO.Reserva.Request
{
    public class UpdateReservaRequest
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? FechaReserva { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFin { get; set; }
        public string? Responsable { get; set; }
        public int CantAsistentes { get; set; }
        public string? MotivoReunion { get; set; }
        public string? Estado { get; set; }
    }

    public class UpdateReservaRequestValidator : AbstractValidator<UpdateReservaRequest>
    {
        public UpdateReservaRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("El Id de la reserva es obligatorio");

            RuleFor(x => x.Nombre)
                .NotEmpty()
                .NotNull()
                .WithMessage("El nombre es obligatorio");

            RuleFor(x => x.FechaReserva)
                .NotEmpty()
                .NotNull()
                .WithMessage("La fecha de reserva es obligatoria");

            RuleFor(x => x.FechaReserva)
                .Must(BeAValidDate)
                .WithMessage("El fecha de reserva no es válida");

            RuleFor(x => x.HoraInicio)
                .NotEmpty()
                .NotNull()
                .WithMessage("La hora de inicio es obligatoria");

            RuleFor(x => x.HoraFin)
                .NotEmpty()
                .NotNull()
                .WithMessage("La hora de fin es obligatoria");

            RuleFor(x => x.Responsable)
                .NotEmpty()
                .NotNull()
                .WithMessage("El responsable es obligatorio");

            RuleFor(x => x.CantAsistentes)
                .GreaterThan(0)
                .WithMessage("La cantidad de asistentes debe ser mayor a 0");

            RuleFor(x => x.MotivoReunion)
                .NotNull()
                .NotEmpty()
                .WithMessage("El motivo de la reunión es obligatorio");

            RuleFor(x => x.Estado)
                .NotNull()
                .NotEmpty()
                    .WithMessage("El estado de la reserva es obligatorio")
                .Must(x => DataReservas.Estados.Contains(x!))
                    .WithMessage("El estado de la reserva debe ser 'Pendiente', 'Aprobada' o 'Rechazada'");

            RuleFor(x => x)
                .Must(BeAValidTime)
                .WithMessage("La hora de fin debe ser posterior a la hora de inicio");
        }

        private bool BeAValidDate(string? date)
        {
            return DateTime.TryParse(date, out _);
        }

        private bool BeAValidTime(UpdateReservaRequest request)
        {
            var initialTime = DateTime.Parse($" {request.FechaReserva} {request.HoraInicio}");
            var finalTime = DateTime.Parse($" {request.FechaReserva} {request.HoraFin}");

            return finalTime > initialTime;
        }
    }
}
