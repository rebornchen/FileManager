using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.UI.Logic.DirPath
{
    public class DateRule : DirPathRule
    {
        private string date = System.DateTime.Now.ToString("yyyy-MM");

        #region 构造方法
        public DateRule(DirPathRule dirPathRule) 
            : base(dirPathRule.GetPath())
        {
            
        }

        public DateRule(DirPathRule dirPathRule, string date )
            : base(dirPathRule.GetPath())
        {
            this.date = date;
        }
        #endregion

        #region 重写父类的方法
        /// <summary>
        /// 重写父类的方法
        /// </summary>
        /// <returns></returns>
        public override string GetPath()
        {
            string path = base.GetPath();
            path += date + "\\";
            return path;
        }
        #endregion
    }
}
