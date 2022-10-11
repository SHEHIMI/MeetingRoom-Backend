using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;


namespace MeetingRoom.core.services
{
    public interface IReservationsService 
    {
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task<IEnumerable<Reservation>> GetReservationsByCompanyAsync(int CompanyId);
        //CRUD
        Task<Reservation>CreateReservation(Reservation reservation);        
    }
}


