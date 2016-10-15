using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.UI.Logic
{
    public class FileCompare
    {
        #region 私有变量
        /// <summary>
        /// 数据库中的文件对象
        /// </summary>
        private Model.Files DBFile { get; set; }
        /// <summary>
        /// 物理文件对象
        /// </summary>
        private Model.Files PhysicalFile { get; set; }
        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="dbFile"></param>
        /// <param name="physicalFile"></param>
        public FileCompare(Model.Files dbFile, Model.Files physicalFile)
        {
            this.DBFile = dbFile;
            this.PhysicalFile = physicalFile;
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="dbFile"></param>
        /// <param name="filePath"></param>
        public FileCompare(Model.Files dbFile, string filePath)
        {
            this.DBFile = dbFile;
            PhysicalFile = UILogic.GetFileModelByFilePath(filePath);
        }
        #endregion

        //如果
        public void Campare()
        {
            //DBFile.

        }

        /// <summary>
        /// 判断和处理文件比较结果
        /// </summary>
        /// <returns></returns>
        public EnumFileCompareResult FileComparer()
        {
            EnumFileCompareResult result;
            if (DBFile.CFileName != PhysicalFile.CFileName)
            {
                result = EnumFileCompareResult.ErrorCompare;
            }
            else if (DBFile.TLastUpdateTime == PhysicalFile.TLastUpdateTime)
            {
                result = EnumFileCompareResult.Same;
            }
            else
            {
                result = DBFile.TLastUpdateTime > PhysicalFile.TLastUpdateTime
                    ? EnumFileCompareResult.FirstIsNew : EnumFileCompareResult.SecondIsNew;
            }
            return result;
        }
    }
}
