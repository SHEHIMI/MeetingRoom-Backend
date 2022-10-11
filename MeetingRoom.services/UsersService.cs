using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;
using MeetingRoom.core.services;

namespace MeetingRoom.services
{
    public class UsersService : IUsersService
    {

        private readonly IUnitOfWork _unitOfWork;

        public UsersService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<User> CheckPasswordAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.Users.GetAllUsersAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersByCompanyAsync(int compID)
        {
            return await _unitOfWork.Users.GetAllUsersByCompanyAsync(compID);
        }

        public User GetUserByEmailAsync(string Email)
        {
            return  _unitOfWork.Users.GetUserByEmailAsync(Email);


        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetUserByIdAsync(id);
        }

        public async Task<User> GetUserByNameAsync(string UserName)
        {
            return await _unitOfWork.Users.GetUserByNameAsync(UserName);
        }

        public async Task<User> InsertUser(User user)
        {
            
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();
            return user;
        }
    }
}
