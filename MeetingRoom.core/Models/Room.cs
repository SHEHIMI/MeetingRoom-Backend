using System;
using System.Collections.Generic;

namespace MeetingRoom.core.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public short Capacity { get; set; }
        public string? RoomDescription { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
