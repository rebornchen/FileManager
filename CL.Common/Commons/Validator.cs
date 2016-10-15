using System.Text;
using System.Text.RegularExpressions;

namespace CL.Common
{
    /// <summary>
    /// 数据验证类
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// 是否数字字符串 可带正负号
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsNumberSign(this string src)
        {
            return Regex.IsMatch(src, "^[+-]?[0-9]+$");
        }
        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string src)
        {
            return Regex.IsMatch(src, "^[0-9]+[.]?[0-9]+$");
        }
        /// <summary>
        /// 是否是浮点数 可带正负
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsDecimalSign(this string src)
        {
            return Regex.IsMatch(src, "^[+-]?[0-9]+[.]?[0-9]+$");
        }
        /// <summary>
        /// 是否包含数字
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsChinese(this string src)
        {
            return Regex.IsMatch(src, "[\u4e00-\u9fa5]");
        }
        /// <summary>
        /// 身份证验证
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public static bool IsPersonId(this string src)
        {
            return Regex.IsMatch(src, @"^\(d{15})(\d{2}[Xx0-9])?$");
        }
        /// <summary>
        /// 返回字符串的真实长度(中文2个字符长度,英文一个字符长度)
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int GetLength(this string src)
        {
            int len = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (Encoding.UTF8.GetBytes(src.Substring(i, 1)).Length > 1)
                {
                    len += 2;
                }
                else
                {
                    len++;
                }
            }
            return len;
        }
        /// <summary>
        /// 返回只能以正负号开头的整数
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsInt2(string str)
        {
            return Regex.IsMatch(str, @"^([+-]?)\d*$");
        }
        /// <summary>
        /// 检测是否数字
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsInt(this string src)
        {
            return Regex.IsMatch(src, @"^\d+?$");
        }
        /// <summary>
        /// 判断指定的字符串是否可转换为数字
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsNumber(this string src)
        {
            return Regex.IsMatch(src, @"^(-?\d+)(\.\d+)?$");
        }
        /// <summary>
        /// 是否为日期型字符串
        /// </summary>
        /// <param >日期字符串(2008-05-08)</param>
        /// <returns></returns>
        public static bool IsDate(this string src)
        {
            return Regex.IsMatch(src, @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
        }
        /// <summary>
        /// 是否为时间型字符串
        /// </summary>
        /// <param >时间字符串(15:00:00)</param>
        /// <returns></returns>
        public static bool IsTime(string src)
        {
            return Regex.IsMatch(src, @"^((20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsEmail(this string src)
        {
            return Regex.IsMatch(src, "^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil)$");
        }
        /// <summary>
        /// 是否为日期+时间型字符串
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        public static bool IsDateTime(string src)
        {
            return Regex.IsMatch(src, @"^(((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$ ");
        }
    }
}
