using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelogger.DAL.Base;

namespace Timelogger.UnitTests.TestConfigurations
{
    public class TestBaseFixture : IDisposable
    {
        public TestBaseFixture()
        {
            Context = DbContextFactory.Create();
            Mapper = Mappings.MapperFactory.Create();
        }

        public TimeloggerContext Context { get; }
        public IMapper Mapper { get; }

        public void Dispose()
        {
            DbContextFactory.RemoveContext(Context);
        }
    }
}
