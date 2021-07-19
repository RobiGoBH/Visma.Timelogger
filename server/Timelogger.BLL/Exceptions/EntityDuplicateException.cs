using System;

namespace Timelogger.BLL.Exceptions
{
    public class EntityDuplicateException : Exception
    {
        public EntityDuplicateException(string message)
            : base(message) { }
    }
}
