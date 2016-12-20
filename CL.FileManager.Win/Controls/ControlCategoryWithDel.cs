using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL.Model;
using System.Drawing;

namespace CL.FileManager.Win.Controls
{
    public class ControlCategoryWithDel : ControlCategory
    {

        #region 事件
        /// <summary>
        /// 当控件中的类型发生改变事件
        /// </summary>
        public event System.EventHandler OnCategoryChanged;
        #endregion

        #region 构造方法
        public ControlCategoryWithDel()
        {
            this.AutoScroll = true;
            this.Height = 30;
        }
        #endregion

        #region 重写父类的方法
        public override void LoadCategory(List<Category> categoryList)
        {
            //base.LoadCategory(categoryList);
            if (categoryList == null)
            {
                return;
            }

            foreach (Category category in categoryList)
            {
                AddCategory(category);
            }
        }
        #endregion

        #region 事件的处理
        private void Btn_OnDelClick(object sender, EventArgs e)
        {
            //删除控件
            ButtonWithDel btn = (ButtonWithDel)sender;
            RemoveButton(btn);

            //触发事件
            OnCategoryChanged?.Invoke(this, null);
        }

        /// <summary>
        /// 移除控件
        /// </summary>
        /// <param name="btn"></param>
        private void RemoveButton(ButtonWithDel btn)
        {
            //删除该控件
            if (this.Controls.Contains(btn))
            {
                this.Controls.Remove(btn);
            }
        }
        #endregion

        #region 公共的属性和方法
        /// <summary>
        /// 当前控件中的类型list
        /// </summary>
        public List<Category> Categories
        {
            get
            {
                var result = from System.Windows.Forms.Control c in this.Controls
                             where c.GetType().Equals(typeof(ButtonWithDel)) 
                             select (Category)((ButtonWithDel)c).Tag;
                return result.ToList();
            }
        }

        /// <summary>
        /// 添加类型到
        /// </summary>
        /// <param name="c"></param>
        public override void AddCategory(Category category)
        {
            if (category == null
                || this.Categories.Find(c => c.ICId == category.ICId) != null)
            {
                return;
            }
            
            ButtonWithDel btn = new ButtonWithDel();
            btn.AllowDrop = true;
            btn.Tag = category;
            btn.Text = category.CCategoryName;
            btn.BackColor = colors[rd.Next(colors.Count)];
            //btn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            btn.BackColor = colors[rd.Next(colors.Count)];
            //btn.Width = (int)(category.CCategoryName.Length * btn.Font.Size * 2) + 8;

            //事件
            btn.OnButtonClick += Btn_Click;
            btn.OnDelClick += Btn_OnDelClick;

            this.Controls.Add(btn);

            //触发事件
            OnCategoryChanged?.Invoke(this, null);

        }
        #endregion

    }
    
}
