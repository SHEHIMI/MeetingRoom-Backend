using AutoMapper;
using MeetingRoom.Api.Resources;
using MeetingRoom.core.Models;

namespace MeetingRoom.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<User, UsersResource>();

            CreateMap<Company, CompaniesResource>();

            CreateMap<Room, RoomsResource>();
            CreateMap<Reservation, ReservationsResource>();
            CreateMap<Admin, AdminResource>();
            // Resource to Domain
            CreateMap<UsersResource, User>();
            CreateMap<SaveUserResource, User>();

            CreateMap<CompaniesResource, Company>();
            CreateMap<SaveCompaniesResource, Company>();

            CreateMap<RoomsResource, Room>();
            CreateMap<SaveRoomsResource, Room>();

            CreateMap<ReservationsResource, Reservation>();
            CreateMap<SaveReservationsResource, Reservation>();

            CreateMap<AdminResource,Admin>();
            CreateMap<SaveAdminResource, Admin>();

        }
    }
}
