using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CL.Common
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 防止Session[key]为null时报错
        /// </summary>
        /// <param name="o"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(this System.Web.SessionState.HttpSessionState o, string key)
        {
            return (o.Contents[key] == null) ? "" : o.Contents[key];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToStrings(this object o)
        {
            try
            {
                if (o == null || o == DBNull.Value)
                {
                    return string.Empty;
                }
                else
                {
                    return (o.ToString().Equals("0")) ? string.Empty : o.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 对象为Null时返回""
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToStr(this object o)
        {
            return (o == null || o == DBNull.Value) ? "" : o.ToString();
        }
        /// <summary>
        /// 将字符串转换为数字，不是数字返回【0】
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static double ToDouble(this object src)
        {
            if (src == null || src == DBNull.Value)
                return 0;
            if (src.ToString().Trim().IsNumber())
            {
                return Convert.ToDouble(src);
            }
            return 0;
        }
        /// <summary>
        /// 将字符串转换为数字，不是数字返回【0】
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int ToInt32(this object src)
        {
            if (src == null || src == DBNull.Value)
                return 0;
            if (src.ToString().Trim().IsInt())
            {
                return Convert.ToInt32(src);
            }
            return 0;
        }
        /// <summary>
        /// 把对象序列化为Json字符串
        /// </summary>
        /// <param name="obj">对象实例</param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            //Newtonsoft.Json.JsonSerializerSettings s = new Newtonsoft.Json.JsonSerializerSettings();
            //s.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            //s.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;             
            //return Newtonsoft.Json.JsonConvert.SerializeObject(obj, s);
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 把Json字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<T> DeJson<T>(this string src, Type type) where T : class
        {
            return (List<T>)Newtonsoft.Json.JsonConvert.DeserializeObject(src, type);
        }


        public static object JsonToObject(string jsonString, Type type)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, type);
        }

        /// <summary>
        /// 类对象序列化为xml文件
        /// </summary>
        /// <param name="srcObject"></param>
        /// <param name="type"></param>
        /// <param name="xmlFilePath"></param>
        /// <param name="xmlRootName"></param>
        public static void SerializeToXml(object srcObject, Type type, string xmlFilePath, string xmlRootName)
        {
            if (srcObject != null && !string.IsNullOrEmpty(xmlFilePath))
            {
                type = type != null ? type : srcObject.GetType();

                using (StreamWriter sw = new StreamWriter(xmlFilePath))
                {
                    XmlSerializer xs = string.IsNullOrEmpty(xmlRootName) ?
                        new XmlSerializer(type) :
                        new XmlSerializer(type, new XmlRootAttribute(xmlRootName));
                    xs.Serialize(sw, srcObject);
                }
            }
        }


      
        /// <summary>
        ///XML反序列化为类对象
        /// </summary>
        /// <param name="xmlFilePath"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DeserializeFromXml(string xmlFilePath, Type type)
        {
            object result = null;
            if (File.Exists(xmlFilePath))
            {
                using (StreamReader reader = new StreamReader(xmlFilePath))
                {
                    XmlSerializer xs = new XmlSerializer(type);
                    result = xs.Deserialize(reader);
                }
            }
            return result;
        }
    }
}
