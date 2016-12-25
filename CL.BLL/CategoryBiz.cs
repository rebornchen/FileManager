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

        /// <summary>
        /// 获取类型列表
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <returns></returns>
        public List<Category> GetCategories(List<int> categoryIds)
        {
            return GetList(c => categoryIds.Contains(c.ICId));
        }

        /// <summary>
        /// 根据文件实体，获取相应类型列表
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public List<Category> GetCategories(Files file)
        {
            return GetCategories(file.IFId);
        }

        /// <summary>
        /// 根据文件id，获取相应类型列表
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public List<Category> GetCategories(int fileId)
        {
            FileCategoryRelationsBiz fcrBiz = new FileCategoryRelationsBiz();
            var fcrList = fcrBiz.GetList(fcr => fcr.IFId == fileId);
            return GetCategories(fcrList.Select(fcr => fcr.ICId).ToList());
        }
    }
}
