using System.Collections.Generic;
namespace CL.Common
{
    public class Directory
    {
        /// <summary>
        /// 获取指定路径下所有文件名
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pattern">
        /// 匹配模式
        /// <example>"*.xls"</example>
        /// </param>
        /// <returns></returns>
        public static List<string> GetFiles(string path, string pattern)
        {
            string[] array = System.IO.Directory.GetFiles(path, pattern);
            if (array == null || array.Length == 0) return null;

            List<string> list = new List<string>();
            foreach (string item in array)
            {
                string[] arr = item.Split('\\');
                list.Add(arr[arr.Length - 1]);
            }
            return list;
        }        
    }
}
