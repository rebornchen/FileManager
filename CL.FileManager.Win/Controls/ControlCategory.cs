using System;
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

        /// <summary>
        /// 文件拖放
        /// </summary>
        [Description("文件拖放到类型按钮事件")]
        public event System.EventHandler OnFileDragDrop;

        BLL.CategoryBiz biz = new BLL.CategoryBiz();

        /// <summary>
        /// 加载类型
        /// </summary>
        public void LoadCategory ()
        {
            List<Category> categoryList = biz.GetAllTopCategory();

            List<Color> colors = InitialColors();

            Random rd = new Random();

            foreach (Category category in categoryList)
            {
                SkinButton btn = new SkinButton();
                btn.AllowDrop = true;
                btn.Tag = category;
                btn.Text = category.CCategoryName;
                btn.BaseColor = colors[rd.Next(colors.Count)];
                btn.Width = (int)(category.CCategoryName.Length * btn.Font.Size * 2) + 8;
                
                //事件
                btn.Click += Btn_Click;
                btn.DragDrop += Btn_DragDrop;

                this.Controls.Add(btn);
            }
            
        }

        /// <summary>
        /// 拖动文件到类型按钮上事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {

            Array arr = ((System.Array)e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop));

            Category c = ((SkinButton)sender).Tag as Category;

            FileDragDropArgs args = new FileDragDropArgs();
            args.FileCategory = c;
            args.FlileArray = arr;

            //触发事件
            if (OnFileDragDrop != null)
            {
                OnFileDragDrop(sender, args);
            }

        }

        /// <summary>
        /// 初始化颜色
        /// </summary>
        /// <returns></returns>
        private static List<Color> InitialColors()
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
        private void Btn_Click(object sender, EventArgs e)
        {
            //触发事件
            if (OnCategroyButtonClick != null)
            {
                Category c = ((SkinButton)sender).Tag as Category;
                OnCategroyButtonClick(c, null);
            }
        }


        /// <summary>
        /// 事件参数
        /// </summary>
        public class FileDragDropArgs : System.EventArgs
        {
            public Category FileCategory { get; set; }
            public System.Array FlileArray { get; set; }
        }
        
    }
}
