using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;


namespace MeetingRoom.core.services
{
    public interface IAdminService
    { 
      Admin GetAdminByUsername(string username);
    }
}
