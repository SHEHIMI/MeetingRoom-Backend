using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;
using MeetingRoom.core.services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MeetingRoom.services
{


    public class RoomsService : IRoomsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Room> AddRoom(Room room)
        {

            await _unitOfWork.Rooms.AddAsync(room);
            await _unitOfWork.CommitAsync();
            return room;
        }

        async Task<IEnumerable<Room>> IRoomsService.GetAllRoomsAsync()
        {
            return await _unitOfWork.Rooms.GetAllRoomsAsync();
        }

        async Task<Room> IRoomsService.GetRoomByIdAsync(int id)
        {
          return await _unitOfWork.Rooms.GetRoomByIdAsync(id);
        }

        async Task<IEnumerable<Room>> IRoomsService.GetRoomsByCompanyAsync(int CompanyId)
        {
            return await _unitOfWork.Rooms.GetRoomsByCompanyAsync(CompanyId);
        }
    }
}
