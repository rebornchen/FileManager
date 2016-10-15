using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using CL.Common;
using CL.AffSSNManage.Win.HttpDataRequest;

namespace CL.AffSSNManage.Win
{
    public partial class FrmMain : Form
    {
        #region 构造方法 
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region 自动填写 hotmail

        /// <summary>
        /// 自动完成的控制变量
        /// </summary>
        private bool isAutoComplete = false;

        public void LoadData()
        {
            isAutoComplete = true;
            wbHotmail.Url = new Uri("http://www.baidu.com");
        }

        void wbHotmail_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!isAutoComplete)
            {
                return;
            }
            HtmlElement searchText = wbHotmail.Document.GetElementById("kw");
            searchText.InnerText = "xp系统 .netframework 4";

            HtmlElement submit = wbHotmail.Document.GetElementById("su");
            submit.InvokeMember("click");

            isAutoComplete = false;
        }
        #endregion

        #region 窗体加载事件 
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadData();
            CollectSSN();
        }
        #endregion

        #region 采集SSN
        /// <summary>
        /// 采集SSN
        /// </summary>
        public void CollectSSN()
        {
            SSNRequest ssnRequest = new SSNRequest();
            ssnRequest.RequestURLAndSaveSSN();
        }
        #endregion
    }
}
