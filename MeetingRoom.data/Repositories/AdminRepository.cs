using MeetingRoom.core.Context;
using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace MeetingRoom.data.Repositories
{

    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(MeetingRoomAppContext context)
        : base(context)
        { }

     

        private MeetingRoomAppContext? MeetingRoomAppContext
        {
            get { return Context as MeetingRoomAppContext; }
        }

        public Admin GetAdminByUsername(string username)
        {
            return MeetingRoomAppContext.Admins.SingleOrDefault(m => m.Username == username);
        }
    }
}
