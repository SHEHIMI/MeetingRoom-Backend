using MeetingRoom.core.Models;



namespace MeetingRoom.core.services
{
    public interface IRoomsService 
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomByIdAsync(int id);
        Task<IEnumerable<Room>> GetRoomsByCompanyAsync(int CompanyId);
        //CRUD
        Task<Room> AddRoom(Room room);
    }
}
