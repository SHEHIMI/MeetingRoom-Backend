using MeetingRoom.core.Context;
using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;
using MeetingRoom.core.services;
using Microsoft.EntityFrameworkCore;


namespace MeetingRoom.data.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(MeetingRoomAppContext context)
        : base(context)
        { }

        async Task<IEnumerable<Room>> IRoomRepository.GetAllRoomsAsync()
        {
           return await MeetingRoomAppContext.Rooms.ToListAsync();
        }

        async Task<Room> IRoomRepository.GetRoomByIdAsync(int id)
        {
            return await MeetingRoomAppContext.Rooms.FirstOrDefaultAsync(m => m.Id == id);
        }

        async Task<IEnumerable<Room>> IRoomRepository.GetRoomsByCompanyAsync(int CompanyId)
        {

            return await MeetingRoomAppContext.Rooms.Include(m => m.Company).Where(m => m.CompanyId ==
            CompanyId).ToListAsync();

          
        }

        private MeetingRoomAppContext? MeetingRoomAppContext
        {
            get { return Context as MeetingRoomAppContext; }
        }
    }
}
