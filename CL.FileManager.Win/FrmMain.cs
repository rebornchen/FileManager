using CCWin;
using CCWin.SkinControl;
using CL.BLL;
using CL.Model;
using CL.UI.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CL.FileManager.Win
{
    public partial class FrmMain : CCSkinMain
    {
        private CategoryBiz categoryBiz = new CategoryBiz();

        public FrmMain()
        {
            InitializeComponent();
            skinPnlCategory.OnCategoryChanged += SkinPnlCategory_OnCategoryChanged;

        }

        #region 菜单事件
        /// <summary>
        /// 退出菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region 临时处理
        private void CategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Category> categories = categoryBiz.GetAllTopCategory();
            controlCategory1.LoadCategory(categories);
        }
        #endregion

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //UILogic.GetFileModelByFilePath()
        }


        /// <summary>
        /// 类型按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlCategory1_OnCategroyButtonClick(object sender, EventArgs e)
        {
            SkinButton btn = (SkinButton)sender;
            Category c = (Category)btn.Tag;
            lblMessage.Text = c.CCategoryName;

            //处理,将选中的内容放置到右边的类型选择框中
            skinPnlCategory.AddCategory(c);
        }

        private void SkinPnlCategory_OnCategoryChanged(object sender, EventArgs e)
        {
            ucFileListView.SelectedCategoris = skinPnlCategory.Categories;
        }

        #region 文件拖放处理



        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            Array arr = ((System.Array)e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop));

            var list = SaveFilesToDB(arr);

            FrmAddFilesCategory frmAddFilesCategory = new FrmAddFilesCategory();
            frmAddFilesCategory.SetFiles(list);

           
            List<Category> categories = categoryBiz.GetAllTopCategory();
            frmAddFilesCategory.SetCategory(categories);

            frmAddFilesCategory.ShowDialog();

        }
        #endregion 文件拖放处理

        #region 私有方法
        /// <summary>
        /// 根据文件地址数组，保存数据到数据库
        /// </summary>
        /// <param name="filesArr"></param>
        /// <returns></returns>
        private List<Files> SaveFilesToDB(System.Array filesArr)
        {
            List<Files> filesList = new List<Files>();
            FilesBiz fileBiz = new FilesBiz();
            foreach (var item in filesArr)
            {
                Files file = CL.UI.Logic.UILogic.GetFileModelByFilePath(item.ToString());
                file.IFId = fileBiz.GetMaxNext();
                fileBiz.Add(file);
                filesList.Add(file);
            }
            return filesList;
        }
        #endregion 私有方法

    }
}
