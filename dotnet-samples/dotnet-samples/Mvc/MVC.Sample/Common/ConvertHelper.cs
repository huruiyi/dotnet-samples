using System;

namespace MVC.Sample.Common
{
    public static class ConvertHelper
    {
        public static byte ToByte(this Enum e, byte defaultvalue = 0)
        {
            try
            {
                return Convert.ToByte(e);
            }
            catch (Exception)
            {
                return defaultvalue;
            }
        }

        public static int ToInt(this Enum e, int defaultvalue = -1)
        {
            try
            {
                return Convert.ToInt32(e);
            }
            catch (Exception)
            {
                return defaultvalue;
            }
        }
    }
}