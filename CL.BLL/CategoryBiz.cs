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
            return base.GetMaxId(idField, tableName);
        }

        /// <summary>
        /// 获取最大id+1的值
        /// </summary>
        /// <returns></returns>
        public int GetMaxNextId()
        {
            return GetMaxId() + 1;
        }

        /// <summary>
        /// 获取所有的顶级类型
        /// </summary>
        /// <returns></returns>
        public List<Model.Category> GetAllTopCategory()
        {
            return GetAll();
            //return GetList(c => c.IParentId == 0);
        }
    }
}
