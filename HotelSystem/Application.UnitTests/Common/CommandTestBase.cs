using HotelSystem.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly HotelDbContext _context;
        protected readonly Mock<HotelDbContext> _contextMock;

        public CommandTestBase()
        {
            _contextMock = HotelDbContextMockFactory.Create();
            _context = _contextMock.Object;
        }

        public void Dispose()
        {
            HotelDbContextMockFactory.Destroy(_context);
        }
    }
}
