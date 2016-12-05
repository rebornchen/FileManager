using CCWin;
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
        public FrmMain()
        {
            InitializeComponent();
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
            controlCategory1.LoadCategory();
        }
        #endregion

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //UILogic.GetFileModelByFilePath()
        }

        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {

        }

        /// <summary>
        /// 类型按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlCategory1_OnCategroyButtonClick(object sender, EventArgs e)
        {
            Category c = (Category)sender;
            lblMessage.Text = c.CCategoryName;
            //处理
        }

        private void controlCategory1_OnFileDragDrop(object sender, EventArgs e)
        {
            CL.FileManager.Win.Controls.ControlCategory.FileDragDropArgs
                args = (CL.FileManager.Win.Controls.ControlCategory.FileDragDropArgs)e;
            Category c = args.FileCategory;
            System.Array arr = args.FlileArray;

            foreach (var a in arr)
            {
                if(System.IO.File.Exists(a.ToString()))
                {
                    BLL.FilesBiz fileBiz = new BLL.FilesBiz();
                    var files = CL.UI.Logic.UILogic.GetFileModelByFilePath(a.ToString());
                    fileBiz.Add(files);
                }
            }

            lblMessage.Text = "OK";
        }
    }
}
