using MeetingRoom.core.Models;

namespace MeetingRoom.Api.Resources
{
    public class RoomsResource
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public short Capacity { get; set; }
        public string? RoomDescription { get; set; }
        public int CompanyId { get; set; }


    }
}
