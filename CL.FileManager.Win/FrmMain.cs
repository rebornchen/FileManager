using CCWin;
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
            Array arr = ((System.Array)e.Data.GetData(DataFormats.FileDrop));

            foreach (var a in arr   )
            {
                System.Console.WriteLine(a.ToString());
            }

            //string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
        }
    }
}
