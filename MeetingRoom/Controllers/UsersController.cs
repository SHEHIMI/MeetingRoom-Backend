using AutoMapper;
using MeetingRoom.Api.Resources;
using MeetingRoom.core.Models;
using MeetingRoom.core.services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace MeetingRoom.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class UsersController : ControllerBase
    {

        private readonly IUsersService _UsersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService UsersService, IMapper mapper)
        {
            this._UsersService = UsersService;
            this._mapper = mapper;

        }

        [HttpGet("/Allusers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
        {
            var users = await _UsersService.GetAllUsersAsync();

            var UsersResources = _mapper.Map<IEnumerable<User>, IEnumerable<UsersResource>>(users);

            return Ok(UsersResources);
        }

        [HttpGet("{compID}/companyId")]
        public async Task<ActionResult<UsersResource>> GetAllusersByCompanyAsync(int compID)
        {
            var users = await _UsersService.GetAllUsersByCompanyAsync(compID);
            var usersResources = _mapper.Map<IEnumerable<User>, IEnumerable<UsersResource>>(users);

            return Ok(usersResources);
        }

        [HttpGet("{Id}/userID")]
        public async Task<ActionResult<UsersResource>> GetUserByIdAsync(int Id)
        {
            var users = await _UsersService.GetUserByIdAsync(Id);
            var usersResources = _mapper.Map<User, UsersResource>(users);

            return Ok(usersResources);
        }

        [HttpGet("{username}/username")]
        public async Task<ActionResult<UsersResource>> GetUserByNameAsync(string username)
        {
            var users = await _UsersService.GetUserByNameAsync(username);
            var usersResources = _mapper.Map<User, UsersResource>(users);

            return Ok(usersResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<UsersResource>> InsertUser([FromBody] SaveUserResource USER)
        {

            var UserToCreate = _mapper.Map<SaveUserResource, User>(USER);

            var newUser = await _UsersService.InsertUser(UserToCreate);

            var user = await _UsersService.GetUserByIdAsync(newUser.Id);

            var UserResource = _mapper.Map<User, UsersResource>(user); 
            

            return Ok(UserResource);

        }

        [HttpPost("{Email}/{Password}")]
        public async Task<IActionResult> SignIn(string Email,string Password)
        {


            var user = _UsersService.GetUserByEmailAsync(Email);

            if(user == null)
            {
                return BadRequest("Email or password incorrect.");
            }
        
            if(user.Password == Password)
            {
                return Ok(user);
            }
        

            return BadRequest("Email or password incorrect.");
        }



    }
}

