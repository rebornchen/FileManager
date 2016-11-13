using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CCWin.SkinControl;
using System.Drawing;

namespace CL.FileManager.Win.Controls
{
    public class ControlCategory : CCWin.SkinControl.SkinFlowLayoutPanel
    {
        /// <summary>
        /// 加载类型
        /// </summary>
        public void LoadCategory ()
        {
            List<string> list = new List<string>();
            list.Add("时间");
            list.Add("北汽项目");
            list.Add("北汽项目培训资料");
            list.Add("北汽项目出差");
            list.Add("2016.10");
            list.Add("2016.11");

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

            foreach (string str in list)
            {
                SkinButton btn = new SkinButton();
                btn.Text = str;
                btn.BaseColor = colors[rd.Next(colors.Count)];
                btn.Width = (int)(str.Length * btn.Font.Size * 2) + 8;

                this.Controls.Add(btn);
            }
        }
    }
}
