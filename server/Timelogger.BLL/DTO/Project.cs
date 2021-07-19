using AutoMapper;
using System;
using Timelogger.BLL.Mapper;
using Timelogger.DAL.Entities.Enums;

namespace Timelogger.BLL.DTO
{
    public class Project : IMapFrom<Timelogger.DAL.Entities.Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Timelogger.DAL.Entities.Project, Project>();
        }
    }
}
