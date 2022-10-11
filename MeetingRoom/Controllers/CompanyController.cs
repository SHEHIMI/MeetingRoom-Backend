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

    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService _CompanyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService CompanyService, IMapper mapper)
        {
            _CompanyService = CompanyService;
            _mapper = mapper;

        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCompaniesAsync()
        {
            var companies = await _CompanyService.GetAllCompaniesAsync();

            var CompanyResources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompaniesResource>>(companies);

            return Ok(CompanyResources);
        }

        [HttpGet("{id}/companyId")]
        public async Task<ActionResult<Company>> GetCompanyByIdAsync(int id)
        {
            var companies = await _CompanyService.GetCompanyByIdAsync(id);

            var CompanyResources = _mapper.Map<Company,CompaniesResource>(companies);

            return Ok(CompanyResources);
        }

        [HttpGet("{CompanyName}/companyName")]
        public async Task<ActionResult<Company>> GetCompanyByNameAsync(string CompanyName)
        {

            var companies = await _CompanyService.GetCompanyByNameAsync(CompanyName);   

            var CompanyResources = _mapper.Map<Company, CompaniesResource>(companies);

            return Ok(CompanyResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<Company>> AddCompany([FromBody] SaveCompaniesResource COMP)
        {
            var CompToCreate = _mapper.Map<SaveCompaniesResource, Company>(COMP);

            var newComp = await _CompanyService.AddCompany(CompToCreate);

            var company = await _CompanyService.GetCompanyByIdAsync(newComp.Id);

            var CompanyResource = _mapper.Map<Company, CompaniesResource>(company);


            return Ok(CompanyResource);
        }
    }
}
