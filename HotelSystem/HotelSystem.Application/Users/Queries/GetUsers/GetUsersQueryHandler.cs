using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelSystem.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UsersVm>
    {
        private readonly IHotelDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IHotelDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UsersVm> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.Where(p => p.StatusId == 1)
                .ProjectTo<UsersVm>(_mapper.ConfigurationProvider).ToListAsync();

            return new UsersVm();
        }
    }
}
