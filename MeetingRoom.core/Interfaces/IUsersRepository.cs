using MeetingRoom.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoom.core.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersByCompanyAsync(int compID);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string UserName);
        User GetUserByEmailAsync(string Email);
        Task<User> CheckPasswordAsync();
    }
}
