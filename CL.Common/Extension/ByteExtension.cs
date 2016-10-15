using System.Text;

namespace CL.Common
{
    public static class ByteExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string GetString(this byte[] arr)
        {
            return GetString(arr, 0, arr.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetString(this byte[] arr, int offset, int len)
        {
            return Encoding.Default.GetString(arr, offset, len);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string GetStringUTF8(this byte[] arr)
        {
            return GetStringUTF8(arr, 0, arr.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetStringUTF8(this byte[] arr, int offset, int len)
        {
            return Encoding.UTF8.GetString(arr, offset, len);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetStringASCII(this byte[] arr, int offset, int len)
        {
            return Encoding.ASCII.GetString(arr, offset, len);
        }
    }
}
