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

namespace HotelSystem.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailVm>
    {
        private readonly IHotelDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandler(IHotelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDetailVm> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            var userVm = _mapper.Map<UserDetailVm>(user);
            return userVm;
        }
    }
}
