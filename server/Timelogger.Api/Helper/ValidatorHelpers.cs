using System;

namespace Timelogger.Api.Helper
{
    public static class ValidatorHelpers
    {
        public static bool BeNullOrAValidDate(DateTime? date)
        {
            if (date == null) return true;

            return !date.Equals(default(DateTime));
        }
    }
}
