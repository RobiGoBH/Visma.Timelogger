using AutoMapper;

namespace Timelogger.BLL.Mapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType()).ReverseMap();
    }
}
