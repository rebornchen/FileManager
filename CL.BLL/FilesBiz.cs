using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL.Model;

namespace CL.BLL
{
    public class FilesBiz : CL.BLL.Base<Files>
    {
        /// <summary>
        /// 获取下一个id值
        /// </summary>
        /// <returns></returns>
        public int GetMaxNext()
        {
            string idField = "IFId";
            string tablename = "T_Files";
            return GetMaxNextId(idField, tablename);
        }
    }
}
