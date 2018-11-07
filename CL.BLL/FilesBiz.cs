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



        /// <summary>
        /// 根据输入的名称，获取或者创建相应的文件，并返回类型列表
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<Files> GetFiles(List<string> filePath)
        {
            //获取已经存在的文件列表
            var existsFiles = GetExistsFiles(filePath);

            //去除已经存在的文件名称
            foreach (var item in existsFiles)
            {
                filePath.Remove(item.CFullName);
            }

            //创建名字尚不存在的文件
            List<Files> newFiles = CreateFiles(filePath);

            //将文件整合
            existsFiles.AddRange(newFiles);

            //返回数据
            return existsFiles;
        }

        /// <summary>
        /// 获取已经存在的文件，并返回文件列表
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<Files> GetExistsFiles(List<string> filePath)
        {
            List<Files> files = new List<Files>();
            List<Files> allfiles = this.GetAll();

            files = (from file in allfiles
                    join path in filePath
                    on file.CFullName equals path
                    select file).ToList();

            return files;
        }

        /// <summary>
        /// 创建名字尚不存在的文件，并返回文件列表
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<Files> CreateFiles(List<string> filePath)
        {
            int nextId = GetMaxNext();
            //组建需创建的文件列表
            List<Files> newFiles = new List<Files>();
            foreach (var item in filePath)
            {
                Files f = CL.UI.Logic.UILogic.GetFileModelByFilePath(item);
                f.IFId = nextId;
                newFiles.Add(f);
                nextId++;
            }
            //创建文件列表
            Add(newFiles);
            return newFiles;
        }


    }
}
