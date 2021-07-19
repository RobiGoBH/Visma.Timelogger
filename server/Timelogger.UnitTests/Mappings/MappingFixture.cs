using AutoMapper;

namespace Timelogger.UnitTests.Mappings
{
    public class MappingFixture
    {
        public MappingFixture() =>
            Mapper = MapperFactory.Create();

        public IMapper Mapper { get; set; }
    }
}
