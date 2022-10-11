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


    public class AdminController : ControllerBase
    {

        private readonly IAdminService _AdminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService AdminService, IMapper mapper)
        {
            this._AdminService = AdminService;
            this._mapper = mapper;

        }

      
        [HttpGet("{username}/username")]
        public async Task<ActionResult<AdminResource>> GetAdminByUsername(string username)
        {
            var admins =  _AdminService.GetAdminByUsername(username);
            var AdminResources = _mapper.Map<Admin, AdminResource>(admins);

            return Ok(AdminResources);
        }



        [HttpPost("{username}/{Password}")]
        public async Task<IActionResult> SignIn(string username, string Password)
        {


            var Admin = _AdminService.GetAdminByUsername(username);

            if (Admin == null)
            {
                return BadRequest("Username or password incorrect.");
            }

            if (Admin.Password == Password)
            {
                return Ok(Admin);
            }


            return BadRequest("username or password incorrect.");
        }



    }
}

