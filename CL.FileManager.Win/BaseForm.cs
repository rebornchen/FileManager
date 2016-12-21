using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CCWin;

namespace CL.FileManager.Win
{
    public class BaseForm : CCSkinMain
    {
        public BaseForm()
        {
            ThemeChanged("Dev");
        }

        #region 更换主题
        /// <summary>
        /// 更换主题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemeChanged(string theme)
        {
            //string theme = cboTheme.SelectedItem.ToString();
            switch (theme)
            {
                case "Mac":
                    this.XTheme = new Skin_Mac() { };
                    break;
                case "Dev":
                    this.XTheme = new Skin_DevExpress() { };
                    break;
                case "VS":
                    this.XTheme = new Skin_VS() { };
                    break;
                case "Win8":
                    this.XTheme = new Skin_Metro() { };
                    break;
                case "Color":
                    this.XTheme = new Skin_Color() { };
                    break;
                case "None":
                    //            如果不想变动的属性可以在↓这里输入
                    this.XTheme = new CCSkinMain() { Shadow = false };
                    break;
            }
        }
        #endregion
    }
}
