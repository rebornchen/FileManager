using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CL.FileManager.Win.Commons
{
    public class UICommon
    {

        public static float GetControlWidth(string text, Font font, System.Windows.Forms.Control c)
        {
            Graphics graphics = c.CreateGraphics();
            SizeF sizeF = graphics.MeasureString(text, font);
            graphics.Dispose();
            return sizeF.Width;
        }

    }
}
