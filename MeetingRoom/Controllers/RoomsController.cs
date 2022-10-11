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

    public class RoomsController : ControllerBase
    {

        private readonly IRoomsService _RoomsService;
        private readonly IMapper _mapper;

        public RoomsController(IRoomsService RoomsService, IMapper mapper)
        {
            _RoomsService = RoomsService;
            _mapper = mapper;

        }

        [HttpGet("/GetAllRooms")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRoomsAsync()
        {
            var rooms = await _RoomsService.GetAllRoomsAsync();

            var RoomsResources = _mapper.Map<IEnumerable<Room>, IEnumerable<RoomsResource>>(rooms);

            return Ok(RoomsResources);
        }

        [HttpGet("{id}/RoomId")]
        public async Task<ActionResult<Room>> GetRoomByIdAsync(int id)
        {
            var rooms = await _RoomsService.GetRoomByIdAsync(id);

            var RoomsResources = _mapper.Map<Room, RoomsResource>(rooms);

            return Ok(RoomsResources);
        }

        [HttpGet("{CompanyId}/RoomByCompId")]
        public async Task<ActionResult<Company>> GetRoomsByCompanyAsync(int CompanyId)
        {

            var rooms = await _RoomsService.GetRoomsByCompanyAsync(CompanyId);

            var RoomsResources = _mapper.Map<IEnumerable<Room>, IEnumerable<RoomsResource>>(rooms);

            return Ok(RoomsResources);

        }

        [HttpPost("")]
        public async Task<ActionResult<Room>> AddRoom([FromBody] SaveRoomsResource room)
        {
            var RoomToCreate = _mapper.Map<SaveRoomsResource, Room>(room);

            var newRoom = await _RoomsService.AddRoom(RoomToCreate);

            var rooms = await _RoomsService.GetRoomByIdAsync(newRoom.Id);

            var RoomResource = _mapper.Map<Room, RoomsResource>(rooms);

            return Ok(RoomResource);
        }

    }
}
