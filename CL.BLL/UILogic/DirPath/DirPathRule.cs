using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.UI.Logic.DirPath
{
    public class DirPathRule
    {
        private string path;
        public DirPathRule(string path)
        {
            this.path = path;
        }

        public virtual string GetPath()
        {
            return path;
        }
    }
}
