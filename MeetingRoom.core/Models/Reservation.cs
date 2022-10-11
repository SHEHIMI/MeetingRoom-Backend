using System;
using System.Collections.Generic;

namespace MeetingRoom.core.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RelatedRoom { get; set; }
        public short NumberOfAttendees { get; set; }
        public bool MeetingStatus { get; set; }
        public int CompanyId { get; set; }
        public string? Title { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual Room RelatedRoomNavigation { get; set; } = null!;
    }
}
