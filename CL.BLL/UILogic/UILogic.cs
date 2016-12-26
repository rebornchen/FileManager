using CL.Common.Commons;
using CL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CL.UI.Logic
{
    /// <summary>
    /// 界面上各种操作产生的业务逻辑
    /// </summary>
    public class UILogic
    {
        #region 文件夹检查

        /// <summary>
        /// 确保一个路径的存在
        /// 判断，如果没有，会主动创建
        /// </summary>
        /// <param name="dirPath"></param>
        public static void EnsureDirectoryExists(string dirPath)
        {
            CL.Common.Commons.FileIOHelper.CreateDirectory(dirPath);
        }

        /// <summary>
        /// 确保一个路径的存在
        /// 判断，如果没有，会主动创建
        /// </summary>
        /// <param name="dirPath">存放的主路径</param>
        /// <param name="category">文件存放的类型</param>
        /// <param name="date">文件存放到哪个时间点的文件夹中</param>
        /// <param name="enumMethod">枚举：文件路径组织的类型</param>
        public static void EnsureDirectoryExists(string dirPath, string category, string date, EnumFileDirSaveMethod enumMethod)
        {
            CL.Common.Commons.FileIOHelper.CreateDirectory(GetFilePath(dirPath, category, date, enumMethod));
        }

        /// <summary>
        /// 确保一个路径的存在
        /// 判断，如果没有，会主动创建
        /// </summary>
        /// <param name="dirPath">存放的主路径</param>
        /// <param name="category">文件存放的类型</param>
        /// <param name="enumMethod">枚举：文件路径组织的类型</param>
        public static void EnsureDirectoryExists(string dirPath, string category, EnumFileDirSaveMethod enumMethod)
        {
            CL.Common.Commons.FileIOHelper.CreateDirectory(GetFilePath(dirPath, category, enumMethod));
        }



        #endregion

        #region 文件保存的路径
        /// <summary>
        /// 返回文件保存的路径，必须有指定的时间
        /// </summary>
        /// <param name="dirPath">存放的主路径</param>
        /// <param name="category">文件存放的类型</param>
        /// <param name="date">文件存放到哪个时间点的文件夹中</param>
        /// <param name="enumMethod">枚举：文件路径组织的类型</param>
        public static string GetFilePath(string dirPath, string category, string date, EnumFileDirSaveMethod enumMethod)
        {
            CL.UI.Logic.DirPath.DirPathRule result = null;
            if (enumMethod == EnumFileDirSaveMethod.DateFirst)
            {
                CL.UI.Logic.DirPath.DirPathRule dirRule = new CL.UI.Logic.DirPath.DirPathRule(dirPath);
                CL.UI.Logic.DirPath.DateRule dateRule = new CL.UI.Logic.DirPath.DateRule(dirRule, date);
                result = new UI.Logic.DirPath.CategoryRule(dateRule, category);
            }
            else
            {
                CL.UI.Logic.DirPath.DirPathRule dirRule = new CL.UI.Logic.DirPath.DirPathRule(dirPath);
                CL.UI.Logic.DirPath.CategoryRule categoryRule = new UI.Logic.DirPath.CategoryRule(dirRule, category);
                result = new CL.UI.Logic.DirPath.DateRule(categoryRule, date);
            }

            return result.GetPath();
        }

        /// <summary>
        /// 返回文件保存的路径，无需指定的时间，默认为当前月份
        /// </summary>
        /// <param name="dirPath">存放的主路径</param>
        /// <param name="category">文件存放的类型</param>
        /// <param name="enumMethod">枚举：文件路径组织的类型</param>
        /// <returns></returns>
        public static string GetFilePath(string dirPath, string category, EnumFileDirSaveMethod enumMethod)
        {
            CL.UI.Logic.DirPath.DirPathRule result = null;
            if (enumMethod == EnumFileDirSaveMethod.DateFirst)
            {
                CL.UI.Logic.DirPath.DirPathRule dirRule = new CL.UI.Logic.DirPath.DirPathRule(dirPath);
                CL.UI.Logic.DirPath.DateRule dateRule = new CL.UI.Logic.DirPath.DateRule(dirRule);
                result = new UI.Logic.DirPath.CategoryRule(dateRule, category);
            }
            else
            {
                CL.UI.Logic.DirPath.DirPathRule dirRule = new CL.UI.Logic.DirPath.DirPathRule(dirPath);
                CL.UI.Logic.DirPath.CategoryRule categoryRule = new UI.Logic.DirPath.CategoryRule(dirRule, category);
                result = new CL.UI.Logic.DirPath.DateRule(categoryRule);
            }

            return result.GetPath();
        }
        #endregion


        #region 文件信息获取
        /// <summary>
        /// 根据路径获取文件信息，并转换为model
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Files GetFileModelByFilePath(string filePath)
        {
            Files f = new Files();

            f.CFullName = filePath;
            f.CDir = System.IO.Path.GetDirectoryName(filePath);
            f.CFileName = FileIOHelper.GetFileName(filePath);
            f.CExtention = FileIOHelper.GetExtension(filePath);
            f.IFileLength = FileIOHelper.GetFileSize(filePath);
            f.TCreateTime = System.IO.File.GetCreationTime(filePath);
            f.TLastUpdateTime = System.IO.File.GetLastWriteTime(filePath);
            f.IStatus = 0;
            f.TSysCheckDateTime = System.DateTime.Now;
            f.CRemark = "";
            f.TKeyWords = "";

            return f;
        }

        /// <summary>
        /// 2个文件对比，并返回比较的结果
        /// </summary>
        /// <param name="firstFileModel"></param>
        /// <param name="secondFileModel"></param>
        public static EnumFileCompareResult FileComparer(Files firstFileModel, Files secondFileModel)
        {
            EnumFileCompareResult result;
            if (firstFileModel.CFileName != secondFileModel.CFileName)
            {
                result = EnumFileCompareResult.ErrorCompare;
            }
            else if(firstFileModel.TLastUpdateTime == secondFileModel.TLastUpdateTime)
            {
                result = EnumFileCompareResult.Same;
            }
            else
            {
                result = firstFileModel.TLastUpdateTime > secondFileModel.TLastUpdateTime
                    ? EnumFileCompareResult.FirstIsNew : EnumFileCompareResult.SecondIsNew;
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 更新文件信息
        /// </summary>
        public static void UpdateFileInfos(string filename)
        {
            
        }

        /// <summary>
        /// 检查文件路径是否还存在
        /// </summary>
        /// <param name="fileModel"></param>
        public static bool CheckPathExists(Files fileModel)
        {
            return System.IO.File.Exists(fileModel.CFullName);
        }

        #region 根据目录获取 文件 和 子目录信息
        /// <summary>
        /// 获取子目录名称，根据文件路径剔除主目录后获取子目录名称
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="mainDirPath"></param>
        /// <returns></returns>
        public static string[] GetDirNames(string filePath, string mainDirPath)
        {
            string dirStr = System.IO.Path.GetDirectoryName(filePath).Replace(mainDirPath, String.Empty);
            dirStr = dirStr.Length > 0 && dirStr[0] == '\\' ? dirStr.Substring(1) : dirStr;
            return dirStr.Split('\\');
        }

        /// <summary>
        /// 根据主目录，获取所有的子目标名称
        /// </summary>
        /// <param name="mainDirPath"></param>
        /// <returns></returns>
        public static string[] GetDirNames(string mainDirPath)
        {
            return CL.Common.Commons.FileIOHelper.GetDirectories(mainDirPath, "*", true);
        }

        /// <summary>
        /// 根据主目录，获取所有的子目录中的文件名称
        /// </summary>
        /// <param name="mainDirPath"></param>
        /// <returns></returns>
        public static string[] GetFilePath(string mainDirPath)
        {
            return CL.Common.Commons.FileIOHelper.GetFileNames(mainDirPath, "*", true);
        }
        #endregion 根据目录获取 文件 和 子目录信息
    }
}
