using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanzasCF.Helpers
{
    public static class ConvertHelper
    {
        public static Int32 ToInteger(this object val, Int32 def = 0)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch (Exception)
            {
                return def;
            }
        }

        public static decimal Round(this decimal val, decimal def = 0)
        {
            try
            {
                return decimal.Round(val,2);
            }
            catch (Exception)
            {
                return def;
            }
        }
    }
}