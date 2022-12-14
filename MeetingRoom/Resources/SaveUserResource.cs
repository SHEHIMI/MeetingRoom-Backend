using MeetingRoom.core.Models;

namespace MeetingRoom.Api.Resources
{
    public class SaveUserResource
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int CompanyId { get; set; }

      //  public virtual Company Company { get; set; } = null!;
    }
}
