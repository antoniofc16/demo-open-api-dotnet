namespace DemoOpenAPI.DTO.Reserva.Response
{
    public class ListReservaResponse
    {
        public List<GetReservaResponse> Reservas { get; set; } = new List<GetReservaResponse>();

        public int TotalReservas => Reservas.Count;
    }
}
