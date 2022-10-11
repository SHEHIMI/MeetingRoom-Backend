using MeetingRoom.core.Context;
using MeetingRoom.core.Interfaces;
using MeetingRoom.data.Repositories;

namespace MeetingRoom.core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeetingRoomAppContext _context;
        private UsersRepository _userRepository;
        private CompanyRepository _companyRepository;
        private RoomRepository _roomRepository;
        private ReservationRepository _reservationRepository;
        private AdminRepository _adminRepository;
        public UnitOfWork(MeetingRoomAppContext context)
        {
            _context = context;
        }

        public IUsersRepository Users => _userRepository = _userRepository ?? new UsersRepository(_context);

        public ICompanyRepository Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);

        public IRoomRepository Rooms => _roomRepository = _roomRepository ?? new RoomRepository(_context);

        public IReservationRepository Reservations => _reservationRepository = _reservationRepository ?? new ReservationRepository(_context);

        public IAdminRepository Admins => _adminRepository = _adminRepository ?? new AdminRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
