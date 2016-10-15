using System;

using System.IO;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;
using System.Xml;
using NLite.Log;
namespace CL.Common
{
    /// <summary>
    /// 全局管理类
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Const Key of CurrentUser
        /// </summary>
        public const string ckCurrentUser = "CurrentUser";
        public const string ckCurrentLang = "CurrentLanguage";
        public const string ckCurrentWFLoginName = "CurrentWFLoginName";

        static Cache cache = null;
        private Manager()
        {
            cache = new Cache();
        }
        /// <summary>
        /// 日期在解析为年月日格式时，使用该文化
        /// </summary>
        public static readonly IFormatProvider usculture = new System.Globalization.CultureInfo("en-US", true);
        /// <summary>
        ///  日期在解析为日月年格式时，使用该文化
        /// </summary>
        public static readonly IFormatProvider frculture = new System.Globalization.CultureInfo("fr-FR", true);
        /// <summary>
        /// 年月日格式字符串
        /// </summary>
        public const string cfUSDate = "yyyy-MM-dd";
        /// <summary>
        /// 日月年格式字符串
        /// </summary>
        //public const string cfFRDate = "dd-MM-yyyy";
        #region 系统日志
        /// <summary>
        /// 系统日志
        /// </summary>        
        //public static readonly log4net.ILog Logger = log4net.LogManager.GetLogger("LogAllToFile");
        public static readonly log4net.ILog Logger1 = log4net.LogManager.GetLogger("TMSLogger");

        public static NLite.Log.ILog Logger
        {
            get
            {
                if (NLite.Log.LogManager.Instance.GetType().ToString() == "NLite.Log.LogManager")
                    NLite.Log.LogManager.Instance = new NLite.Log.Log4nLogManager();

                return NLite.Log.LogManager.GetLogger("LogAllToFile");
            }
        }
        #endregion

        #region 系统缓存
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            var log = LogManager.GetLogger("");
            return cache[key];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public static object SetCache(string key, object val)
        {
            if (cache[key] == null)
                return cache[key] = val;
            else
                cache.Insert(key, val);
            return val;
        }
        #endregion

        #region 会话处理
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetSession(string key)
        {
            try
            {
                return HttpContext.Current.Session[key];
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public static void SetSession(string key, object val)
        {
            HttpContext.Current.Session[key] = val;
        }
        #endregion

        #region 日期处理
        /// <summary>
        /// 用来统一处理在当前年度录入以往年度圈闭数据时，相应的发现时间、复查时间等默认问题
        /// 例如当前年度为2012年，需要录入2008年度的圈闭数据时，发现时间等要默认为2008年某月
        /// </summary>
        public static DateTime DateTimer { get { return DateTime.Now; } }
        /// <summary>
        /// 获取时间字符串
        /// </summary>
        public static string DateTimeStr { get { return DateTime.Now.ToString("4yyyyMMddHHmmssfffff"); } }
        #endregion

        #region 目录处理
        /// <summary>
        /// 虚拟目录
        /// </summary>
        public static readonly string VDirectory = HttpContext.Current.Server.MapPath(string.Concat("~/", WebConfigurationManager.AppSettings["vdirectory"]));
        /// <summary>
        /// 模板文件目录
        /// </summary>
        public static readonly string Templates = GetDirectory("Templates");
        /// <summary>
        /// 报表文件目录
        /// </summary>
        public static readonly string Reports = GetDirectory("Reports");

        /// <summary>
        /// 导出报表文件目录
        /// </summary>
        public static readonly string OutPutReports = GetDirectory("OutPutReports");
        /// <summary>
        /// 
        /// </summary>
        public static readonly string Config = GetDirectory("Config");
        /// <summary>
        /// 
        /// </summary>
        public static readonly string Pictures = GetDirectory("Pictures");
        /// <summary>
        /// 获取目录
        /// </summary>
        /// <param name="folder">文件夹名称</param>
        /// <returns>目录全名称</returns>
        private static string GetDirectory(string folder)
        {
            string directory = Path.Combine(Manager.VDirectory, folder);
            if (System.IO.Directory.Exists(directory)) return directory;
            return System.IO.Directory.CreateDirectory(directory).FullName;
        }

        /// <summary>
        /// 获取Setting.xml配置文件中指定键的值
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>值</returns>
        public static string GetValueByConfig(string key)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Manager.Config + "/Settings.xml");
            XmlNodeList list = xmldoc.GetElementsByTagName("add");
            foreach (XmlElement node in list)
            {
                if (node.GetAttribute("key") == key)
                {
                    return node.GetAttribute("value");
                }
            }
            return "";
        }
        #endregion
    }
}