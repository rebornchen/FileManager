using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.Collections;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraNavBar;
using CL.Model;
using CL.BLL;


namespace CL.FileManager.DXWin
{
    
    public partial class FrmMain : XtraForm
    {
        #region 构造方法

        public FrmMain()
        {
            InitializeComponent();
            barManager.ForceInitialize();
            SkinHelper.InitSkinPopupMenu(mPaintStyle);
            LoadCategorys();

            Test();

        }

        public void Test()
        {
            //CL.UI.Logic.DirPath.DirPathRule dirRule = new CL.UI.Logic.DirPath.DirPathRule(@"F:\abc\ddd\");
            //CL.UI.Logic.DirPath.CategoryRule categoryRule = new UI.Logic.DirPath.CategoryRule(dirRule, "编程");
            //CL.UI.Logic.DirPath.DateRule dateRule = new CL.UI.Logic.DirPath.DateRule(categoryRule);
            CL.UI.Logic.UILogic.EnsureDirectoryExists(@"F:\abc\ddd\", "Program", "2015-01", CL.UI.Logic.EnumFileDirSaveMethod.DateFirst);
            //MessageBox.Show(dateRule.GetPath());

        }
        #endregion

        #region 类型菜单加载
        /// <summary>
        /// 加载数据到导航窗体
        /// </summary>
        private void LoadCategorys()
        {
            //加载时间菜单
            NavBarItem bItem = this.dateGroup.AddItem().Item;
            bItem.Caption = "2016-09";
            bItem.LinkClicked += bItem_DateLinkClicked;

            CategoryBiz categoryBiz = new BLL.CategoryBiz();
            var categoryList = categoryBiz.GetAll();
            foreach (Category c in categoryList)
            {
                NavBarItem item = this.dateGroup.AddItem().Item;
                item.Caption = c.CCategoryName;
                item.LinkClicked += bItem_DateLinkClicked;

            }
        }
        
        /// <summary>
        /// 统一的数据处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bItem_DateLinkClicked(object sender, NavBarLinkEventArgs e)
        {
            //MessageBox.Show(((NavBarItem)sender).Caption);
            string name = "类型管理";
            string text = "类型管理";
            ShowTabPageByName<CL.AffSSNManage.DXWin.Views.Category.XUCCategory>(name, text);
        }
       #endregion

        #region 导航按钮

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarControl_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.GetType().ToString());
        }

        /// <summary>
        /// ssn 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ssnItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //string name = "tpHaoweichiSSN";
            //string text = "Haoweichi SSN";
            //ShowTabPageByName<SSNUI.XUCHaoweichiSSN>(name, text);
            //string name = "类型管理";
            //string text = "类型管理";
            //ShowTabPageByName<CL.AffSSNManage.DXWin.Views.Category.XUCCategory>(name, text);
        }

        /// <summary>
        /// hotmail 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hotmailItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string name = "Hotmail Reg";
            string text = "Hotmail Reg";
            //ShowTabPageByName<MailUI.XUCRegHotmail>(name, text);
        }

        /// <summary>
        /// 根据名称和文本显示tabpage
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        private void ShowTabPageByName<T>(string name, string text) where T : XtraUserControl, new()
        {
            XtraTabPage page = xtraTabControl1.TabPages.ToList().Find(p => p.Name == name);
            if (page == null)
            {
                page = new XtraTabPage() { Name = name, Text = text };
                page.Controls.Add(new T() { Dock = DockStyle.Fill });
                xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { page });
            }

            xtraTabControl1.SelectedTabPage = page;
        }

       #endregion

        #region 关闭按钮

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            PageEventArgs ea = e as PageEventArgs;
            if (ea != null)
            {
                XtraTabPage page = ea.Page as XtraTabPage;
                if (page != null) page.Dispose();
            }
        }
        #endregion

        #region 菜单按钮方法

        /// <summary>
        /// 关闭当前应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
        #endregion




    }
}