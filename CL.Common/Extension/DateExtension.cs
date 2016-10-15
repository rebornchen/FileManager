using System;

namespace CL.Common
{
    public static class DateExtension
    {
        /// <summary>
        /// 把可空日期转换为日期，为空是返回【1753-1-1】
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DateTime? src)
        {
            if (src.HasValue)
                return src.Value;
            return new DateTime(1753, 1, 1);
        }
    }
}
