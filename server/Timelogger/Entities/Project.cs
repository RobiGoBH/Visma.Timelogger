using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Timelogger.DAL.Entities.Abstract;
using Timelogger.DAL.Entities.Enums;

namespace Timelogger.DAL.Entities
{
	[Index(nameof(Id), nameof(Name))]
	public class Project : BaseDateInfoEntity
	{
		public string Name { get; set; }
		public DateTime Deadline { get; set; }
		public ProjectStatus Status { get; set; }
		public virtual ICollection<ProjectTask> Tasks { get; set; }
	}
}
