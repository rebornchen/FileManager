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
        public List<int> GetFileIds(List<int> categoryIds)
        {
            /***
             * 待修改
             * 
             * ************/
            List<int> result = new List<int>();
            if (categoryIds == null || categoryIds.Count == 0)
            {
                return result;
            }
            using (DbContext ctx = new DbContext(cfg))
            {
                string innerjoinSql = String.Empty;
                string whereSql = String.Format(" where t0.ICId={0} ", categoryIds[0]);
                //生成sql
                //1.生成 select 
                string selectSql = "select t0.IFId ";
                //2.生成 from
                string fromSql = " FROM [T_FileCategoryRelations] t0 ";
                //3.生成联表
                //4.生成where
                for (int i = 1; i < categoryIds.Count; i++)
                {
                    innerjoinSql += String.Format(" inner join [T_FileCategoryRelations] t{0} on t0.IFId=t{0}.IFId ", i);
                    whereSql += String.Format(" and t{0}.ICId={1} ", i, categoryIds[i]);
                }

                //5.形成完整的sql
                string sql = selectSql + fromSql + innerjoinSql + whereSql;

                //查询数据，并将数据转换成列表
                System.Data.DataTable dt = ctx.DbHelper.ExecuteDataTable(sql);
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    result.Add(Convert.ToInt32(row[0]));
                }
            }
            return result;
        }

        /// <summary>
        /// 添加类型和文件关联关系
        /// </summary>
        /// <param name="c"></param>
        /// <param name="file"></param>
        public void Add(Category c, Files file)
        {
            var list = GetList(r => r.IFId == file.IFId && r.ICId == c.ICId);
            if(list.Count > 0)
            {
                return;
            }
            FileCategoryRelations relation = new FileCategoryRelations();
            relation.ICId = c.ICId;
            relation.IFId = file.IFId;
            base.Add(relation);
        }
    }
}

//select * from FileCategoryRelations inner join ({0} where ICId = {1} ) t{2} on t1.Ifid=t{2}.ifid 
/*
 SELECT t1.IFId, t1.*,t2.*, t3.*
  FROM [T_FileCategoryRelations] t1 
  inner join [T_FileCategoryRelations] t2 on t1.IFId=t2.IFId
  inner join [T_FileCategoryRelations] t3 on t1.IFId=t3.IFId
  where t1.ICId=1 and t2.ICId=2 and t3.ICId=1
  ;

 * */


