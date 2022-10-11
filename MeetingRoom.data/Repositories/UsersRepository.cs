using MeetingRoom.core.Context;
using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace MeetingRoom.data.Repositories
{

    public class UsersRepository : Repository<User>, IUsersRepository
    {
        public UsersRepository(MeetingRoomAppContext context)
        : base(context)
        { }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
           return await MeetingRoomAppContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersByCompanyAsync(int compID)
        {  

          return await MeetingRoomAppContext.Users.Include(m => m.Company).Where(m => m.CompanyId == compID).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await MeetingRoomAppContext.Users.FirstOrDefaultAsync(m => m.Id == id);
            #pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<User> GetUserByNameAsync(string UserName)
        {
            return await MeetingRoomAppContext.Users.FirstOrDefaultAsync(m=>m.Name==UserName);
        }

        public User GetUserByEmailAsync(string Email)
        {
            return MeetingRoomAppContext.Users.SingleOrDefault(m => m.Email == Email);
        }

        Task<User> IUsersRepository.CheckPasswordAsync()
        {
            throw new NotImplementedException();
        }

        private MeetingRoomAppContext? MeetingRoomAppContext
        {
            get { return Context as MeetingRoomAppContext; }
        }
    }
}
