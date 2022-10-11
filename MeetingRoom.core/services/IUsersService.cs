using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;


namespace MeetingRoom.core.services
{
    public interface IUsersService
    {

        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IEnumerable<User>> GetAllUsersByCompanyAsync(int compID);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string UserName);
        Task<User> CheckPasswordAsync();

        User GetUserByEmailAsync(string Email);

        //delete update create methods
        Task<User> InsertUser(User user);
        

    }
}
