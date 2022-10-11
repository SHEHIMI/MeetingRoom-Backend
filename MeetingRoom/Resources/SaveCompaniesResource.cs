using MeetingRoom.core.Models;

namespace MeetingRoom.Api.Resources
{
    public class SaveCompaniesResource
    {


        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public bool Active { get; set; }

       
    }
}
