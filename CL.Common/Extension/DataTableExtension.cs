using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CL.Common
{
    public static class DataTableExtension
    {
        /// <summary>
        /// 将DataTable转换成指定类型的泛型集合
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="source">要转换的DataTable</param>
        /// <returns></returns>
        public static List<T> ToGenericList<T>(this DataTable source)
        {
            List<T> Result = new List<T>();
            PropertyInfo[] PropInfoArr = typeof(T).GetProperties();
            try
            {
                foreach (DataRow dr in source.Rows)
                {
                    T model = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in PropInfoArr)
                    {
                        if (dr.Table.Columns.Contains(prop.Name) && dr[prop.Name] != DBNull.Value)
                        {
                            try
                            {
                                prop.SetValue(model, dr[prop.Name], null);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    Result.Add(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
    }
}
