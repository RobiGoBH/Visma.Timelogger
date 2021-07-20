using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Timelogger.BLL.Helper
{
    static class ServiceHelper<TDto, TDBo>
    {
        public static bool UpdateDataByDTO(TDto newDataObject, ref TDBo storedDataObject)
        {
            PropertyInfo[] dtoProperties = typeof(TDto).GetProperties();
            PropertyInfo[] dataProperties = typeof(TDBo).GetProperties();
            bool isAnyUpdated = false;
            foreach (var prop in dtoProperties)
            {
                if (prop.Name.ToLowerInvariant() == "id")
                    continue;
                foreach (var dprop in dataProperties)
                {
                    if (dprop.Name.ToLowerInvariant() == prop.Name.ToLowerInvariant())
                    {
                        if (prop.GetValue(newDataObject).ToString() != dprop.GetValue(storedDataObject).ToString())
                        {
                            isAnyUpdated = true;
                            dprop.SetValue(storedDataObject, prop.GetValue(newDataObject));
                        }
                    }
                }
            }

            return isAnyUpdated;
        }
    }
}
