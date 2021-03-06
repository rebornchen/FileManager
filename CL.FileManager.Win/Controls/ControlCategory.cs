﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CCWin.SkinControl;
using System.Drawing;
using CL.Model;
using System.ComponentModel;

namespace CL.FileManager.Win.Controls
{
    public class ControlCategory : CCWin.SkinControl.SkinFlowLayoutPanel
    {

        /// <summary>
        /// 定义类型点击事件
        /// </summary>
        [Description("类型点击事件；参数 sender: Category")]
        public event System.EventHandler OnCategroyButtonClick;

        ///// <summary>
        ///// 文件拖放
        ///// </summary>
        //[Description("文件拖放到类型按钮事件")]
        //public event System.EventHandler OnFileDragDrop;

        protected BLL.CategoryBiz biz = new BLL.CategoryBiz();
        protected List<Color> colors = InitialColors();
        protected Random rd = new Random();

        /// <summary>
        /// 加载类型
        /// </summary>
        public virtual void LoadCategory (List<Category> categoryList)
        {
            if(categoryList == null )
            {
                return;
            }

            foreach (Category category in categoryList)
            {
                AddCategory(category);
            }
            
        }

        /// <summary>
        /// 添加单个类型
        /// </summary>
        /// <param name="category"></param>
        public virtual void AddCategory(Category category)
        {
            if (category == null)
            {
                return;
            }
            
            SkinButton btn = new SkinButton();
            btn.AllowDrop = true;
            btn.Tag = category;
            btn.Text = category.CCategoryName;
            btn.BackColor = colors[rd.Next(colors.Count)];
            //btn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            btn.BaseColor = colors[rd.Next(colors.Count)];
            //btn.Width = (int)(category.CCategoryName.Length * btn.Font.Size * 2) + 8;
            btn.Width = (int)Commons.UICommon.GetControlWidth(btn.Text, btn.Font, this) + 10;

            //事件
            btn.Click += Btn_Click;
            //btn.DragDrop += Btn_DragDrop;
            //btn.DragEnter += Btn_DragEnter;

            this.Controls.Add(btn);

        }
        
        /// <summary>
        /// 移除指定按钮
        /// </summary>
        /// <param name="btn"></param>
        public void Remove(SkinButton btn)
        {
            if(this.Controls.Contains(btn))
            {
                this.Controls.Remove(btn);
            }
        }


        /// <summary>
        /// 初始化颜色
        /// </summary>
        /// <returns></returns>
        protected static List<Color> InitialColors()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Color.AliceBlue);
            colors.Add(Color.AntiqueWhite);
            colors.Add(Color.Beige);
            colors.Add(Color.CadetBlue);
            colors.Add(Color.Coral);
            colors.Add(Color.Cyan);
            colors.Add(Color.DarkRed);
            colors.Add(Color.DarkSlateBlue);
            colors.Add(Color.DarkViolet);
            return colors;
        }


        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Click(object sender, EventArgs e)
        {
            //触发事件
            if (OnCategroyButtonClick != null)
            {
                //Category c = ((SkinButton)sender).Tag as Category;
                OnCategroyButtonClick(sender, null);
            }
        }


        ///// <summary>
        ///// 事件参数
        ///// </summary>
        //public class FileDragDropArgs : System.EventArgs
        //{
        //    public Category FileCategory { get; set; }
        //    public System.Array FlileArray { get; set; }
        //}
        
    }
}
