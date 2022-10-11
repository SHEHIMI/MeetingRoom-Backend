using MeetingRoom.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoom.core.Interfaces
{
    public interface IAdminRepository
    {

        Admin GetAdminByUsername(string username);
    }
}
