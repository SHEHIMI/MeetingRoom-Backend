using MeetingRoom.core.Context;
using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoom.data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(MeetingRoomAppContext context)
        : base(context)
        { }

        async Task<IEnumerable<Company>> ICompanyRepository.GetAllCompaniesAsync()
        {
            return await MeetingRoomAppContext.Companies.ToListAsync();
        }
        
        async Task<Company> ICompanyRepository.GetCompanyByIdAsync(int id)
        {
            return await MeetingRoomAppContext.Companies.FirstOrDefaultAsync(m => m.Id == id);
        }

        async Task<Company> ICompanyRepository.GetCompanyByNameAsync(string CompanyName)
        {
            return await MeetingRoomAppContext.Companies.FirstOrDefaultAsync(m => m.Name == CompanyName);
        }

        private MeetingRoomAppContext? MeetingRoomAppContext
        {
            get { return Context as MeetingRoomAppContext; }
        }

    }
}
