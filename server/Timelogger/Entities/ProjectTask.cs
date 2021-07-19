using Microsoft.EntityFrameworkCore;
using System;
using Timelogger.DAL.Entities.Abstract;

namespace Timelogger.DAL.Entities
{
	[Index(nameof(Id))]
	public class ProjectTask : BaseDateInfoEntity
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public virtual int ProjectId { get; set; }
		public virtual Project Project { get; set; }
    }
}
