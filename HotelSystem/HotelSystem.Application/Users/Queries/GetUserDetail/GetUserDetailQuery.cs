using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserDetailVm>
    {
        public int Id { get; set; }
    }
}
