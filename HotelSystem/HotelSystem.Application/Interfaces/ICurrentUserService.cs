using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Interfaces
{
    public interface ICurrentUserService
    {
        string userName { get; set; }
        bool IsAuthenticated { get; set; }
    }
}
