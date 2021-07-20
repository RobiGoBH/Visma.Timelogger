using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using Timelogger.BLL.Mapper;
using Timelogger.BLL.DTO.Enums;

namespace Timelogger.BLL.DTO
{ 
    public class Project : IMapFrom<DAL.Entities.Project>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? Deadline { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Project, Project>()
                .ReverseMap();
        }
    }
}
