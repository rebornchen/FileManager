using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CL.Model;

namespace CL.FileManager.Win.Controls
{
    /// <summary>
    /// 显示文件信息的控件
    /// 显示选择的类型下的所有的类型内容，可能会有重复文件
    /// </summary>
    public partial class UCFileListView : UserControl
    {
        #region 私有变量-bll 对象
        private BLL.FileCategoryRelationsBiz fileCategoryRelationsBiz = new BLL.FileCategoryRelationsBiz();
        private BLL.CategoryBiz categoryBiz = new BLL.CategoryBiz();
        private BLL.FilesBiz fileBiz = new BLL.FilesBiz();
        #endregion 私有变量-bll 对象

        #region 构造方法
        public UCFileListView()
        {
            InitializeComponent();
            //增加右键菜单
            this.ContextMenuStrip = skinContextMenuStrip1;
        }
        #endregion

        #region 公共属性
        private List<Category> selectedCategoris = new List<Category>();
        /// <summary>
        /// 选择的类型列表
        /// </summary>
        public List<Category> SelectedCategoris
        {
            get { return selectedCategoris; }
            set
            {
                selectedCategoris = value;
                LoadData();
            }
        }

        /// <summary>
        ///  当前文件展示的视图方式
        /// </summary>
        public System.Windows.Forms.View View
        {
            set
            {
                skinLV.View = value;
            }
            get
            {
                return skinLV.View;
            }
        }
        #endregion 公共属性

        #region 加载数据
        //根据类型列表获取所有的文件
        private void LoadData()
        {
            //清空列表
            skinLV.Groups.Clear();
            skinLV.Items.Clear();

            //根据类型列表获取所有的文件、类型
            var temp = selectedCategoris.Select(sc => sc.ICId);
            var tempFileIds = fileCategoryRelationsBiz.GetFileIds(temp.ToList());
            List<FileCategoryRelations> fcrList = fileCategoryRelationsBiz.GetList(fcr => tempFileIds.Contains(fcr.IFId));

            //根据文件 id 获取所有 Relations


            //
            // 处理类型列表
            //
            List<int> categoryIdList = fcrList.Select(f => f.ICId).Distinct().ToList();
            //去掉已经选择的类型
            List<int> selectedCategoryIds = selectedCategoris.Select(sc => sc.ICId).ToList();
            foreach (var item in selectedCategoryIds)
            {
                if(categoryIdList.Contains(item))
                {
                    categoryIdList.Remove(item);
                }
            }

            //
            // 生成组
            //
            LoadGroups(categoryIdList);

            //
            // 处理文件列表
            //
            List<int> fileIdList = fcrList.Select(f => f.IFId).Distinct().ToList();
            var files = GetFiles(fileIdList);

            //处理图像列表
            var fileExtends = files.Select(f => f.CExtention).Distinct();
            foreach(string extend in fileExtends)
            {
                if(imageListLarge.Images.Keys.Contains(extend))
                {
                    continue;
                }
                imageListLarge.Images.Add(extend, CL.Common.Commons.FileSysIcon.GetIcon(extend, true));
                imageListSmall.Images.Add(extend, CL.Common.Commons.FileSysIcon.GetIcon(extend, false));
            }

            //
            // 加载文件到组中
            //
            LoadFileToGroups(fcrList, files);

            //fileBiz.GetList(file=>file.c)
        }

        /// <summary>
        /// 将文件对象进行处理，组织到组中
        /// </summary>
        /// <param name="fcrList"></param>
        /// <param name="files"></param>
        private void LoadFileToGroups(List<FileCategoryRelations> fcrList, List<Files> files)
        {
            ListViewGroup allFilesGroup = null;
            foreach (ListViewGroup item in skinLV.Groups)
            {
                //处理“全部 all files”组
                if(item.Tag == null)
                {
                    allFilesGroup = item;
                    continue;
                }
                List<Files> list = (from fcr in fcrList
                                    join f in files
                                    on fcr.IFId equals f.IFId
                                    where fcr.ICId == ((Category)item.Tag).ICId
                                    select f).ToList();

                AddFilesToGroup(list, item);
            }
            AddFilesToGroup(files, allFilesGroup);
        }

        /// <summary>
        /// 添加文件到单个组中
        /// </summary>
        /// <param name="files"></param>
        /// <param name="group"></param>
        private void AddFilesToGroup(List<Files> files, ListViewGroup group)
        {
            foreach (var item in files)
            {
                System.Windows.Forms.ListViewItem listItem = new System.Windows.Forms.ListViewItem(group);
                listItem.Text = item.CFileName;
                listItem.ToolTipText = item.CFullName;
                listItem.Tag = item;
                
                listItem.ImageKey = item.CExtention;

                skinLV.Items.Add(listItem);
            }
        }

        /// <summary>
        /// 加载组
        /// </summary>
        /// <param name="categoryIdList"></param>
        private void LoadGroups(List<int>  categoryIdList)
        {
            List<Category> categoryList = categoryBiz.GetList(c => categoryIdList.Contains(c.ICId));

            foreach (var item in categoryList)
            {
                System.Windows.Forms.ListViewGroup listViewGroup = 
                    new System.Windows.Forms.ListViewGroup(item.CCategoryName, System.Windows.Forms.HorizontalAlignment.Left);
                listViewGroup.Tag = item;
                skinLV.Groups.Add(listViewGroup);
            }
            System.Windows.Forms.ListViewGroup allFilesGroup =
                    new System.Windows.Forms.ListViewGroup("All Files", System.Windows.Forms.HorizontalAlignment.Left);
            skinLV.Groups.Add(allFilesGroup);
        }

        /// <summary>
        /// 根据文件id list，获取文件列表
        /// </summary>
        /// <param name="fileIdList"></param>
        /// <returns></returns>
        private List<Files> GetFiles(List<int> fileIdList)
        {
            List<Files> fileList = fileBiz.GetList(f => fileIdList.Contains(f.IFId));
            return fileList;
        }

        /// <summary>
        /// 打开文件夹的菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(skinLV.SelectedItems.Count == 0)
            {
                return;
            }
            string path = ((Files)skinLV.SelectedItems[0].Tag).CFullName;
            CL.Common.Winform.WindowsFunctions.OpenFolderAndSelectFile(path);
        }

        /// <summary>
        /// 编辑文件类型按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (skinLV.SelectedItems.Count == 0)
            {
                return;
            }
            Files file = (Files)skinLV.SelectedItems[0].Tag;
            List<Files> filelist = new List<Files>();
            filelist.Add(file);
            FrmAddFilesCategory frmAddFilesCategory = new FrmAddFilesCategory();
            frmAddFilesCategory.SetFiles(filelist);


            List<Category> categories = categoryBiz.GetAllTopCategory();
            frmAddFilesCategory.SetCategory(categories);

            frmAddFilesCategory.LoadFileCategory();

            frmAddFilesCategory.ShowDialog();
        }
        #endregion


        //根据文件获取所有的类型

        //根据类型组织成listview 中的组

        //将文件添加到组中
    }
}
