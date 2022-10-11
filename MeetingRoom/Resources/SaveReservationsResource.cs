using MeetingRoom.core.Models;

namespace MeetingRoom.Api.Resources
{
    public class SaveReservationsResource
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RelatedRoom { get; set; }
        public short NumberOfAttendees { get; set; }
        public bool MeetingStatus { get; set; }
        public int CompanyId { get; set; }
        public string? Title { get; set; }

    }
}
