using System;
using System.Drawing;
using System.Drawing.Drawing2D;
//using BarcodeLib;

namespace CL.Common.Print
{
    public static class Code128Rendering
    {
        #region   变量和属性

        private static string topStr;

        public static string TopStr
        {
            get { return topStr; }
            set { topStr = value; }
        }

        private static string bottomStr;

        public static string BottomStr
        {
            get { return bottomStr; }
            set { bottomStr = value; }
        }

        private static string rightStr;

        public static string RightStr
        {
            get { return rightStr; }
            set { rightStr = value; }
        }

        private static string rightBottomStr;

        public static string RightBottomStr
        {
            get { return rightBottomStr; }
            set { rightBottomStr = value; }
        }

        private static string encodeValue;

        public static string EncodeValue
        {
            get { return encodeValue; }
            set { encodeValue = value; }
        }

        private static int barHeight;

        public static int BarHeight
        {
            get { return barHeight; }
            set { barHeight = value; }
        }

        private static int toLeft;

        public static int ToLeft
        {
            get { return toLeft; }
            set { toLeft = value; }
        }

        private static int toTop;

        public static int ToTop
        {
            get { return toTop; }
            set { toTop = value; }
        }

        private static Color backColor;

        public static Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        private static Color foreColor;

        public static Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }

        #endregion

        /// <summary>
        /// 绘制条形码
        /// </summary>
        /// <param name="g"></param>
        public static void DrawBar(Graphics g)
        {
            if (EncodeValue == "")
            {
                throw new Exception("条码值不能为空！");
            }

            BackColor = Color.White;
            ForeColor = Color.Black;

            int iBarWidth = 1;
            BarHeight = 35;

            ToTop = 0;
            ToLeft = 20;

            Pen pen = new Pen(ForeColor, iBarWidth);
            pen.Alignment = PenAlignment.Center;

            Matrix matrix1 = new Matrix();
            matrix1.Scale(0.85f, 1);
            g.Transform = matrix1;

            //1.画条码
            int pos = 0;
            while (pos < EncodeValue.Length)
            {
                if (EncodeValue[pos] == '1')
                {
                    g.DrawLine(pen, new Point(ToLeft + pos * iBarWidth, ToTop + 16), new Point(ToLeft + pos * iBarWidth, ToTop + BarHeight + 16));//加16的原因是为了把上面空出来，因为顶部还要添加标签
                }

                pos++;
            }

            //恢复全局变换矩阵
            g.ResetTransform();


            //2.画标签             
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            StringFormat f = new StringFormat();
            f.Alignment = StringAlignment.Near;

            //2.2画底部的标签
            Font bottomFont = new Font("华文仿宋", 12, FontStyle.Bold);
            g.DrawString(BottomStr, bottomFont, new SolidBrush(ForeColor), (float)(ToLeft+12), ToTop + BarHeight + 16);//buttom

            g.SmoothingMode = SmoothingMode.Default;
            g.InterpolationMode = InterpolationMode.Default;
            g.PixelOffsetMode = PixelOffsetMode.Default;
            g.CompositingQuality = CompositingQuality.Default;

            g.Save();
            g.Dispose();
        }

        /// <summary>
        /// 根据传入的字符串绘制相应的条码
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="g"></param>
        public static void MakeBarcodeImage(string barCode, Graphics g)
        {
            IBarcode ibarcode;
            ibarcode = new Code128(barCode, Code128.TYPES.B);
            EncodeValue = ibarcode.Encoded_Value;

            BottomStr = barCode;

            g.Clear(Color.White);
            DrawBar(g);
        }

    }
}
