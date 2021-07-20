using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using Timelogger.BLL.Mapper;

namespace Timelogger.BLL.DTO
{
    public class ProjectTask : IMapFrom<DAL.Entities.ProjectTask>
    {
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        public string Type { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DAL.Entities.ProjectTask, ProjectTask>()
                .ForMember(d=>d.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
                .ReverseMap()
                .ForPath(s => s.Project.Id, opt => opt.MapFrom(src => src.ProjectId));
        }
    }
}
