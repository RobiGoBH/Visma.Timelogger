
using System;

namespace Timelogger.DAL.Entities.Abstract
{
    public class BaseDateInfoEntity : BaseEntity
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
