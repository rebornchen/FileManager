using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using NLite.Data;
using CL.Model.Interfaces;
using CL.Common;
using CL.Model;
using System.Data;

namespace CL.BLL
{


    #region 数据操作类
    /// <summary>
    /// 
    /// </summary>
    internal sealed class Db
    {
        private Db() { }
        /// <summary>
        /// 
        /// </summary>

        //internal static readonly DbConfiguration cfg = DbConfiguration
        //            .Configure("myCon")
        //            .SetSqlLogger(() => new SqlLog(Console.Out))
        //            .AddFromAssemblyOf<IEntity>(p => typeof(IEntity)
        //            .IsAssignableFrom(p));
        private static DbConfiguration _cfg;
        internal static DbConfiguration cfg
        {
            get
            {
                if (_cfg == null)
                {
                    //System.Data.Common.DbConnection conn =
                    //    System.Data.Common.DbProviderFactories.GetFactory("System.Data.SQLite").CreateConnection();

                    //conn.ConnectionString = "Data Source=filedb.db;Persist Security Info=True";
                    //conn.Open();

                    try
                    {
                        _cfg = DbConfiguration
                        .Configure("SQLiteELinq")
                        //.ConfigureSQLite("filedb.db")
                        .SetSqlLogger(() => new SqlLog(Console.Out))
                        .AddFromAssemblyOf<IEntity>(p => typeof(IEntity)
                        .IsAssignableFrom(p));

                       // DbConfiguration.ConfigureSQLite("filedb.db")
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
                return _cfg;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        //internal static System.Web.Caching.Cache Cache = System.Web.HttpRuntime.Cache;
    }
    /// <summary>
    /// 业务逻辑操作基类，包含了增删改查基本操作，基承
    /// 于本类的类可以覆写相关方法、增加具体的一些方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Base<T> where T : class, IEntity, new()
    {
        protected static readonly DbConfiguration cfg = Db.cfg;

        #region 添加
        /// <summary>
        /// 新增一个实例对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual bool Add(T model)
        {
            using (var ctx = new DbContext(cfg))
            {
                return ctx.Set<T>().Insert(model) > 0;
            }
        }
        /// <summary>
        /// 批量增加实例对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual bool Add(List<T> list)
        {
            using (var ctx = new DbContext(cfg))
            {
                int counta = list.Count;
                int countb = ctx.Set<T>().Batch<T>(list, (s, e) => s.Insert(e)).Count();
                return (counta == countb);
            }
        }
        #endregion

        #region 删除

        /// <summary>
        /// 删除一个实例对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual bool Delete(T model)
        {
            using (var ctx = new DbContext(cfg))
            {
                return ctx.Set<T>().Delete(model) > 0;
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public virtual bool Delete(List<T> models)
        {
            using (var ctx = new DbContext(cfg))
            {
                int counta = models.Count;
                int countb = ctx.Set<T>().Batch<T>(models, (s, e) => s.Delete(e)).Count();
                return (counta == countb);
            }
        }

        #endregion

        #region 更新

        /// <summary>
        /// 更新一个实例对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual bool Update(T model)
        {
            using (var ctx = new DbContext(cfg))
            {
                return ctx.Set<T>().Update(model) > 0;
            }
        }

        /// <summary>
        /// 更新多个实体对象
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual bool Update(List<T> models)
        {
            using (var ctx = new DbContext(cfg))
            {
                int counta = models.Count;
                int countb = ctx.Set<T>().Batch<T>(models, (s, e) => s.Update(e)).Count();
                return (counta == countb);
            }
        }

        #endregion

        #region 查询

        /// <summary>
        /// 通过实体Id获取对应的实体，Id可以是单Id也可以
        /// 是联合Id，如果是联合Id那么以数组的形式作为参数
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual T GetOne(object Id)
        {
            using (var ctx = new DbContext(cfg))
            {
                return ctx.Set<T>().Get(Id);
            }
        }

        /// <summary>
        /// Modify by xiao rui ,目的：获取某个实体类型的所有实列(取表所有Deleted=0的记录，Deleted=1表示数据已经删除)
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetAll()
        {

            string deletedfiled = "Deleted";
            Type t = typeof(T);
            PropertyInfo field = t.GetProperty(deletedfiled);
            using (var ctx = new DbContext(cfg))
            {
                if (field != null)
                {
                    ///
                    //var query = from contact in ctx.Set<T>().ToList()
                    //            where Convert.ToInt32(contact.GetType().GetProperty("Deleted").GetValue(contact,null)) == 0
                    //            select contact;
                    return ctx.Set<T>().ToList().Where(m => Convert.ToInt32(m.GetType().GetProperty(deletedfiled).GetValue(m, null)) == 0).ToList();
                }
                else
                {
                    return ctx.Set<T>().ToList();
                }

            }
        }


        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="whereFunc"></param>
        /// <param name="order"></param>
        /// <param name="isASC"></param>
        /// <returns></returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> whereFunc,
                Expression<Func<T, Object>> order = null, bool isASC = true)
        {
            using (DbContext ctx = new DbContext(cfg))
            {
                IQueryable<T> query = ctx.Set<T>().Where(whereFunc);
                if (order != null)
                {
                    if (isASC)
                    {
                        query = query.OrderBy(order);
                    }
                    else
                    {
                        query = query.OrderByDescending(order);
                    }
                }
                if (query == null)
                {
                    return null;
                }
                else
                {
                    return query.ToList();
                }
            }
        }
        #endregion

        #region 缓存

        ///// <summary>
        ///// 获取某个实体类型的所有实列(从缓存取，适合高频度、公用数据，如Product,Customer,Tank等)
        ///// </summary>
        ///// <returns></returns>
        //public virtual List<T> GetAllCached()
        //{
        //    using (var ctx = new DbContext(cfg))
        //    {
        //        string key = typeof(T).FullName;
        //        if (Db.Cache[key] == null)
        //            Db.Cache[key] = ctx.Set<T>().ToList();
        //        return Db.Cache[key] as List<T>;
        //    }
        //}
        ///// <summary>
        ///// 重置某个实体类型的所有实列(从缓存取，适合高频度、公用数据，如Product,Customer,Tank等)
        ///// </summary>
        //public virtual void RemoveCached()
        //{
        //    string key = typeof(T).FullName;
        //    if (Db.Cache[key] != null)
        //        Db.Cache.Remove(key);
        //}
        ///// <summary>
        ///// 清除指定类型的实体的所有实例
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        //public virtual void RemoveCached<T>() where T : class,IEntity
        //{
        //    string key = typeof(T).FullName;
        //    if (Db.Cache[key] != null)
        //        Db.Cache.Remove(key);
        //}
        ///// <summary>
        ///// 清除缓存中所有的对象
        ///// </summary>
        //public virtual void RemoveAllCached()
        //{
        //    Db.Cache.Clear();
        //}

        #endregion

        #region 用于翻页的方法
        /// <summary>
        /// 翻页仅适用于维护信息(信息量较少的表）：注意Index从0开始
        /// totalCount是总数
        /// datas表示每页详细信息
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public virtual Hashtable GetListByPaging(int startIndex, int limit, Func<T, object> orderFunc)
        {
            //从缓存中取数据
            //List<T> list = GetAllCached();

            //直接取数据
            List<T> list = null;
            using (var ctx = new DbContext(cfg))
            {
                list = ctx.Set<T>().ToList();
            }


            if (null != orderFunc)
            {
                list.OrderBy(orderFunc);//排序
            }
            startIndex = startIndex < list.Count ? startIndex : list.Count - 1;
            int count = startIndex + limit < list.Count ? limit : list.Count - startIndex;

            Hashtable hashtable = new Hashtable();
            hashtable.Add("totalCount", list.Count);
            hashtable.Add("datas", list.GetRange(startIndex, count));
            return hashtable;
        }

        public class OrderParams
        {
            public string property { get; set; }
            public string direction { get; set; }
        }

        /// <summary>
        /// 获取排序参数
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual List<OrderParams> GetOrderParams(string sort)
        {
            List<OrderParams> OPList = new List<OrderParams>();//排序参数表
            if (!string.IsNullOrEmpty(sort))
            {
                OPList = (List<OrderParams>)(sort.ToObject(typeof(List<OrderParams>)));
            }

            return OPList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderField"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public virtual Hashtable GetListByPaging(int startIndex, int pageSize, string orderField = null, bool isASC = true, List<NLite.Dynamic.Filter> filters = null)
        {
            using (DbContext ctx = new DbContext(cfg))
            {
                QueryContext qctx = new QueryContext();
                if (!string.IsNullOrEmpty(orderField))
                {
                    qctx.Property = orderField.Trim();
                    qctx.SortOrder = isASC ? NLite.SortOrder.Ascending : NLite.SortOrder.Descending;
                }
                qctx.PageIndex = startIndex / pageSize;
                qctx.PageSize = pageSize;
                qctx.Data = filters;

                IPagination<T> pagination = ctx.Set<T>().ToPagination<T>(qctx);

                Hashtable hashtable = new Hashtable();
                hashtable.Add("totalCount", pagination.TotalRowCount);
                hashtable.Add("datas", pagination.ToList());
                return hashtable;
            }
        }

        /// <summary>
        /// 包含当前页、分页大小、总页数、总记录数和当前页数据的类
        /// </summary>
        public class PagingClass
        {
            /// <summary>
            /// 当前页
            /// </summary>
            public int PageIndex { get; set; }
            /// <summary>
            /// 分页大小
            /// </summary>
            public int PageSize { get; set; }
            /// <summary>
            /// 总页数
            /// </summary>
            public int TotalPageCount { get; set; }
            /// <summary>
            /// 总记录数
            /// </summary>
            public int TotalRowCount { get; set; }
            /// <summary>
            /// 当前页的数据
            /// </summary>
            public List<T> Data { get; set; }
            public PagingClass()
            {
                PageIndex = 1;
                PageSize = 20;
                TotalPageCount = 0;
                TotalRowCount = 10;
                Data = new List<T>();
            }
        }

        /// <summary>
        /// 根据查询条件获取数据
        /// </summary>
        /// <param name="orderField">排序字段，若为null将由系统自动选择排序字段</param>
        /// <param name="orderDirection">排序方式（ASC|DESC），若为null将使用升序（ASC）</param>
        /// <param name="sqlWhereString">
        /// <para>查询条件（sql语句where那一部分，不用包含where关键字）</para>
        /// <para>例如：</para>
        /// <para>ID > 45 and (PName like '%as%' or Quality = 'high')</para>
        /// <para>请严格遵循Sql server 的sql语句规范</para></param>
        /// <param name="fulltextSearchText">全文搜索的查询文本</param>
        /// <param name="fulltextSearchFields">
        /// <para>全文搜索限定字段（多个字段中间用英文逗号(,)分隔）</para>
        /// <para>限定只在某些列中进行全文搜索</para>
        /// <para>例如："PName,Quality"</para></param>
        /// <returns></returns>
        public virtual PagingClass GetDataBySearch(
            string orderField = null,
            string orderDirection = null,
            string sqlWhereString = null,
            string fulltextSearchText = null,
            string fulltextSearchFields = null
        )
        {
            System.Reflection.PropertyInfo[] PropInfoArr = typeof(T).GetProperties();

            string[] PropNameArr = PropInfoArr.Select(x => x.Name).ToArray();
            if (string.IsNullOrEmpty(orderField) && PropNameArr.Length > 0)
            {
                //将第一个字段作为默认排序字段
                orderField = PropNameArr[0];
            }

            //拼接Sql语句
            using (DbContext ctx = new DbContext(cfg))
            {
                string CurrentTableName = ctx.Set<T>().Mapping.TableName;   //当前连接的表名
                StringBuilder SBSql = new StringBuilder();                  //完整的Sql语句
                StringBuilder SBSqlWhere = new StringBuilder();             //where那一部分的sql语句
                if (!string.IsNullOrEmpty(fulltextSearchText))
                {
                    //先处理全文搜索的部分
                    //如果有限定全文搜索的字段，则对全文搜索进行限定
                    if (!string.IsNullOrEmpty(fulltextSearchFields))
                    {
                        //用逗号分割限定字段，将属性数组的元素限定为这些字段
                        string[] searchFieldArr = fulltextSearchFields.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        PropInfoArr = PropInfoArr.Where(p => searchFieldArr.Contains(p.Name)).ToArray();
                    }

                    fulltextSearchText = fulltextSearchText.Replace(";", "").Replace("--", "").Replace("\'", "");

                    //将多个连续的空格替换为单个空格（包括全角空格）
                    fulltextSearchText = Regex.Replace(fulltextSearchText, @"[ 　]+", " ", RegexOptions.IgnoreCase);
                    List<string> SearchTextList = fulltextSearchText.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                    foreach (string str in SearchTextList)
                    {
                        SBSqlWhere.Append("and (");
                        StringBuilder sb = new StringBuilder();
                        foreach (PropertyInfo p in PropInfoArr)
                        {
                            sb.AppendFormat("or {0} like N'%{1}%'", p.Name, str);
                        }
                        sb.Remove(0, 3);//将最开始的or关键字和空格移除
                        SBSqlWhere.Append(sb);
                        SBSqlWhere.Append(")");
                    }

                    if (!string.IsNullOrEmpty(SBSqlWhere.ToString()))
                    {
                        //将最开始的and关键字和空格移除
                        SBSqlWhere = SBSqlWhere.Remove(0, 4);

                        //把整个放在括号里
                        SBSqlWhere.Insert(0, "and (");
                        SBSqlWhere.Append(")");
                        //SBSqlWhere.Insert(0, "where ");         //在最开始添加where关键字
                    }
                }

                if (!string.IsNullOrEmpty(sqlWhereString))
                {
                    //把整个放括号里
                    sqlWhereString = " and (" + sqlWhereString + ")";
                    SBSqlWhere.Append(sqlWhereString);
                }

                if (!string.IsNullOrEmpty(SBSqlWhere.ToString()))
                {
                    //将最开始的and关键字和空格移除，并添加where关键字
                    SBSqlWhere.Remove(0, 4);
                    SBSqlWhere.Insert(0, "where ");
                }

                //拼装Sql语句
                SBSql.Append("select cnt.totalcnt,basetbl.* from (");
                SBSql.AppendFormat("select row_number() over(order by {0}) as rowindex, * from {1} {2}",
                    orderField, CurrentTableName, SBSqlWhere.ToString());
                SBSql.Append(") as basetbl,(");
                SBSql.AppendFormat("select count(1) as totalcnt from {0} {1}", CurrentTableName, SBSqlWhere.ToString());
                SBSql.Append(") as cnt");

                System.Data.DataTable ResultDT = ctx.DbHelper.ExecuteDataTable(SBSql.ToString());

                //获得总记录数后，删除多余的列（totalcnt, rowindex）
                int TotalRowCount = ResultDT.Rows.Count == 0 ? 0 : Convert.ToInt32(ResultDT.Rows[0]["totalcnt"]);
                ResultDT.Columns.Remove("totalcnt");
                ResultDT.Columns.Remove("rowindex");

                PagingClass Paging = new PagingClass();
                Paging.Data = ResultDT.ToGenericList<T>();
                Paging.TotalRowCount = TotalRowCount;
                if (Paging.PageIndex > Paging.TotalPageCount)
                {
                    Paging.PageIndex = Paging.TotalPageCount;
                }
                return Paging;
            }
        }


        /// <summary>
        /// 根据页码、分页大小和查询条件获取数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="orderField">排序字段，若为null将由系统自动选择排序字段</param>
        /// <param name="orderDirection">排序方式（ASC|DESC），若为null将使用升序（ASC）</param>
        /// <param name="sqlWhereString">
        /// <para>查询条件（sql语句where那一部分，不用包含where关键字）</para>
        /// <para>例如：</para>
        /// <para>ID > 45 and (PName like '%as%' or Quality = 'high')</para>
        /// <para>请严格遵循Sql server 的sql语句规范</para></param>
        /// <param name="fulltextSearchText">全文搜索的查询文本</param>
        /// <param name="fulltextSearchFields">
        /// <para>全文搜索限定字段（多个字段中间用英文逗号(,)分隔）</para>
        /// <para>限定只在某些列中进行全文搜索</para>
        /// <para>例如："PName,Quality"</para></param>
        /// <returns></returns>
        public virtual PagingClass GetDataByPageAndSearch(
            int pageIndex,
            int pageSize,
            string orderField = null,
            string orderDirection = null,
            string sqlWhereString = null,
            string fulltextSearchText = null,
            string fulltextSearchFields = null
        )
        {
            System.Reflection.PropertyInfo[] PropInfoArr = typeof(T).GetProperties();
            string[] PropNameArr = PropInfoArr.Select(x => x.Name).ToArray();
            if (PropNameArr.Length == 0) throw new ArgumentNullException("对象为空引用");


            string[] orderDirectionArray = null;
            if (!string.IsNullOrEmpty(orderDirection))
            {
                orderDirectionArray = orderDirection.Split(',');
            }

            string orderSQL = string.Empty;
            if (string.IsNullOrEmpty(orderField))
            {
                //将第一个字段作为默认排序字段
                orderField = PropNameArr[0];
                if (orderDirectionArray == null)
                {
                    orderSQL = string.Format(" {0} ASC ", orderField);
                }
                else
                {
                    orderSQL = string.Format(" {0} {1} ", orderField, orderDirectionArray[0]);
                }
            }
            else
            {

                StringBuilder orderBuilder = new StringBuilder();
                string[] fieldArray = orderField.Split(',');
                for (int i = 0; i < fieldArray.Length; i++)
                {
                    string orderStr = "ASC";
                    if (orderDirectionArray != null && orderDirectionArray.Length > 0)
                    {
                        if (i < orderDirectionArray.Length)
                        {
                            orderStr = orderDirectionArray[i];
                        }
                    }

                    if (i == fieldArray.Length - 1)
                    {
                        orderBuilder.AppendFormat(" {0} {1} ", fieldArray[i], orderStr);
                    }
                    else
                    {
                        orderBuilder.AppendFormat(" {0} {1}, ", fieldArray[i], orderStr);
                    }
                }
                orderSQL = orderBuilder.ToString();
            }



            //拼接Sql语句
            using (DbContext ctx = new DbContext(cfg))
            {
                string CurrentTableName = ctx.Set<T>().Mapping.TableName;   //当前连接的表名
                StringBuilder SBSql = new StringBuilder();                  //完整的Sql语句
                StringBuilder SBSqlWhere = new StringBuilder();             //where那一部分的sql语句
                if (!string.IsNullOrEmpty(fulltextSearchText))
                {
                    //先处理全文搜索的部分
                    //如果有限定全文搜索的字段，则对全文搜索进行限定
                    if (!string.IsNullOrEmpty(fulltextSearchFields))
                    {
                        //用逗号分割限定字段，将属性数组的元素限定为这些字段
                        string[] searchFieldArr = fulltextSearchFields.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        PropInfoArr = PropInfoArr.Where(p => searchFieldArr.Contains(p.Name)).ToArray();
                    }

                    fulltextSearchText = fulltextSearchText.Replace(";", "").Replace("--", "").Replace("\'", "");

                    //将多个连续的空格替换为单个空格（包括全角空格）
                    fulltextSearchText = Regex.Replace(fulltextSearchText, @"[ 　]+", " ", RegexOptions.IgnoreCase);
                    List<string> SearchTextList = fulltextSearchText.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                    foreach (string str in SearchTextList)
                    {
                        SBSqlWhere.Append("and (");
                        StringBuilder sb = new StringBuilder();
                        foreach (PropertyInfo p in PropInfoArr)
                        {
                            sb.AppendFormat("or {0} like N'%{1}%'", p.Name, str);
                        }
                        sb.Remove(0, 3);//将最开始的or关键字和空格移除
                        SBSqlWhere.Append(sb);
                        SBSqlWhere.Append(")");
                    }

                    if (!string.IsNullOrEmpty(SBSqlWhere.ToString()))
                    {
                        //将最开始的and关键字和空格移除
                        SBSqlWhere = SBSqlWhere.Remove(0, 4);

                        //把整个放在括号里
                        SBSqlWhere.Insert(0, "and (");
                        SBSqlWhere.Append(")");
                        //SBSqlWhere.Insert(0, "where ");         //在最开始添加where关键字
                    }
                }

                if (!string.IsNullOrEmpty(sqlWhereString))
                {
                    //把整个放括号里
                    sqlWhereString = " and (" + sqlWhereString + ")";
                    SBSqlWhere.Append(sqlWhereString);
                }

                if (!string.IsNullOrEmpty(SBSqlWhere.ToString()))
                {
                    //将最开始的and关键字和空格移除，并添加where关键字
                    SBSqlWhere.Remove(0, 4);
                    SBSqlWhere.Insert(0, "where ");
                }

                pageIndex = pageIndex < 1 ? 1 : pageIndex;
                int StartRowIndex = (pageIndex - 1) * pageSize + 1;
                int EndRowIndex = pageIndex * pageSize;

                //拼装Sql语句
                SBSql.Append("select cnt.totalcnt,basetbl.* from (");
                SBSql.AppendFormat("select row_number() over(order by {0}) as rowindex, * from {1} {2}",
                    orderSQL, CurrentTableName, SBSqlWhere.ToString());
                SBSql.Append(") as basetbl,(");
                SBSql.AppendFormat("select count(1) as totalcnt from {0} {1}", CurrentTableName, SBSqlWhere.ToString());
                SBSql.Append(") as cnt");
                SBSql.AppendFormat(" where basetbl.rowindex >={0} and basetbl.rowindex <={1}", StartRowIndex, EndRowIndex);

                System.Data.DataTable ResultDT = ctx.DbHelper.ExecuteDataTable(SBSql.ToString());

                //获得总记录数后，删除多余的列（totalcnt, rowindex）
                int TotalRowCount = ResultDT.Rows.Count == 0 ? 0 : Convert.ToInt32(ResultDT.Rows[0]["totalcnt"]);
                ResultDT.Columns.Remove("totalcnt");
                ResultDT.Columns.Remove("rowindex");

                PagingClass Paging = new PagingClass();
                Paging.Data = ResultDT.ToGenericList<T>();
                Paging.PageIndex = pageIndex;
                Paging.PageSize = pageSize;
                Paging.TotalPageCount = (int)Math.Ceiling((double)TotalRowCount / pageSize);
                Paging.TotalRowCount = TotalRowCount;
                if (Paging.PageIndex > Paging.TotalPageCount)
                {
                    Paging.PageIndex = Paging.TotalPageCount;
                }
                return Paging;
            }
        }


        /// <summary>
        /// 对数据先分组，再分页
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="orderField">排序字段，若为null将由系统自动选择排序字段</param>
        /// <param name="orderDirection">排序方式（ASC|DESC），若为null将使用升序（ASC）</param>
        /// <param name="sqlWhereString">
        /// <para>查询条件（sql语句where那一部分，不用包含where关键字）</para>
        /// <para>例如：</para>
        /// <para>ID > 45 and (PName like '%as%' or Quality = 'high')</para>
        /// <para>请严格遵循Sql server 的sql语句规范</para></param>
        /// <param name="fulltextSearchText">全文搜索的查询文本</param>
        /// <param name="fulltextSearchFields">
        /// <para>全文搜索限定字段（多个字段中间用英文逗号(,)分隔）</para>
        /// <para>限定只在某些列中进行全文搜索</para>
        /// <para>例如："PName,Quality"</para></param>
        /// <returns></returns>
        public virtual PagingClass GetDataByPageAndSearchWithGroupBy(
            int pageIndex,
            int pageSize,
            string orderField = null,
            string orderDirection = null,
            string sqlWhereString = null,
            string fulltextSearchText = null,
            string fulltextSearchFields = null
            )
        {
            System.Reflection.PropertyInfo[] PropInfoArr = typeof(T).GetProperties();

            string[] PropNameArr = PropInfoArr.Select(x => x.Name).ToArray();
            if (string.IsNullOrEmpty(orderField) && PropNameArr.Length > 0)
            {
                //将第一个字段作为默认排序字段
                orderField = PropNameArr[0];
            }
            //Added by XiaoRui,排序
            if (!string.IsNullOrEmpty(orderDirection))
            {
                orderDirection = (orderDirection.ToLower() == "desc") ? "desc" : "asc";
            }



            //拼接Sql语句
            using (DbContext ctx = new DbContext(cfg))
            {
                string CurrentTableName = ctx.Set<T>().Mapping.TableName;   //当前连接的表名
                StringBuilder SBSql = new StringBuilder();                  //完整的Sql语句
                StringBuilder SBSqlWhere = new StringBuilder();             //where那一部分的sql语句
                if (!string.IsNullOrEmpty(fulltextSearchText))
                {
                    //先处理全文搜索的部分
                    //如果有限定全文搜索的字段，则对全文搜索进行限定
                    if (!string.IsNullOrEmpty(fulltextSearchFields))
                    {
                        //用逗号分割限定字段，将属性数组的元素限定为这些字段
                        string[] searchFieldArr = fulltextSearchFields.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        PropInfoArr = PropInfoArr.Where(p => searchFieldArr.Contains(p.Name)).ToArray();
                    }

                    fulltextSearchText = fulltextSearchText.Replace(";", "").Replace("--", "").Replace("\'", "");

                    //将多个连续的空格替换为单个空格（包括全角空格）
                    fulltextSearchText = Regex.Replace(fulltextSearchText, @"[ 　]+", " ", RegexOptions.IgnoreCase);
                    List<string> SearchTextList = fulltextSearchText.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                    foreach (string str in SearchTextList)
                    {
                        SBSqlWhere.Append("and (");
                        StringBuilder sb = new StringBuilder();
                        foreach (PropertyInfo p in PropInfoArr)
                        {
                            sb.AppendFormat("or {0} like N'%{1}%'", p.Name, str);
                        }
                        sb.Remove(0, 3);//将最开始的or关键字和空格移除
                        SBSqlWhere.Append(sb);
                        SBSqlWhere.Append(")");
                    }

                    if (!string.IsNullOrEmpty(SBSqlWhere.ToString()))
                    {
                        //将最开始的and关键字和空格移除
                        SBSqlWhere = SBSqlWhere.Remove(0, 4);

                        //把整个放在括号里
                        SBSqlWhere.Insert(0, "and (");
                        SBSqlWhere.Append(")");
                        //SBSqlWhere.Insert(0, "where ");         //在最开始添加where关键字
                    }
                }

                if (!string.IsNullOrEmpty(sqlWhereString))
                {
                    //把整个放括号里
                    sqlWhereString = " and (" + sqlWhereString + ")";
                    SBSqlWhere.Append(sqlWhereString);
                }

                if (!string.IsNullOrEmpty(SBSqlWhere.ToString()))
                {
                    //将最开始的and关键字和空格移除，并添加where关键字
                    SBSqlWhere.Remove(0, 4);
                    SBSqlWhere.Insert(0, "where ");
                }

                pageIndex = pageIndex < 1 ? 1 : pageIndex;
                int StartRowIndex = (pageIndex - 1) * pageSize + 1;
                int EndRowIndex = pageIndex * pageSize;

                //用于GROUP BY 的字段
                string keyItems = "MaterialId, MaterialCName, MaterialEName, Mode,UnitId, UnitCName, UnitEName, TotalQuantity,Location, " +
                     "LargeClassCName, LargeClassEName, MiddleClassCName, MiddleClassEName, SmallClassCName, SmallClassEName, ItemCName, ItemEName, MaterialDesc, Remark";

                //拼装Sql语句
                //SBSql.Append("select cnt.totalcnt,basetbl.* from (");
                //SBSql.AppendFormat("select row_number() over(order by {0} {3}) as rowindex, {4} from {1} {2}",
                //    orderField, CurrentTableName, SBSqlWhere.ToString(), orderDirection == null ? "asc" : orderDirection,keyItems);
                //SBSql.AppendFormat(" group by {0}) as basetbl,(",keyItems);
                //SBSql.AppendFormat("select count(1) as totalcnt from {0} {1}", CurrentTableName, SBSqlWhere.ToString());
                //SBSql.AppendFormat(" group by {0}) as cnt",keyItems);
                //SBSql.AppendFormat(" where basetbl.rowindex >={0} and basetbl.rowindex <={1}", StartRowIndex, EndRowIndex);



                SBSql.AppendFormat("select * from (select ROW_NUMBER() over(order by {0} {1}) as rowindex,(select COUNT(*)  from (select MaterialId from {2} {3}" +
                    " group by {4} ) as t) as totalcnt,{4} from {2} {3} group by {4} ) as t1 where t1.rowindex >={5} and t1.rowindex <={6}",
                    orderField, orderDirection == null ? "asc" : orderDirection, CurrentTableName, SBSqlWhere.ToString(), keyItems, StartRowIndex, EndRowIndex);





                //SBSql.AppendFormat("select cnt.totalcnt,basetbl.* from (select row_number() over(order by DeptMaterialID asc) as rowindex, {0}, 0 AS DeptQuantity " +
                //    " from uv_whDeptMaterial where  (DeptId<>{1} group by {0})) as basetbl,(select count(1) as totalcnt from uv_whDeptMaterial where  (DeptId<>{1} group by {0})) " +
                //    "as cnt where basetbl.rowindex >={2} and basetbl.rowindex <={3}", keyItems, sqlWhereString, StartRowIndex, EndRowIndex);


                System.Data.DataTable ResultDT = ctx.DbHelper.ExecuteDataTable(SBSql.ToString());

                //获得总记录数后，删除多余的列（totalcnt, rowindex）
                int TotalRowCount = ResultDT.Rows.Count == 0 ? 0 : Convert.ToInt32(ResultDT.Rows[0]["totalcnt"]);
                ResultDT.Columns.Remove("totalcnt");
                ResultDT.Columns.Remove("rowindex");

                PagingClass Paging = new PagingClass();
                Paging.Data = ResultDT.ToGenericList<T>();
                Paging.PageIndex = pageIndex;
                Paging.PageSize = pageSize;
                Paging.TotalPageCount = (int)Math.Ceiling((double)TotalRowCount / pageSize);
                Paging.TotalRowCount = TotalRowCount;
                if (Paging.PageIndex > Paging.TotalPageCount)
                {
                    Paging.PageIndex = Paging.TotalPageCount;
                }
                return Paging;
            }
        }





        /// <summary>
        /// <para>将字符串转换成Nlite的filter</para>
        /// <para>每个条件之间用英文分号分隔(;)</para>
        /// <para>条件里面，字段名、操作符、值用竖线分隔(|)</para>
        /// </summary>
        /// <param name="inputStr">输入字符串</param>
        /// <returns></returns>
        public List<NLite.Dynamic.Filter> GetNliteFilter(string inputStr)
        {
            List<NLite.Dynamic.Filter> Result = new List<NLite.Dynamic.Filter>();

            if (string.IsNullOrWhiteSpace(inputStr))
            {
                return Result;
            }

            //拆分每个条件
            string[] Conditions = inputStr.Split(';').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            //拆分条件里面的字段名、操作符和值
            foreach (string cond in Conditions)
            {
                string[] paramArr = cond.Split('|');
                if (paramArr.Length != 3)
                {
                    continue;
                }
                NLite.Dynamic.Filter f = new NLite.Dynamic.Filter();
                f.Field = paramArr[0];
                f.Value = paramArr[2];
                //转换操作符
                switch (paramArr[1].ToLower())
                {
                    case "=":
                        f.Operation = NLite.Dynamic.OperationType.Equal;
                        break;
                    case "<":
                        f.Operation = NLite.Dynamic.OperationType.Less;
                        break;
                    case ">":
                        f.Operation = NLite.Dynamic.OperationType.Greater;
                        break;
                    case "<=":
                        f.Operation = NLite.Dynamic.OperationType.LessOrEqual;
                        break;
                    case ">=":
                        f.Operation = NLite.Dynamic.OperationType.GreaterOrEqual;
                        break;
                    case "like":
                        f.Operation = NLite.Dynamic.OperationType.Contains;
                        f.Value = paramArr[2].Replace("%", "");
                        break;
                    case "not like":
                        f.Operation = NLite.Dynamic.OperationType.NotContains;
                        f.Value = paramArr[2].Replace("%", "");
                        break;
                    default:
                        break;
                }
                Result.Add(f);
            }

            return Result;
        }

        /// <summary>
        /// 根据当前页码、分页大小和查询条件获取数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="orderField">排序字段，默认为null</param>
        /// <param name="orderDirection">排序方式：asc| desc，默认为asc</param>
        /// <param name="condition">
        /// <para>查询条件，默认为null，条件之间是“且”的关系</para>
        /// <para>示例："Name|=|ab;Description|like|www"</para>
        /// <para>相当于sql的：where Name = 'ab' and Description like '%www%'</para>
        /// </param>
        /// <param name="searchField">全文搜索限定字段，多个字段用英文逗号(,)隔开，默认为null：不限定</param>
        /// <param name="searchText">全文搜索关键字，默认为null</param>
        /// <returns></returns>
        public virtual PagingClass GetDataByPagingAndSearch(
            int pageIndex,
            int pageSize,
            string orderField = null,
            string orderDirection = null,
            string condition = null,
            string searchField = null,
            string searchText = null
        )
        {
            System.Reflection.PropertyInfo[] PropInfoArr = typeof(T).GetProperties();

            string[] PropNameArr = PropInfoArr.Select(x => x.Name).ToArray();
            if (string.IsNullOrEmpty(orderField) && PropNameArr.Length > 0)
            {
                //将第一个字段作为默认排序字段
                orderField = PropNameArr[0];
            }



            //处理全文搜索的条件
            List<NLite.Dynamic.Filter> filtersList = new List<NLite.Dynamic.Filter>();
            if (!string.IsNullOrEmpty(searchText))
            {
                //如果有限定全文搜索的字段，则对全文搜索进行限定
                if (!string.IsNullOrEmpty(searchField))
                {
                    //用逗号分割限定字段，在属性数组中取这些字段
                    string[] searchFieldArr = searchField.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    PropInfoArr = PropInfoArr.Where(p => searchFieldArr.Contains(p.Name)).ToArray();
                }
                //将多个连续的空格替换为单个空格（包括全角空格）
                searchText = Regex.Replace(searchText, @"[ 　]+", " ", RegexOptions.IgnoreCase);
                List<string> SearchTextList = searchText.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                for (int i = 0; i < SearchTextList.Count; i++)
                {
                    Guid g = Guid.NewGuid();//or条件分组的唯一标识
                    foreach (System.Reflection.PropertyInfo pInfo in PropInfoArr)
                    {
                        NLite.Dynamic.Filter filter = new NLite.Dynamic.Filter();
                        filter.OrGroup = "{" + g.ToString("N") + "}";
                        filter.Field = pInfo.Name;
                        try
                        {
                            string TypeName = pInfo.PropertyType.FullName.ToLower();
                            //如果是数字类型
                            if (TypeName.Contains("int")
                                || TypeName.Contains("double")
                                || TypeName.Contains("float"))
                            {
                                filter.Operation = NLite.Dynamic.OperationType.Equal;
                            }
                            else
                            {
                                filter.Operation = NLite.Dynamic.OperationType.Contains;
                            }

                            //如果是可为空的泛型类型
                            if (pInfo.PropertyType.IsGenericType
                                && pInfo.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                            {
                                //获取Nullable的基础类型
                                Type NullableType = Nullable.GetUnderlyingType(pInfo.PropertyType);
                                filter.Value = Convert.ChangeType(SearchTextList[i], NullableType);
                            }
                            else
                            {
                                filter.Value = Convert.ChangeType(SearchTextList[i], pInfo.PropertyType);
                            }
                        }
                        catch
                        {
                            continue;
                        }
                        filtersList.Add(filter);
                    }
                }
            }

            if (!string.IsNullOrEmpty(condition))
            {
                filtersList.AddRange(GetNliteFilter(condition));
            }

            using (DbContext ctx = new DbContext(cfg))
            {
                QueryContext qctx = new QueryContext();
                if (!string.IsNullOrEmpty(orderField))
                {
                    qctx.Property = orderField.Trim();
                    qctx.SortOrder = (!string.IsNullOrEmpty(orderDirection) && orderDirection.ToLower() == "desc")
                        ? NLite.SortOrder.Descending
                        : NLite.SortOrder.Ascending;
                }
                qctx.PageIndex = pageIndex < 1 ? 0 : pageIndex - 1;
                qctx.PageSize = pageSize;
                qctx.Data = filtersList;

                IPagination<T> pagination = ctx.Set<T>().ToPagination<T>(qctx);

                PagingClass Paging = new PagingClass();
                Paging.PageIndex = (int)qctx.PageIndex + 1;
                Paging.PageSize = pageSize;
                Paging.TotalPageCount = (int)Math.Ceiling((double)pagination.TotalRowCount / pageSize);
                Paging.TotalRowCount = pagination.TotalRowCount;
                Paging.Data = pagination.ToList();
                return Paging;
            }
        }

        /// <summary>
        /// 获取指定条件的记录数（原始方法）
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public virtual int Count(string tablename, string strWhere)
        {
            strWhere = string.IsNullOrEmpty(strWhere) ? "1=1" : strWhere;
            using (var ctx = new DbContext(cfg))
            {
                try
                {
                    return int.Parse(ctx.DbHelper.ExecuteScalar(string.Format("select count(*) from {0} where {1}", tablename, strWhere)).ToString());
                }
                catch
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 获取指定条件的记录数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual int Count(Func<T, bool> predicate)
        {
            using (var ctx = new DbContext(cfg))
            {
                return ctx.Set<T>().Count(predicate);
            }
        }
        /// <summary>
        /// 获取计划的总数
        /// </summary>
        /// <returns></returns>
        public virtual int TotalCount()
        {
            using (var ctx = new DbContext(cfg))
            {
                return ctx.Set<T>().Count();
            }
        }
        #endregion Count

        #region 逻辑删除

        /// <summary>
        /// 逻辑删除数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual bool DeleteByLogic(T model)
        {
            return UpdateDeletedStatus(model);
        }

        /// <summary>
        /// 修改表中删除标记的状态
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        private bool UpdateDeletedStatus(T model)
        {
            bool result = false;

            //判断是否有deleted 属性
            bool hasDeletedProperty = false;
            var propertiesList = typeof(T).GetProperties();
            foreach (var p in propertiesList)
            {
                if (p.Name.ToLower() == "deleted")
                {
                    hasDeletedProperty = true;
                    break;
                }
            }
            //如果有deleted 属性，进行修改标记操作
            if (hasDeletedProperty)
            {
                //model.GetType().GetProperty("Deleted").GetValue(model, null) == 0
                PropertyInfo propertyDeleted = model.GetType().GetProperty("Deleted");
                int deletedNewValue = Convert.ToInt32(propertyDeleted.GetValue(model, null)) == 0 ? 1 : 0;
                propertyDeleted.SetValue(model, deletedNewValue, null);
                using (var ctx = new DbContext(cfg))
                {
                    result = ctx.Set<T>().Update(model) > 0;
                }
            }

            return result;
        }

        #endregion


        #region 公用功能
        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <param name="fieldname"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        protected int GetMaxId(string fieldname, string tablename)
        {

            string idField = fieldname;
            string tableName = tablename;
            string sql = String.Format("select isnull(MAX({0}),0) as maxId from {1}", idField, tableName);

            using (var ctx = new DbContext(cfg))
            {
                DataTable dt = ctx.DbHelper.ExecuteDataTable(sql);
                return Convert.ToInt32(dt.Rows[0][0]);
            }
        }
        #endregion
    }


    #endregion
}
