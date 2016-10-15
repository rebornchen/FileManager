
using System.Data;
namespace CL.Common
{
    /// <summary>
    /// 数据对象处理
    /// </summary>
    public class Processor
    {
        /// <summary>
        /// 获取数据表的行数
        /// </summary>
        /// <param name="table">数据表对象</param>
        /// <returns></returns>
        public int GetRowCount(DataTable table)
        {
            return (table == null || table.Rows == null) ? -1 : table.Rows.Count;
        }
        /// <summary>
        /// 获取数据表的行数
        /// </summary>
        /// <param name="table">数据表对象</param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int GetRowCount(DataTable table, string condition)
        {
            DataRow[] rows = table.Select(condition);
            return (rows == null) ? -1 : rows.Length;
        }
        /// <summary>
        /// 获取数据表中的数值
        /// </summary>
        /// <param name="table">数据表对象</param>
        /// <param name="ColumnName">列名称</param>
        /// <param name="RowIndex">行索引</param>
        /// <returns>指定行列的数值</returns>
        public string GetColumnValue(DataTable table, string ColumnName, int RowIndex)
        {
            if (table == null ||
                table.Rows.Count == 0 ||
                table.Rows.Count <= RowIndex ||
                !table.Columns.Contains(ColumnName))
                return null;
            return table.Rows[RowIndex][ColumnName].ToString();
        }
        /// <summary>
        /// 获取数据表中的数值
        /// </summary>
        /// <param name="table">数据表对象</param>
        /// <param name="ColumnName">列名称</param>
        /// <param name="RowIndex">行索引</param>
        /// <param name="condition">过滤条件</param>
        /// <returns>指定行列的数值</returns>
        public string GetColumnValue(DataTable table, string ColumnName, int RowIndex, string condition)
        {
            if (GetRowCount(table, condition) <= 0) return null;
            return GetColumnValue(table, ColumnName, RowIndex);
        }
    }
}