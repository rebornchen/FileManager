using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.FileManager.Win.Controls
{


    public class ButtonWithDel : SkinFlowLayoutPanel
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
            
            btn.Width = (int)Commons.UICommon.GetControlWidth(Text, btn.Font, this) + 10;
                        
            int width = (ShowDelete ? btn.Width + btnDel.Width + 4: btn.Width + 4) ;
            this.Width = width;
        }

        

        /// <summary>
        /// 构造方法
        /// </summary>
        public ButtonWithDel()
        {
            InitialControls();
            //设置border 为none
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Height = 23;
            
            ShowDelete = true;
            Text = "Test";
            Tag = null;

            //InitialControls();
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        public void InitialControls()
        {
            //btn 处理
            btn.IsDrawBorder = false;
            btn.BaseColor = System.Drawing.Color.Transparent;
            btn.Height = 23;
            btn.Margin = System.Windows.Forms.Padding.Empty;
            btn.Click += Btn_Click;

            //btnDel 处理
            btnDel.BackColor = System.Drawing.Color.Transparent;
            btnDel.BackgroundImage = global::CL.FileManager.Win.Properties.Resources.icon_del1;
            btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btnDel.BaseColor = System.Drawing.Color.Transparent;
            btnDel.ControlState = CCWin.SkinClass.ControlState.Normal;
            btnDel.DownBack = null;
            btnDel.Location = new System.Drawing.Point(287, 186);
            btnDel.MouseBack = null;
            btnDel.NormlBack = null;
            btnDel.Size = new System.Drawing.Size(20, 20);
            btnDel.IsDrawBorder = false;
            btnDel.Text = String.Empty;
            btnDel.UseVisualStyleBackColor = false;
            btnDel.DrawType = DrawStyle.Img;
            btnDel.Margin = System.Windows.Forms.Padding.Empty;
            btnDel.Click += BtnDel_Click;

            //添加子控件
            this.Controls.Add(btn);
            this.Controls.Add(btnDel);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            OnDelClick?.Invoke(this, e);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            OnButtonClick?.Invoke(this, e);
        }
    }
}
