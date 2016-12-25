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
    public partial class FrmAddFilesCategory : BaseForm
    {

        private List<Files> files = null;
        private FileCategoryRelationsBiz relationsbiz = new FileCategoryRelationsBiz();
        private CategoryBiz categoryBiz = new CategoryBiz();

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
        /// 加载已有的文件类型
        /// </summary>
        public void LoadFileCategory()
        {
            if(files.Count == 1)
            {
                List<Category> categories = categoryBiz.GetCategories(files[0]);
                foreach(Category c in categories)
                {
                    controlCategoryWithDel.AddCategory(c);
                }
            }
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

            
            foreach (Files f in files)
            {
                FileCategoryRelations r = new FileCategoryRelations();
                r.ICId = c.ICId;
                r.IFId = f.IFId;
                relationsbiz.Add(r);
            }

            controlCategory1.Remove(btn);
            controlCategoryWithDel.AddCategory(c);
            //btn.Visible = false;

            //controlCategory1.Controls.Remove(btn);
        }

        /// <summary>
        /// 当类型发生变化时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlCategoryWithDel_OnCategoryChanged(object sender, Controls.ControlCategoryWithDel.OnCategoryChangedEventArgs e)
        {
            if(!e.IsDel)
            {
                return;
            }
            if (files == null || files.Count == 0)
            {
                return;
            }
            Category c = e.ChangedCategory;
            //FileCategoryRelationsBiz relationsbiz = new FileCategoryRelationsBiz();
            foreach (Files f in files)
            {
                relationsbiz.Delete(f.IFId, c.ICId);
            }

        }
    }
}
