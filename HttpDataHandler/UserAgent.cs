using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HttpDataHandler
{
    /// <summary>
    /// UA 的model
    /// </summary>
    public class UserAgentModel
    {
        public string Category { get; set; }
        public string Agent { get; set; }
    }

    /// <summary>
    /// 用户代理类
    /// </summary>
    public class UserAgent
    {
        /// <summary>
        /// ua 导入的文件
        /// 示例如下：
        /// Chrome|Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1667.0 Safari/537.36
        /// 每一行一个，使用 | 分隔
        /// </summary>
        public static string UAFilePath { get; set; }

        private static List<UserAgentModel> userAgentList = new List<UserAgentModel>();
        /// <summary>
        /// 用户代理
        /// </summary>
        public static List<UserAgentModel> UserAgentList
        {
            get
            {
                if (String.IsNullOrEmpty(UAFilePath))
                {
                    throw new Exception("no ua file");
                }
                //执行读取方法
                LoadUAFile();

                return userAgentList;
            }
        }

        /// <summary>
        /// 加载UA 的文件
        /// </summary>
        private static void LoadUAFile()
        {
            userAgentList.Clear();

            if (!System.IO.File.Exists( UAFilePath))
            {
                throw new Exception("UA file is not exists.");
            }
            StreamReader sr = new StreamReader(UAFilePath, Encoding.UTF8);
            String line;
            //读取每一行，并添加到ua 的集合中
            while ((line = sr.ReadLine()) != null)
            {
                string[] arr = line.Split('|');
                if (arr.Length == 2)
                {
                    userAgentList.Add(new UserAgentModel() { Category = arr[0], Agent = arr[1] });
                }
            }

            sr.Close();
        }

        /// <summary>
        /// 静态构造方法
        /// </summary>
        static UserAgent()
        {
            UAFilePath = System.Environment.CurrentDirectory + "\\DataBaseAccess\\ua";
        }

    }
}
/*************************

 //写文件
public void Write(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write("Hello World!!!!");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }




**********************************/