using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CCWin.SkinControl;
using System.Drawing;
using CL.Model;

namespace CL.FileManager.Win.Controls
{
    public class ControlCategory : CCWin.SkinControl.SkinFlowLayoutPanel
    {
        BLL.CategoryBiz biz = new BLL.CategoryBiz();

        /// <summary>
        /// 加载类型
        /// </summary>
        public void LoadCategory ()
        {
            //List<string> list = new List<string>();
            //list.Add("时间");
            //list.Add("北汽项目");
            //list.Add("北汽项目培训资料");
            //list.Add("北汽项目出差");
            //list.Add("2016.10");
            //list.Add("2016.11");


            //CL.BLL.RegionBiz biz = new CL.BLL.RegionBiz();
            //List<Model.Region> list = biz.GetAll();

            //Model.Region model = list.Find(r => r.RegionID == 3);


            //Assert.AreEqual(4, list.Count);
            //Assert.AreEqual("Northern", model.RegionDescription.Trim());


            List<Category> categoryList = biz.GetAllTopCategory();


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

            Random rd = new Random();

            foreach (Category category in categoryList)
            {
                SkinButton btn = new SkinButton();
                btn.Text = category.CCategoryName;
                btn.BaseColor = colors[rd.Next(colors.Count)];
                btn.Width = (int)(category.CCategoryName.Length * btn.Font.Size * 2) + 8;

                this.Controls.Add(btn);
            }



        }
    }
}
