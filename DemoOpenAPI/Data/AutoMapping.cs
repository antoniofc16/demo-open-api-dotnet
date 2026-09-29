using AutoMapper;
using DemoOpenAPI.Domain;
using DemoOpenAPI.DTO.Reserva.Response;

namespace DemoOpenAPI.Data
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Reserva, GetReservaResponse>()
                .ForMember(dest => dest.FechaReserva, opt => opt.MapFrom(src => src.FechaReserva.ToString("yyyy-MM-dd")));

            CreateMap<Reserva, NewReservaResponse>()
                .ForMember(dest => dest.FechaReserva, opt => opt.MapFrom(src => src.FechaReserva.ToString("yyyy-MM-dd")));

            CreateMap<Reserva, UpdateReservaResponse>()
                .ForMember(dest => dest.FechaReserva, opt => opt.MapFrom(src => src.FechaReserva.ToString("yyyy-MM-dd")));
        }
    }
}
