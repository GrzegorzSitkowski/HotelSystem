using AutoMapper;
using HotelSystem.Application.Mappings;
using HotelSystem.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Common
{
    public class QueryTestFixtures : IDisposable
    {
        public HotelDbContext Context { get; private set; }
        public IMapper Mapper { get; set; }

        public QueryTestFixtures()
        {
            Context = HotelDbContextMockFactory.Create().Object;

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            HotelDbContextMockFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixtures>
    {

    }
}
