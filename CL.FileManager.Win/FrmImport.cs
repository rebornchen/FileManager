using CL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CL.FileManager.Win
{
    public partial class FrmImport : BaseForm
    {

        #region 私有变量-bll 对象
        private BLL.FileCategoryRelationsBiz fileCategoryRelationsBiz = new BLL.FileCategoryRelationsBiz();
        private BLL.CategoryBiz categoryBiz = new BLL.CategoryBiz();
        private BLL.FilesBiz fileBiz = new BLL.FilesBiz();
        #endregion 私有变量-bll 对象

        public FrmImport()
        {
            InitializeComponent();
        }

        #region 按钮事件
        /// <summary>
        /// 导入按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if(CL.Common.Commons.FileIOHelper.IsExistDirectory(txtDirectory.Text))
            {
                lblVal.Text = String.Empty;
                Import(txtDirectory.Text);
            }
            else
            {
                lblVal.Text = "Directory is not exists.";
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 按钮事件

        #region 文本框事件
        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDirectory_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        private void Import(string mainDirPath)
        {
            SetImportInfoText("Initial Import Info...");
            skinProgressBar1.Value = 5;
            string[] dirArr = CL.UI.Logic.UILogic.GetDirNames(mainDirPath);
            string[] filesArr = CL.UI.Logic.UILogic.GetFilePath(mainDirPath);

            SetImportInfoText("正在导入类型信息...");
            List<Category> categories= categoryBiz.GetCategories(dirArr.ToList());
            skinProgressBar1.Value = 25;

            SetImportInfoText("正在导入文件信息...");
            List<Files> files = fileBiz.GetFiles(filesArr.ToList());
            skinProgressBar1.Value = 60;

            SetImportInfoText("正在建立文件关联...");
            //添加文件类型关联
            foreach (var item in files)
            {
                SaveRelations(item, categories, mainDirPath);
            }
            skinProgressBar1.Value = 100;
            SetImportInfoText("Import Finished.");
        }

        /// <summary>
        /// 保存 文件和类型的关系
        /// </summary>
        /// <param name="file"></param>
        /// <param name="categories"></param>
        private void SaveRelations(Files file, List<Category> categories, string mainDirPath)
        {
            string [] dirArr = CL.UI.Logic.UILogic.GetDirNames(file.CFullName, mainDirPath);
            var list = from c in categories
                                  join string dir in dirArr
                                  on c.CCategoryName equals dir
                                  select c;
            foreach (var item in list)
            {
                fileCategoryRelationsBiz.Add(item, file);
            }
        }

        /// <summary>
        /// 设置导入信息文本
        /// </summary>
        /// <param name="text"></param>
        private void SetImportInfoText(string text)
        {
            lblImportInfo.Text = text;
        }

        private void txtDirectory_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog(this);
            txtDirectory.Text = this.folderBrowserDialog1.SelectedPath;
        }
    }
}
