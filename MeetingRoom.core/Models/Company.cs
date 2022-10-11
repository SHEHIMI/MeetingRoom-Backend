using System;
using System.Collections.Generic;

namespace MeetingRoom.core.Models
{
    public partial class Company
    {
        public Company()
        {
            Reservations = new HashSet<Reservation>();
            Rooms = new HashSet<Room>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
