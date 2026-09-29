namespace DemoOpenAPI.Domain
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaReserva { get; set; }
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFin { get; set; } = string.Empty;
        public string Responsable { get; set; } = string.Empty;
        public int CantAsistentes { get; set; } = 0;
        public string MotivoReunion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
