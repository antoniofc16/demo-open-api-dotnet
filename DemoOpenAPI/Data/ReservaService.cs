using AutoMapper;
using DemoOpenAPI.Domain;
using DemoOpenAPI.DTO.Reserva.Request;
using DemoOpenAPI.DTO.Reserva.Response;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DemoOpenAPI.Data
{
    public interface IReservaService
    {
        Task<GetReservaResponse> GetReserva(int id);
        Task<ListReservaResponse> GetReservas(ListReservaRequest request);
        Task<NewReservaResponse> NewReserva(NewReservaRequest reserva);
        Task<UpdateReservaResponse> UpdateReserva(UpdateReservaRequest reserva);
        Task<bool> DeleteReserva(int id);
    }

    public class ReservaService : IReservaService
    {
        private readonly IMapper _mapper;

        public ReservaService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<GetReservaResponse> GetReserva(int id)
        {
            var reserva = DataReservas.Reservas.FirstOrDefault(r => r.Id == id);

            if (reserva is null)
            {
                throw new KeyNotFoundException("La reserva  Nro " + id + " no existe");
            }

            var result = _mapper.Map<GetReservaResponse>(reserva);

            return result;
        }

        public async Task<ListReservaResponse> GetReservas(ListReservaRequest request)
        {
            var validator = new ListReservaRequestValidator();
            var assertionResult = await validator.ValidateAsync(request);

            if (!assertionResult.IsValid)
            {
                throw new BadHttpRequestException(string.Join(", ", assertionResult.Errors.Select(e => e.ErrorMessage)));
            }

            var reservas = DataReservas.Reservas.Where(r => request.Fecha is null ? 1 == 1 : r.FechaReserva.Date == request.Fecha.Value.Date);

            return new ListReservaResponse { Reservas = reservas.Select(r => _mapper.Map<GetReservaResponse>(r)).ToList() };
        }

        public async Task<NewReservaResponse> NewReserva(NewReservaRequest reserva)
        {
            var validator = new NewReservaRequestValidator();
            var assertionResult = await validator.ValidateAsync(reserva);

            if (!assertionResult.IsValid)
            {
                throw new BadHttpRequestException(string.Join(", ", assertionResult.Errors.Select(e => e.ErrorMessage)));
            }

            var nuevaReserva = new Reserva
            {
                Id = DataReservas.Reservas.Max(r => r.Id) + 1,
                Nombre = reserva.Nombre!,
                FechaReserva = DateTime.Parse(reserva.FechaReserva!),
                HoraInicio = reserva.HoraInicio!,
                HoraFin = reserva.HoraFin!,
                Responsable = reserva.Responsable!,
                CantAsistentes = reserva.CantAsistentes,
                MotivoReunion = reserva.MotivoReunion!,
                Estado = "Pendiente"
            };
            
            DataReservas.Reservas.Add(nuevaReserva);

            var result = _mapper.Map<NewReservaResponse>(nuevaReserva);

            return result;
        }

        public async Task<UpdateReservaResponse> UpdateReserva(UpdateReservaRequest reserva)
        {
            var validator = new UpdateReservaRequestValidator();
            var assertionResult = await validator.ValidateAsync(reserva);

            if (!assertionResult.IsValid)
            {
                throw new BadHttpRequestException(string.Join(", ", assertionResult.Errors.Select(e => e.ErrorMessage)));
            }

            var existingReserva = DataReservas.Reservas.FirstOrDefault(r => r.Id == reserva.Id);

            if (existingReserva is null)
            {
                throw new KeyNotFoundException("La reserva  Nro " + reserva.Id + " no existe");
            }

            existingReserva.Nombre = reserva.Nombre!;
            existingReserva.FechaReserva = DateTime.Parse(reserva.FechaReserva!);
            existingReserva.HoraInicio = reserva.HoraInicio!;
            existingReserva.HoraFin = reserva.HoraFin!;
            existingReserva.Responsable = reserva.Responsable!;
            existingReserva.CantAsistentes = reserva.CantAsistentes;
            existingReserva.MotivoReunion = reserva.MotivoReunion!;
            existingReserva.Estado = reserva.Estado!;

            var result = _mapper.Map<UpdateReservaResponse>(existingReserva);

            return result;
        }

        public async Task<bool> DeleteReserva(int id)
        {
            var reserva = DataReservas.Reservas.FirstOrDefault(r => r.Id == id);

            if (reserva is null)
            {
                throw new KeyNotFoundException("La reserva  Nro " + id + " no existe");
            }

            DataReservas.Reservas.Remove(reserva);

            return true;
        }
    }
}
