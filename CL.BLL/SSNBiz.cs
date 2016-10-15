using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL.Model;
using NLite.Data;
using System.Data;
using CL.Common;


namespace CL.BLL
{
    public class SSNBiz : CL.BLL.Base<SSN>
    {
        /// <summary>
        /// 获取无关联email 的账户信息
        /// </summary>
        /// <param name="emailHost"></param>
        /// <returns></returns>
        public List<SSN> GetListByEmailHost(string emailHost, int number)
        {
            if (number < 1 || number > 100)
            {
                number = 100;
            }
            using (var ctx = new DbContext(cfg))
            {
                //list = ctx.Set<T>().ToList();
                string sql = string.Empty;

                sql += " SELECT top " + number.ToString() + "  [_Locked], [_SortKey], 全名, 性别, Firstname, Lastname, Middlename, 称呼, 生日, 州, 街道地址, 城市, 电话, 邮编, ";
                sql += " 州全称, SSN社会保险号, 网络用户名, 随机密码, 信用卡类型, 信用卡号, CVV2, 有效期, 职位, 所属公司, 身高, 体重, ";
                sql += " [_Identify]";
                sql += " FROM      SSN t";
                sql += " WHERE   ([_Identify] NOT IN";
                sql += " (SELECT   SSN.[_Identify]";
                sql += "  FROM      ((RSSNEmail INNER JOIN";
                sql += "                  SSN ON RSSNEmail.SSNName = SSN.网络用户名) INNER JOIN";
                sql += "                  SSNEmail ON RSSNEmail.SSNEmailAdd = SSNEmail.Email)";
                sql += "  WHERE   (SSNEmail.Remark <> '" + emailHost + "')))";

                DataTable dt = ctx.DbHelper.ExecuteDataTable(sql);
                return dt.ToGenericList<SSN>();
                //ctx.Set<SSN>().
                //ctx.DbHelper.
            }
        }

        /// <summary>
        /// 获取随机人员信息
        /// </summary>
        /// <param name="emailHost"></param>
        /// <returns></returns>
        public SSN GetRadomSSN(string emailHost)
        {
            var list = GetListByEmailHost(emailHost, 80);
            int count = list.Count;

            //如果没有符合条件的数据，则返回空
            if (count == 0)
            {
                return null;
            }

            Random rd = new Random();
            return list[rd.Next(0, count)];
        }

        public SSN GetRadomHotmailSSN()
        {
            return GetRadomSSN("hotmail");
        }
    }
}
