using System;

namespace CL.Common
{
    /// <summary>
    /// Author   : Aricous
    /// Datetime : 20100628
    /// Function : 字符串扩展
    /// </summary>
    public static class NumberExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static double Round(this double src, int decimals)
        {
            return Math.Round(src, decimals);
        }         
        /// <summary>
        /// 把可空整形转换为整形，为空时返回【0】
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int ToInt(this int? src)
        {
            if (src.HasValue)
                return src.Value;
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static double Average(this double[] values)
        {
            if (values == null) return 0;
            int count = values.Length;
            if (count == 0) return 0;

            double temporary = 0.0;
            for (int i = 0; i < count; i++)
                temporary += values[i];
            return temporary / count;
        }
    }
}
