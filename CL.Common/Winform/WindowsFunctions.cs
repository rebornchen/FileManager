using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.Common.Winform
{
    /// <summary>
    /// windows 系统常用功能
    /// </summary>
    public class WindowsFunctions
    {
        /// <summary>
        /// 在windows 中打开文件夹，并选中该文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public static void OpenFolderAndSelectFile(string path)
        {
            System.Diagnostics.Process.Start("Explorer.exe", @"/select,"+path);
        }

        /// <summary>
        /// 在windows 中打开指定文件夹
        /// </summary>
        /// <param name="dirPath"></param>
        public static void OpenFolder(string dirPath)
        {
            System.Diagnostics.Process.Start("Explorer.exe", dirPath);
        }
    }
}
/******************
 例如：打开“E:\Training”文件夹并选中“20131250.html”文件

System.Diagnostics.Process.Start("Explorer.exe", @"/select,E:\Training\20131250.html");

一句代码搞定！！！

扩展：

1）只打开文件夹：

System.Diagnostics.Process.Start("Explorer.exe", @"E:\Training");

2）打开文件夹并选中文件夹

System.Diagnostics.Process.Start("Explorer.exe", @"/select,E:\Training\test.txt");
 * *****************/
