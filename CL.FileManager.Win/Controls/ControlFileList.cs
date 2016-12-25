using CCWin.SkinControl;
using CL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.FileManager.Win.Controls
{
    public class ControlFileList : SkinListBox
    {
        /// <summary>
        /// 根据文件列表，显示文件
        /// </summary>
        /// <param name="files"></param>
        public void SetList(List<Files> files)
        {
            foreach(Files f in files)
            {
                SkinListBoxItem item = new SkinListBoxItem(f.CFullName);
                item.Tag = f;
                this.Items.Add(item);
            }
        }

        /// <summary>
        /// 添加单个文件到列表中
        /// </summary>
        /// <param name="file"></param>
        public void AddFile(Files file)
        {
            SkinListBoxItem item = new SkinListBoxItem(file.CFullName);
            item.Tag = file;
            this.Items.Add(item);
        }
    }
}
