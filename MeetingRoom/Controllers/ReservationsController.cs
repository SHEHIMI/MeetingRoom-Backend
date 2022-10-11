using AutoMapper;
using MeetingRoom.Api.Resources;
using MeetingRoom.core.Models;
using MeetingRoom.core.services;
using MeetingRoom.services;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReservationsController : ControllerBase 
    {

        private readonly IReservationsService _ReservationsService;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationsService ReservationsService, IMapper mapper)
        {
            _ReservationsService = ReservationsService;
            _mapper = mapper;

        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllReservationsAsync()
        {
            var reservations = await _ReservationsService.GetAllReservationsAsync();

            var ReservationsResources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationsResource>>(reservations);

            return Ok(ReservationsResources);
        }

        [HttpGet("{id}/ResId")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationByIdAsync(int id)
        {
            var reservations = await _ReservationsService.GetReservationByIdAsync(id);

            var ReservationsResources = _mapper.Map<Reservation,ReservationsResource>(reservations);

            return Ok(ReservationsResources);
        }

        [HttpGet("{Companyid}/ReservationByCompId")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsByCompanyAsync(int Companyid)
        {
            var reservations = await _ReservationsService.GetReservationsByCompanyAsync(Companyid);

            var ReservationsResources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationsResource>>(reservations);

            return Ok(ReservationsResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<ReservationsResource>> AddReservation([FromBody]SaveReservationsResource res)
        {

            var reservationToCreate = _mapper.Map<SaveReservationsResource, Reservation>(res);

            var newRes = await _ReservationsService.CreateReservation(reservationToCreate);

            var reservation = await _ReservationsService.GetReservationByIdAsync(newRes.Id);

            var ReservationResource = _mapper.Map<Reservation,ReservationsResource>(reservation);

            return Ok(ReservationResource);
        }


    }
}
