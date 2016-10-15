using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL.Model;
using System.Data;
using NLite.Data;

namespace CL.BLL
{
    /// <summary>
    /// 类型模块 逻辑代码
    /// </summary>
    public class CategoryBiz : CL.BLL.Base<Category>
    {
        /// <summary>
        /// 获取最大id
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {

            string idField = "ICId";
            string tableName = "T_Category";
            string sql = String.Format("select isnull(MAX({0}),0) as maxId from {1}", idField, tableName);

            using (var ctx = new DbContext(cfg))
            {
                DataTable dt = ctx.DbHelper.ExecuteDataTable(sql);
                return Convert.ToInt32(dt.Rows[0][0]);
            }
        }

        /// <summary>
        /// 获取最大id+1的值
        /// </summary>
        /// <returns></returns>
        public int GetMaxNextId()
        {
            return GetMaxId() + 1;
        }
    }
}
