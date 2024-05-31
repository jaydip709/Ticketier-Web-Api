using AutoMapper;
using Ticketier_WebApi.Core.DTO;
using Ticketier_WebApi.Core.Entities;

namespace Ticketier_WebApi.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<CreateTicketDto , Ticket>();
            CreateMap<Ticket, GetTicketDto>();
            CreateMap<UpdateTicketDto , Ticket>();
        }
    }
}
