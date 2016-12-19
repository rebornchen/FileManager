using CCWin;
using CCWin.SkinControl;
using CL.BLL;
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
    public partial class FrmAddFilesCategory : CCWin.CCSkinMain
    {

        private List<Files> files = null;

        public FrmAddFilesCategory()
        {
            InitializeComponent();
        }

        //public FrmAddFilesCategory(CCSkinMain main) : base(main)
        //{
        //    InitializeComponent();
        //    //base.sh
        //}

        /// <summary>
        /// 设置文件
        /// </summary>
        /// <param name="files"></param>
        public void SetFiles(List<Files> files)
        {
            this.files = files;
            controlFileList1.SetList(files);
        }

        /// <summary>
        /// 设置类型
        /// </summary>
        /// <param name="categories"></param>
        public void SetCategory(List<Category> categories)
        {
            controlCategory1.LoadCategory(categories);
        }

        /// <summary>
        /// 点击类型按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlCategory1_OnCategroyButtonClick(object sender, EventArgs e)
        {
            if(files == null || files.Count == 0)
            {
                return;
            }
            SkinButton btn = (SkinButton)sender;
            Category c = (Category)btn.Tag;

            FileCategoryRelationsBiz relationsbiz = new FileCategoryRelationsBiz();
            foreach (Files f in files)
            {
                FileCategoryRelations r = new FileCategoryRelations();
                r.ICId = c.ICId;
                r.IFId = f.IFId;
                relationsbiz.Add(r);
            }

            btn.Visible = false;

            //controlCategory1.Controls.Remove(btn);
        }
    }
}
