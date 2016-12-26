using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL.UI.Logic.DirPath
{
    public class CategoryRule : DirPathRule
    {
        /// <summary>
        /// 类型
        /// </summary>
        private string category = String.Empty;
        /// <summary>
        /// 类型文件夹规则
        /// </summary>
        /// <param name="dirPathRule">观察者模式的对象</param>
        /// <param name="category">类型</param>
        public CategoryRule(DirPathRule dirPathRule, string category) : base(dirPathRule.GetPath())
        {
            this.category = category;
        }

        /// <summary>
        /// 返回路径
        /// </summary>
        /// <returns></returns>
        public override string GetPath()
        {
            string path = base.GetPath();
            path += category + "\\";
            return path;
        }

    }
}
