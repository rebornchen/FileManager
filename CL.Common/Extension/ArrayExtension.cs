using System;

namespace CL.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string[] ToStrArr(this int[] src)
        {
            return Array.ConvertAll(src, i => i.ToString());
            // return Array.ConvertAll<int, string>(src, new Converter<int, string>(toString));
        }
        private static string toString(int src) { return src.ToString(); }
    }
}
