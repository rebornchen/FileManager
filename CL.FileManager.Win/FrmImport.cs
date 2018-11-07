using CL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CL.FileManager.Win
{
    public partial class FrmImport : BaseForm
    {
        #region 更新界面-线程处理
        #region 委托定义
        /// <summary>
        /// 更新信息文本
        /// </summary>
        /// <param name="text"></param>
        delegate void UpdateImportInfoTextHandler(object text);
        /// <summary>
        /// 更新进度条
        /// </summary>
        /// <param name="progress"></param>
        delegate void UpdateProgressBarHandler(object progress);
        #endregion 委托定义
        
        #region 信息文本线程处理
        /// <summary>
        /// 设置导入信息文本线程
        /// </summary>
        /// <param name="text"></param>
        private void StartImportInfoText(string text)
        {
            Thread t = new Thread(new ParameterizedThreadStart(SetImportInfoTextInvoke));
            t.Start(text);
        }

        /// <summary>
        /// 设置导入信息文本线程方法
        /// </summary>
        /// <param name="text"></param>
        private void SetImportInfoTextInvoke(object text)
        {
            if(lblImportInfo.InvokeRequired)
            {
                UpdateImportInfoTextHandler d = new UpdateImportInfoTextHandler(SetImportInfoText);
                lblImportInfo.Invoke(d, text);
            }
            else
            {
                lblImportInfo.Text = (string)text;
            }

        }

        /// <summary>
        /// 设置导入信息文本线程委托方法
        /// </summary>
        /// <param name="text"></param>
        private void SetImportInfoText(object text)
        {
            lblImportInfo.Text = (string)text;
        }
        #endregion

        #region 进度条线程处理
        /// <summary>
        /// 设置进度条值线程
        /// </summary>
        /// <param name="text"></param>
        private void StartUpdateProgressBar(int progress)
        {
            Thread t = new Thread(new ParameterizedThreadStart(UpdateProgressBarInvoke));
            t.Start(progress);
        }

        /// <summary>
        /// 设置进度条值线程方法
        /// </summary>
        /// <param name="text"></param>
        private void UpdateProgressBarInvoke(object progress)
        {
            if (skinProgressBar1.InvokeRequired)
            {
                UpdateProgressBarHandler d = new UpdateProgressBarHandler(UpdateProgressBar);
                skinProgressBar1.Invoke(d, progress);
            }
            else
            {
                skinProgressBar1.Value = (int)progress;
            }
        }

        /// <summary>
        /// 设置进度条值线程委托方法
        /// </summary>
        /// <param name="text"></param>
        private void UpdateProgressBar(object progress)
        {
            skinProgressBar1.Value = (int)progress;
        }
        #endregion 进度条线程处理
        #endregion 更新界面-线程处理
        
        #region 私有变量-bll 对象
        private BLL.FileCategoryRelationsBiz fileCategoryRelationsBiz = new BLL.FileCategoryRelationsBiz();
        private BLL.CategoryBiz categoryBiz = new BLL.CategoryBiz();
        private BLL.FilesBiz fileBiz = new BLL.FilesBiz();
        #endregion 私有变量-bll 对象

        #region 构造方法
        public FrmImport()
        {
            InitializeComponent();
        }
        #endregion

        #region 按钮事件
        /// <summary>
        /// 导入按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            string path = txtDirectory.Text.Trim();
            Thread t = new Thread(new ParameterizedThreadStart(Import));
            t.Start(path);
            //Import(path);
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 浏览按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrownse_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog(this);
            txtDirectory.Text = this.folderBrowserDialog1.SelectedPath;
        }
        #endregion 按钮事件

        #region 导入逻辑方法
        private void Import(object arg)
        {
            Import(arg.ToString());
        }
        private void Import(string mainDirPath)
        {
            StartImportInfoText("Initial Import Info...");
            StartUpdateProgressBar(5);
            string[] dirArr = CL.UI.Logic.UILogic.GetDirNames(mainDirPath);
            string[] filesArr = CL.UI.Logic.UILogic.GetFilePath(mainDirPath);

            StartImportInfoText("正在导入类型信息...");
            List<Category> categories= categoryBiz.GetCategories(dirArr.ToList());
            StartUpdateProgressBar(25);

            StartImportInfoText("正在导入文件信...");
            List<Files> files = fileBiz.GetFiles(filesArr.ToList());
            StartUpdateProgressBar(60);

            StartImportInfoText("正在建立文件关联...");
            //添加文件类型关联
            foreach (var item in files)
            {
                SaveRelations(item, categories, mainDirPath);
            }
            StartUpdateProgressBar(100);
            StartImportInfoText("Import Finished.");
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
        /// 保存文件信息
        /// </summary>
        /// <param name="files"></param>
        private void SaveFiles(List<Files> files)
        {
            //对文件进行去重
            foreach(var item in files)
            {
                fileBiz.Add(item);
            }
        }

        /// <summary>
        /// 保存类型信息
        /// </summary>
        /// <param name="categories"></param>
        private void SaveCategories(List<Category> categories)
        {

        }
            

        #endregion 导入逻辑方法


    }
}
