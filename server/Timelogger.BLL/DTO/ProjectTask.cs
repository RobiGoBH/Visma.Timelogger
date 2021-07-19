using AutoMapper;
using System;
using Timelogger.BLL.Mapper;
using Timelogger.DAL.Entities.Enums;

namespace Timelogger.BLL.DTO
{
    public class ProjectTask : IMapFrom<Timelogger.DAL.Entities.ProjectTask>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Timelogger.DAL.Entities.ProjectTask, ProjectTask>()
                .ForMember(d=>d.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
                .ReverseMap()
                .ForPath(s => s.Project.Id, opt => opt.MapFrom(src => src.ProjectId));
        }
    }
}
