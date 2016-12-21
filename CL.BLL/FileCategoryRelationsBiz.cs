using System;
using System.Collections.Generic;
using System.Linq;
using CL.Model;
using System.Text;
using NLite.Data;

namespace CL.BLL
{
    public class FileCategoryRelationsBiz : CL.BLL.Base<FileCategoryRelations>
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="iFId"></param>
        /// <param name="iCId"></param>
        public void Delete(int iFId, int iCId)
        {
            List<FileCategoryRelations> list = GetList(fcr => fcr.ICId == iCId && fcr.IFId == iFId);
            Delete(list);
        }

        /// <summary>
        /// 根据文件类型id，获取文件
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <returns></returns>
        public List<FileCategoryRelations> GetFileCategoryRelations(List<int> categoryIds)
        {
            /***
             * 待修改
             * 
             * ************/
            List<FileCategoryRelations> result = new List<FileCategoryRelations>();
            if (categoryIds == null || categoryIds.Count == 0)
            {
                return result;
            }
            using (DbContext ctx = new DbContext(cfg))
            {


                string sql = "select * from FileCategoryRelations ";



                int i = 1;
                foreach (int categoryid in categoryIds)
                {
                    string temp = String.Format("({0} where ICId = {1} ) t{2} on t1.IFId=t{2}.IFId ", sql, categoryid, i);
                    i++;
                }
            }
            return null;
        }
    }
}

//select * from FileCategoryRelations inner join ({0} where ICId = {1} ) t{2} on t1.Ifid=t{2}.ifid 


