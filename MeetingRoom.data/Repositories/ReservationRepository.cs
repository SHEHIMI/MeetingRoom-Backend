using MeetingRoom.core.Context;
using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;
using Microsoft.EntityFrameworkCore;


namespace MeetingRoom.data.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(MeetingRoomAppContext context)
        : base(context)
        { }
       
        async Task<IEnumerable<Reservation>> IReservationRepository.GetAllReservationsAsync()
        {
            return await MeetingRoomAppContext.Reservations.ToListAsync();
        }

        async Task<Reservation> IReservationRepository.GetReservationByIdAsync(int id)
        {
            return await MeetingRoomAppContext.Reservations.FirstOrDefaultAsync(m => m.Id == id);
        }

        async Task<IEnumerable<Reservation>> IReservationRepository.GetReservationsByCompanyAsync(int CompanyId)
        {
            return await MeetingRoomAppContext.Reservations.Include(m=>m.Company).Where(m=>m.CompanyId == CompanyId).ToListAsync(); 
        }

        private MeetingRoomAppContext? MeetingRoomAppContext
        {
            get { return Context as MeetingRoomAppContext; }
        }

    }
}
