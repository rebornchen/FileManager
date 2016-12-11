using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.FileManager.Win.Controls
{


    public class ButtonWithDel : SkinPanel
    {

        private SkinButton btn = new SkinButton();
        private SkinButton btnDel = new SkinButton();

        /// <summary>
        /// 按钮点击事件
        /// </summary>
        public event System.EventHandler OnButtonClick;
        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        public event System.EventHandler OnDelClick;


        /// <summary>
        /// 设置对象
        /// </summary>
        public new object Tag
        {
            get
            {
                return btn.Tag;
            }
            set
            {
                btn.Tag = value;
            }
        }

        /// <summary>
        /// 显示的文本
        /// </summary>
        public new string Text
        {
            get
            {
                return btn.Text;
            }
            set
            {
                btn.Text = value;
                ChangePanelWidth();
            }
        }

        /// <summary>
        /// 显示删除按钮
        /// </summary>
        public bool ShowDelete
        {
            get
            {
                return btnDel.Visible;
            }
            set
            {
                btnDel.Visible = value;
            }
        }



        /// <summary>
        /// 根据文本长度计算本控件的宽度
        /// </summary>
        private void ChangePanelWidth()
        {
            int width = (int)(Text.Length * btn.Font.Size * 2) + 8;
            width = (ShowDelete ? width + btnDel.Width : width) + 2;
            this.Width = width;
        }


        




        /// <summary>
        /// 构造方法
        /// </summary>
        public ButtonWithDel()
        {
            //设置border 为none
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Height = 23;
            
            ShowDelete = true;
            Text = "Test";
            Tag = null;

            InitialControls();
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        public void InitialControls()
        {
            btn.Click += Btn_Click;

            btnDel.Click += BtnDel_Click;

            btnDel.Text = String.Empty;
            btnDel.Image = global::CL.FileManager.Win.Properties.Resources.icon_del1;
            btnDel.BaseColor = System.Drawing.Color.Transparent;
            btnDel.IsDrawBorder = false;
            btnDel.Width = 23;
            btnDel.Height = 23;
        
            btn.IsDrawBorder = false;
            btn.BaseColor = System.Drawing.Color.Transparent;
            btn.Height = 23;

            this.Controls.Add(btn);
            //this.Controls.Add(btnDel);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            OnDelClick?.Invoke(sender, e);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            OnButtonClick?.Invoke(sender, e);
        }
    }
}
