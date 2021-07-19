using System;

namespace Timelogger.BLL.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message) { }

    }
}
