using AutoMapper;
using Timelogger.BLL.Mapper;

namespace Timelogger.UnitTests.Mappings
{
    public static class MapperFactory
    {
        public static IMapper Create()
        {
            var configProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            return configProvider.CreateMapper();
        }
    }
}
