using DemoOpenAPI.Domain;
using System.Collections.Concurrent;

namespace DemoOpenAPI.Data
{
    public static class DataReservas
    {
        public static readonly List<string> Estados = new List<string>
        {
            "Pendiente",
            "Confirmada",
            "Cancelada"
        };

        public static readonly List<Reserva> Reservas = [
            new Reserva
            {
                Id = 1,
                Nombre = "Reserva 1",
                FechaReserva = DateTime.Now,
                HoraInicio = "10:00",
                HoraFin = "11:00",
                Responsable = "Juan Perez",
                CantAsistentes = 5,
                MotivoReunion = "Reunión de trabajo",
                Estado = "Pendiente"
            },
            new Reserva
            {
                Id = 2,
                Nombre = "Reserva 2",
                FechaReserva = DateTime.Now.AddDays(1),
                HoraInicio = "14:00",
                HoraFin = "15:00",
                Responsable = "Maria Gomez",
                CantAsistentes = 3,
                MotivoReunion = "Presentación de proyecto",
                Estado = "Confirmada"
            },
            new Reserva
            {
                Id = 3,
                Nombre = "Reserva 3",
                FechaReserva = DateTime.Now.AddDays(2),
                HoraInicio = "09:00",
                HoraFin = "10:00",
                Responsable = "Carlos Lopez",
                CantAsistentes = 10,
                MotivoReunion = "Capacitación interna",
                Estado = "Cancelada"
            }
        ];
    }
}
