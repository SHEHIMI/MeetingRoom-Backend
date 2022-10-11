using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;
using MeetingRoom.core.services;

namespace MeetingRoom.services
{
    public class AdminService : IAdminService
    {

        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Admin GetAdminByUsername(string username)
        {
            return _unitOfWork.Admins.GetAdminByUsername(username);
        }
    }
}
