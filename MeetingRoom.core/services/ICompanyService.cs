using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;


namespace MeetingRoom.core.services
{
    public interface ICompanyService { 
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> GetCompanyByNameAsync(string CompanyName);

        //CRUD
        Task<Company> AddCompany(Company company);
       
    }
}
