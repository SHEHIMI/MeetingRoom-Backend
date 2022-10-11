using MeetingRoom.core.Context;
using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;
using MeetingRoom.core.services;

namespace MeetingRoom.services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<Company> ICompanyService.AddCompany(Company company)
        {
            await _unitOfWork.Companies.AddAsync(company);  
            await _unitOfWork.CommitAsync();
            return company;
        }

        async Task<IEnumerable<Company>> ICompanyService.GetAllCompaniesAsync()
        {
            return await _unitOfWork.Companies.GetAllCompaniesAsync();
        }

        async Task<Company> ICompanyService.GetCompanyByIdAsync(int id)
        {
            return await _unitOfWork.Companies.GetCompanyByIdAsync(id);
        }

        async Task<Company> ICompanyService.GetCompanyByNameAsync(string CompanyName)
        {
           return await _unitOfWork.Companies.GetCompanyByNameAsync(CompanyName);
        }
    }
}
