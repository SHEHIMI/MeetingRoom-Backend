using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;
using MeetingRoom.core.services;

namespace MeetingRoom.services
{
    public class ReservationService : IReservationsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Reservation> CreateReservation(Reservation reservation)
        {
            await _unitOfWork.Reservations.AddAsync(reservation);
            await _unitOfWork.CommitAsync();

            return reservation;
        }

        async Task<IEnumerable<Reservation>> IReservationsService.GetAllReservationsAsync()
        {
            return await _unitOfWork.Reservations.GetAllReservationsAsync();    
        }

        async Task<Reservation> IReservationsService.GetReservationByIdAsync(int id)
        {
            return await _unitOfWork.Reservations.GetReservationByIdAsync(id);
        }

        async Task<IEnumerable<Reservation>> IReservationsService.GetReservationsByCompanyAsync(int CompanyId)
        {
            return await _unitOfWork.Reservations.GetReservationsByCompanyAsync(CompanyId);
        }
    }
}
