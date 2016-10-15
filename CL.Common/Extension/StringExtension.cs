using System;
using System.Text;

using Microsoft.VisualBasic;
namespace CL.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 将字符串转换为数字，不是数字返回【0】
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Int64 ToInt64(this string src)
        {
            if (src.Trim().IsInt())
            {
                return Convert.ToInt64(src);
            }
            return 0;
        }
        /// <summary>
        /// 将字符串转换为数字，不是数字返回【0】
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this string src)
        {
            if (src.Trim().IsInt())
            {
                return Convert.ToInt32(src);
            }
            return 0;
        }
        /// <summary>
        /// 返回年月日格式的字符串
        /// </summary>
        /// <returns></returns>
        public static string ToDateString(this string src)
        {
            try
            {
                return DateTime.ParseExact(src,
                    new string[] { "yyyy-MM-dd", "dd-MM-yyyy" },
                    Manager.frculture, System.Globalization.DateTimeStyles.None).ToString(Manager.cfUSDate);
            }
            catch
            {
                return src;
            }
        }
        /// <summary>
        /// 返回年月日格式的字符串
        /// </summary>
        /// <returns></returns>
        public static DateTime ToDate(this string src)
        {
            try
            {
                DateTime defaultValue = new DateTime(1753, 1, 1);
                if (DateTime.TryParseExact(src,
                    new string[] { "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd", "yyyy-MM-dd'T'HH:mm:ss", "dd-MM-yyyy" },
                    Manager.frculture, System.Globalization.DateTimeStyles.None, out defaultValue))
                    return defaultValue;
                else
                    return new DateTime(1753, 1, 1);
            }
            catch
            {
                return new DateTime(1753, 1, 1);
            }
        }
        /// <summary>
        /// 将字符串转换为日期，不是日期返回【1753-1-1】
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string src)
        {
            //The first if is added by chengdh
            //if (src.Contains("/"))
            //    return Convert.ToDateTime(src);
            if (src.Contains("T"))
                return Convert.ToDateTime(src.Split('T')[0]);
            if (src.Trim().IsDate())
                return Convert.ToDateTime(src);
            return Convert.ToDateTime(src.ToDateString());
            //return new DateTime(1753, 1, 1);
        }
        /// <summary>
        /// 将字符串转换为数字，不是数字返回【0】
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static double ToDouble(this string src)
        {
            if (src.Trim().IsNumber())
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
        public static decimal ToDecimal(this string src)
        {
            if (src.Trim().IsNumber())
            {
                return Convert.ToDecimal(src);
            }
            return 0;
        }
        /// <summary>
        /// 将字符串转换为数字，不是数字返回【0】
        /// </summary>
        /// <param name="src"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static double ToDouble(this string src, int decimals)
        {
            if (src.Trim().IsNumber())
            {
                double number = Convert.ToDouble(src);
                return System.Math.Round(number, decimals);
            }
            return 0;
        }
        /// <summary>
        /// 字符串加密(非对称)
        /// </summary>
        /// <param name="Plaintext">明文</param>
        /// <returns>密文</returns>
        public static string ToMD5String(this string Plaintext)
        {
            #region 代码实现
            string tempString = string.Empty;
            string ciphertext = string.Empty;
            //实例化一个MD5对像
            System.Security.Cryptography.MD5 Instance = System.Security.Cryptography.MD5.Create();
            byte[] Buffer = Instance.ComputeHash(Encoding.Default.GetBytes(Plaintext));
            for (int i = 0; i < Buffer.Length; i++)
            {
                tempString = Buffer[i].ToString("X");
                if (tempString.Length == 1)
                {
                    tempString = "0" + tempString;
                }
                ciphertext += tempString;
            }
            return ciphertext;
            #endregion
        }
        /// <summary>
        /// 目标字符串与源字符串是否相等，忽略大小写
        /// </summary>
        /// <param name="src"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Compares(this string src, string text)
        {
            return src.Equals(text, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// 返回指定字符串添加前缀后的形式
        /// </summary>
        /// <param name="src"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string AddPrefix(this string src, string prefix)
        {
            return string.Concat(prefix, src);
        }
        /// <summary>
        /// 返回指定字符串添加前缀后的形式
        /// </summary>
        /// <param name="src"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string AddPrefix(this string src, char prefix)
        {
            return string.Concat(prefix, src);
        }
        /// <summary>
        /// 返回指定字符串添加后缀后的形式
        /// </summary>
        /// <param name="src"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string AddSuffix(this string src, string suffix)
        {
            return string.Concat(src, suffix);
        }
        /// <summary>
        /// 返回指定字符串添加后缀后的形式
        /// </summary>
        /// <param name="src"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string AddSuffix(this string src, char suffix)
        {
            return string.Concat(src, suffix);
        }
        /// <summary>
        /// 返回指定字符串删除前缀后的形式
        /// </summary>
        /// <param name="src"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string DelPrefix(this string src, string prefix)
        {
            if (src.IndexOf(prefix) == 0)
                src = src.Remove(0, prefix.Length);
            return src;
        }
        /// <summary>
        /// 返回指定字符串删除前缀后的形式
        /// </summary>
        /// <param name="src"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string DelPrefix(this string src, char prefix)
        {
            return src.TrimStart(prefix);
        }
        /// <summary>
        /// 返回指定字符串删除后缀后的形式
        /// </summary>
        /// <param name="src"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string DelSuffix(this string src, string suffix)
        {
            int len = suffix.Length;
            int start = src.LastIndexOf(suffix);
            if (start >= 0)
                if (src.Length == (start + len))
                    return src.Remove(start, len);
            return src;
        }
        /// <summary>
        /// 返回指定字符串删除后缀后的形式
        /// </summary>
        /// <param name="src"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string DelSuffix(this string src, char suffix)
        {
            return src.TrimEnd(suffix);
        }
        /// <summary>
        /// 返回匹配项在指定字符串中第一次出现位置左边的内容
        /// </summary>
        /// <param name="src"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string LeftOf(this string src, string val)
        {
            if (String.IsNullOrEmpty(src))
                return src;

            string ret = src;
            int idx = src.IndexOf(val);
            if (idx != -1)
            {
                ret = src.Substring(0, idx);
            }
            return ret;
        }
        /// <summary>
        /// 返回匹配项在指定字符串中第一次出现位置左边的内容
        /// </summary>
        /// <param name="src"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string LeftOf(this string src, char val)
        {
            return LeftOf(src, val.ToString());
        }
        /// <summary>
        /// 返回匹配项在指定字符串中第‘n’次出现位置左边的内容
        /// </summary>
        /// <param name="src"></param>
        /// <param name="val"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string LeftOf(this string src, string val, int n)
        {
            if (String.IsNullOrEmpty(src))
                return src;

            string ret = src;
            int idx = -1;
            while (n > 0)
            {
                idx = src.IndexOf(val, idx + 1);
                if (idx == -1)
                {
                    break;
                }
                --n;
            }
            if (idx != -1)
            {
                ret = src.Substring(0, idx);
            }
            return ret;
        }
        /// <summary>
        /// 返回匹配项在指定字符串中第‘n’次出现位置左边的内容
        /// </summary>
        /// <param name="src"></param>
        /// <param name="val"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string LeftOf(this string src, char val, int n)
        {
            return LeftOf(src, val.ToString(), n);
        }
        /// <summary>
        /// 返回匹配项在指定字符串中第一次出现位置右边的内容
        /// </summary>
        /// <param name="src"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string RightOf(this string src, string val)
        {
            string ret = String.Empty;
            int idx = src.IndexOf(val);
            if (idx != -1)
            {
                idx += val.Length - 1;
                ret = src.Substring(idx + 1);
            }
            return ret;
        }
        /// <summary>
        /// 返回匹配项在指定字符串中第一次出现位置右边的内容
        /// </summary>
        /// <param name="src"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string RightOf(this string src, char val)
        {
            return RightOf(src, val.ToString());
        }
        /// <summary>
        /// 返回匹配项在指定字符串中第n次出现位置右边的内容
        /// </summary>
        /// <param name="src"></param>
        /// <param name="val"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string RightOf(this string src, string val, int n)
        {
            if (String.IsNullOrEmpty(src))
                return src;

            string ret = String.Empty;
            int idx = -1;
            while (n > 0)
            {
                idx = src.IndexOf(val, idx + 1);
                if (idx == -1)
                {
                    break;
                }
                --n;
            }

            if (idx != -1)
            {
                ret = src.Substring(idx + 1);
            }

            return ret;
        }
        /// <summary>
        /// 返回字符在指定字符串中第n次出现位置右边的内容
        /// </summary>
        /// <param name="src"></param>
        /// <param name="val"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string RightOf(this string src, char val, int n)
        {
            return RightOf(src, val.ToString(), n);
        }
        /// <summary>
        /// 返回字符串中两个匹配项（字符）间的子串
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string Between(this string src, char start, char end)
        {
            return Between(src, start.ToString(), end.ToString());
        }
        /// <summary>
        /// 返回字符串中两个匹配项（字符串）间的子串
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string Between(this string src, string start, string end)
        {
            if (String.IsNullOrEmpty(src))
                return src;

            string ret = String.Empty;
            if (String.IsNullOrEmpty(src))
                return ret;

            int idxStart = src.IndexOf(start);
            if (idxStart != -1)
            {
                ++idxStart;
                int idxEnd = src.IndexOf(end, idxStart);
                if (idxEnd != -1)
                {
                    ret = src.Substring(idxStart, idxEnd - idxStart);
                }
            }
            return ret;
        }
        /// <summary>
        /// 返回字符在字符串中出现的次数
        /// </summary>
        /// <param name="src"></param>
        /// <param name="c"></param>
        /// <param name="flag">是否处理转义字符</param>
        /// <returns></returns>
        private static int Count(this string src, char c, bool flag)
        {
            int n = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i].Equals(c))
                {
                    if (flag) // 如果处理转义
                    {
                        if (0 != i && src[i - 1] != '\\')//判断找到字符的前一个字符不是转义字符则++
                        {
                            n++;
                            continue;
                        }
                        else //反之，判断找到字符紧邻右边的字符是不是一样的，如果是则过滤掉
                        {
                            for (i++; i < src.Length; i++)
                            {
                                if (!src[i].Equals(c)) break;
                            }
                        }
                    }
                    else n++;
                }
            }
            return n;
        }
        /// <summary>
        /// 返回字符在字符串中出现的次数
        /// </summary>
        /// <param name="src"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int Count(this string src, char c)
        {
            if (String.IsNullOrEmpty(src))
                return 0;

            return Count(src, c, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string LastLeftOf(this string src, char c)
        {
            if (String.IsNullOrEmpty(src))
                return src;

            string ret = src;
            int idx = src.LastIndexOf(c);
            if (idx != -1)
            {
                ret = src.Substring(0, idx);
            }
            return ret;
        }
        /// <summary>
        /// 返回字符在指定字符串中最后一次次出现位置的右边内容
        /// </summary>
        /// <param name="src"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string LastRightOf(this string src, char c)
        {
            string ret = String.Empty;
            int idx = src.LastIndexOf(c);
            if (idx != -1)
            {
                ret = src.Substring(idx + 1);
            }
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this string str)
        {
            return Encoding.Default.GetBytes(str);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] GetBytesUTF8(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] GetBytesASCII(this string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
        /// <summary>
        /// 转换为全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>        
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }
        /// <summary>
        /// 转换为半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        /// <summary>
        /// 简体中文转换为繁体中文
        /// </summary>
        /// <param name="text">任意字符串</param>
        /// <returns>繁体中文</returns>
        public static string ToTraditional(this string text)
        {
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetterOrDigit(chars[i]))
                {
                    chars[i] = Strings.StrConv(text, VbStrConv.Wide, 0)[0]; // 半角转全角
                    chars[i] = Strings.StrConv(text, VbStrConv.TraditionalChinese, 0)[0]; // 简体转繁体
                }
            }
            return new string(chars);
        }
        /// <summary>
        /// 繁体中文转换为简体中文,全角转换为半角
        /// </summary>
        /// <param name="text">任意字符串</param>
        /// <returns>简体中文</returns>
        public static string ToSimplified(this string text)
        {
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetterOrDigit(chars[i]))
                {
                    chars[i] = Strings.StrConv(chars[i].ToString(), VbStrConv.Narrow, 0)[0]; // 全角转半角
                    chars[i] = Strings.StrConv(chars[i].ToString(), VbStrConv.SimplifiedChinese, 0)[0]; // 繁体转简体
                }
            }
            return new string(chars);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsChineseLatter(this string src)
        {
            for (int i = 0; i < src.Length; i++)
            {
                if ((int)src[i] > (char)'z')
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 返回给定字符串的首字母
        /// </summary>
        /// <param name="IndexText"></param>
        /// <returns></returns>
        public static string IndexCode(this string IndexText)
        {
            string temporary = null;
            for (int i = 0; i < IndexText.Length; i++)
                temporary = temporary + GetOneIndex(IndexText.Substring(i, 1));
            return temporary;
        }
        /// <summary>
        /// 得到单个字符的首字母
        /// </summary>
        /// <param name="OneIndexTxt"></param>
        /// <returns></returns>
        private static string GetOneIndex(string OneIndexTxt)
        {
            if (Convert.ToChar(OneIndexTxt) >= 0 && Convert.ToChar(OneIndexTxt) < 256)
            {
                return OneIndexTxt;
            }
            else
            {
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                byte[] unicodeBytes = Encoding.Unicode.GetBytes(OneIndexTxt);
                byte[] gb2312Bytes = Encoding.Convert(Encoding.Unicode, gb2312, unicodeBytes);
                return GetSpell(Convert.ToInt32(
                String.Format("{0:D2}", Convert.ToInt16(gb2312Bytes[0]) - 160)
                + String.Format("{0:D2}", Convert.ToInt16(gb2312Bytes[1]) - 160)
                ));
            }
        }
        /// <summary>
        /// 根据区位得到首字母
        /// </summary>
        /// <param name="GBCode"></param>
        /// <returns></returns>
        private static string GetSpell(int GBCode)
        {
            if (GBCode >= 1601 && GBCode < 1637) return "A";
            if (GBCode >= 1637 && GBCode < 1833) return "B";
            if (GBCode >= 1833 && GBCode < 2078) return "C";
            if (GBCode >= 2078 && GBCode < 2274) return "D";
            if (GBCode >= 2274 && GBCode < 2302) return "E";
            if (GBCode >= 2302 && GBCode < 2433) return "F";
            if (GBCode >= 2433 && GBCode < 2594) return "G";
            if (GBCode >= 2594 && GBCode < 2787) return "H";
            if (GBCode >= 2787 && GBCode < 3106) return "J";
            if (GBCode >= 3106 && GBCode < 3212) return "K";
            if (GBCode >= 3212 && GBCode < 3472) return "L";
            if (GBCode >= 3472 && GBCode < 3635) return "M";
            if (GBCode >= 3635 && GBCode < 3722) return "N";
            if (GBCode >= 3722 && GBCode < 3730) return "O";
            if (GBCode >= 3730 && GBCode < 3858) return "P";
            if (GBCode >= 3858 && GBCode < 4027) return "Q";
            if (GBCode >= 4027 && GBCode < 4086) return "R";
            if (GBCode >= 4086 && GBCode < 4390) return "S";
            if (GBCode >= 4390 && GBCode < 4558) return "T";
            if (GBCode >= 4558 && GBCode < 4684) return "W";
            if (GBCode >= 4684 && GBCode < 4925) return "X";
            if (GBCode >= 4925 && GBCode < 5249) return "Y";
            if (GBCode >= 5249 && GBCode <= 5589) return "Z";
            if (GBCode >= 5601 && GBCode <= 8794)
            {
                string CodeData = "cjwgnspgcenegypbtwxzdxykygtpjnmjqmbsgzscyjsyyfpggbzgydywjkgaljswkbjqhyjwpdzlsgmr"
                                + "ybywwccgznkydgttngjeyekzydcjnmcylqlypyqbqrpzslwbdgkjfyxjwcltbncxjjjjcxdtqsqzycdxxhgckbphffss"
                                + "pybgmxjbbyglbhlssmzmpjhsojnghdzcdklgjhsgqzhxqgkezzwymcscjnyetxadzpmdssmzjjqjyzcjjfwqjbdzbjgd"
                                + "nzcbwhgxhqkmwfbpbqdtjjzkqhylcgxfptyjyyzpsjlfchmqshgmmxsxjpkdcmbbqbefsjwhwwgckpylqbgldlcctnma"
                                + "eddksjngkcsgxlhzaybdbtsdkdylhgymylcxpycjndqjwxqxfyyfjlejbzrwccqhqcsbzkymgplbmcrqcflnymyqmsqt"
                                + "rbcjthztqfrxchxmcjcjlxqgjmshzkbswxemdlckfsydsglycjjssjnqbjctyhbftdcyjdgwyghqfrxwckqkxebpdjpx"
                                + "jqsrmebwgjlbjslyysmdxlclqkxlhtjrjjmbjhxhwywcbhtrxxglhjhfbmgykldyxzpplggpmtcbbajjzyljtyanjgbj"
                                + "flqgdzyqcaxbkclecjsznslyzhlxlzcghbxzhznytdsbcjkdlzayffydlabbgqszkggldndnyskjshdlxxbcghxyggdj"
                                + "mmzngmmccgwzszxsjbznmlzdthcqydbdllscddnlkjyhjsycjlkohqasdhnhcsgaehdaashtcplcpqybsdmpjlpcjaql"
                                + "cdhjjasprchngjnlhlyyqyhwzpnccgwwmzffjqqqqxxaclbhkdjxdgmmydjxzllsygxgkjrywzwyclzmcsjzldbndcfc"
                                + "xyhlschycjqppqagmnyxpfrkssbjlyxyjjglnscmhcwwmnzjjlhmhchsyppttxrycsxbyhcsmxjsxnbwgpxxtaybgajc"
                                + "xlypdccwqocwkccsbnhcpdyznbcyytyckskybsqkkytqqxfcwchcwkelcqbsqyjqcclmthsywhmktlkjlychwheqjhtj"
                                + "hppqpqscfymmcmgbmhglgsllysdllljpchmjhwljcyhzjxhdxjlhxrswlwzjcbxmhzqxsdzpmgfcsglsdymjshxpjxom"
                                + "yqknmyblrthbcftpmgyxlchlhlzylxgsssscclsldclepbhshxyyfhbmgdfycnjqwlqhjjcywjztejjdhfblqxtqkwhd"
                                + "chqxagtlxljxmsljhdzkzjecxjcjnmbbjcsfywkbjzghysdcpqyrsljpclpwxsdwejbjcbcnaytmgmbapclyqbclzxcb"
                                + "nmsggfnzjjbzsfqyndxhpcqkzczwalsbccjxpozgwkybsgxfcfcdkhjbstlqfsgdslqwzkxtmhsbgzhjcrglyjbpmljs"
                                + "xlcjqqhzmjczydjwbmjklddpmjegxyhylxhlqyqhkycwcjmyhxnatjhyccxzpcqlbzwwwtwbqcmlbmynjcccxbbsnzzl"
                                + "jpljxyztzlgcldcklyrzzgqtgjhhgjljaxfgfjzslcfdqzlclgjdjcsnclljpjqdcclcjxmyzftsxgcgsbrzxjqqcczh"
                                + "gyjdjqqlzxjyldlbcyamcstylbdjbyregklzdzhldszchznwczcllwjqjjjkdgjcolbbzppglghtgzcygezmycnqcycy"
                                + "hbhgxkamtxyxnbskyzzgjzlqjdfcjxdygjqjjpmgwgjjjpkjsbgbmmcjssclpqpdxcdyykypcjddyygywchjrtgcnyql"
                                + "dkljczzgzccjgdyksgpzmdlcphnjafyzdjcnmwescsglbtzcgmsdllyxqsxsbljsbbsgghfjlwpmzjnlyywdqshzxtyy"
                                + "whmcyhywdbxbtlmswyyfsbjcbdxxlhjhfpsxzqhfzmqcztqcxzxrdkdjhnnyzqqfnqdmmgnydxmjgdhcdycbffallztd"
                                + "ltfkmxqzdngeqdbdczjdxbzgsqqddjcmbkxffxmkdmcsychzcmljdjynhprsjmkmpcklgdbqtfzswtfgglyplljzhgjj"
                                + "gypzltcsmcnbtjbhfkdhbyzgkpbbymtdlsxsbnpdkleycjnycdykzddhqgsdzsctarlltkzlgecllkjljjaqnbdggghf"
                                + "jtzqjsecshalqfmmgjnlyjbbtmlycxdcjpldlpcqdhsycbzsckbzmsljflhrbjsnbrgjhxpdgdjybzgdlgcsezgxlblg"
                                + "yxtwmabchecmwyjyzlljjshlgndjlslygkdzpzxjyyzlpcxszfgwyydlyhcljscmbjhblyjlycblydpdqysxktbytdkd"
                                + "xjypcnrjmfdjgklccjbctbjddbblblcdqrppxjcglzcshltoljnmdddlngkaqakgjgyhheznmshrphqqjchgmfprxcjg"
                                + "dychghlyrzqlcngjnzsqdkqjymszswlcfqjqxgbggxmdjwlmcrnfkkfsyyljbmqammmycctbshcptxxzzsmphfshmclm"
                                + "ldjfyqxsdyjdjjzzhqpdszglssjbckbxyqzjsgpsxjzqznqtbdkwxjkhhgflbcsmdldgdzdblzkycqnncsybzbfglzzx"
                                + "swmsccmqnjqsbdqsjtxxmbldxcclzshzcxrqjgjylxzfjphymzqqydfqjjlcznzjcdgzygcdxmzysctlkphtxhtlbjxj"
                                + "lxscdqccbbqjfqzfsltjbtkqbsxjjljchczdbzjdczjccprnlqcgpfczlclcxzdmxmphgsgzgszzqjxlwtjpfsyaslcj"
                                + "btckwcwmytcsjjljcqlwzmalbxyfbpnlschtgjwejjxxglljstgshjqlzfkcgnndszfdeqfhbsaqdgylbxmmygszldyd"
                                + "jmjjrgbjgkgdhgkblgkbdmbylxwcxyttybkmrjjzxqjbhlmhmjjzmqasldcyxyqdlqcafywyxqhz";
                string _gbcode = GBCode.ToString();
                int pos = (Convert.ToInt16(_gbcode.Substring(0, 2)) - 56) * 94 + Convert.ToInt16(_gbcode.Substring(_gbcode.Length - 2, 2));
                return CodeData.Substring(pos - 1, 1);
            }
            return " ";
        }
        /// <summary>
        /// 把Json字符串反序列化为对象
        /// </summary>
        /// <param name="json">json字符串</param>
        /// <param name="type">目标对象类型</param>
        /// <returns></returns>
        public static object ToObject(this string json, Type type)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(json, type);
        }
    }
}
