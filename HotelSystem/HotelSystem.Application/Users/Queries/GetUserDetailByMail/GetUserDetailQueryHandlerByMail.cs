using AutoMapper;
using HotelSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Users.Queries.GetUserDetailByMail
{
    public class GetUserDetailQueryHandlerByMail :IRequestHandler<GetUserDetailQueryByMail, UserDetailByMailVm>
    {
        private readonly IHotelDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandlerByMail(IHotelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDetailByMailVm> Handle(GetUserDetailQueryByMail request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(p => p.Mail == request.Mail).FirstOrDefaultAsync(cancellationToken);

            var userVm = _mapper.Map<UserDetailByMailVm>(user);
            return userVm;
        }
    }
}
