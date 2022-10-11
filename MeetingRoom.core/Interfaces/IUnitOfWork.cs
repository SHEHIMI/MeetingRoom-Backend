using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoom.core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRoomRepository Rooms { get; }
        IUsersRepository Users { get; }
        ICompanyRepository Companies { get; }
        IReservationRepository Reservations { get; }

        IAdminRepository Admins { get; }    
        Task<int> CommitAsync();
    }
}
