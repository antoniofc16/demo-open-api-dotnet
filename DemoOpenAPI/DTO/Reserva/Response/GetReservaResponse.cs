namespace DemoOpenAPI.DTO.Reserva.Response
{
    public class GetReservaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string FechaReserva { get; set; } = string.Empty;
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFin { get; set; } = string.Empty;
        public string Responsable { get; set; } = string.Empty;
        public int CantAsistentes { get; set; }
        public string MotivoReunion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
