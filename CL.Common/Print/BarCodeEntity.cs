using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CL.Common.Print
{
    /// <summary>
    /// 条形码类
    /// </summary>
   public class BarCodeEntity
    {

       private const string ORGANIZATIONNAME="超低渗透油藏研究中心信息技术室";
       private const string CATALOGNAME = "油气勘探库";
       private const int LEFTPOSITION = 10;//40
       private const int TOPPOSITION = 10;//20

       public BarCodeEntity()
       { 
       }

        private string topStr;

        public string TopStr
        {
            get { return topStr; }
            set { topStr = value; }
        }

        private string bottomStr;

        public string BottomStr
        {
            get { return bottomStr; }
            set { bottomStr = value; }
        }

        private string rightStr;

        public string RightStr
        {
            get { return rightStr; }
            set { rightStr = value; }
        }

        private string rightBottomStr;

        public string RightBottomStr
        {
            get { return rightBottomStr; }
            set { rightBottomStr = value; }
        }

        private string encodeValue;

        public string EncodeValue
        {
            get { return encodeValue; }
            set { encodeValue = value; }
        }

        private int barHeight;

        public int BarHeight
        {
            get { return barHeight; }
            set { barHeight = value; }
        }

        private int toLeft;

        public int ToLeft
        {
            get { return toLeft; }
            set { toLeft = value; }
        }

        private int toTop;

        public int ToTop
        {
            get { return toTop; }
            set { toTop = value; }
        }

        private Color backColor;

        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        private Color foreColor;

        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }

       

       //public static void DrawBox1(Graphics g,string str)
       //{
       //    int startX = 30;
       //    int startY = 20;
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(350, 0));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 5), new Point(350,5));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, startY), new Point(350,startY));
       //    //2.画标签             
       //    g.SmoothingMode = SmoothingMode.HighQuality;
       //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
       //    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
       //    g.CompositingQuality = CompositingQuality.HighQuality;

       //    //g.DrawLine(new Pen(Color.Red),new Point(0,0),new Point(320,120));

       //    //string cerStr = "超低渗透油藏研究中心信息技术室";
       //    //string catalogName = "单井库";


          
       //    int addWidth = 0 + startX;
       //    int addHeight = 0 + startY;

       //    //1.画竖排文字
       //    StringFormat f = new StringFormat();
       //    f.Alignment = StringAlignment.Far;
       //    f.FormatFlags = StringFormatFlags.DirectionVertical;

       //    //2.1画顶部的标签
       //    Font bottonFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
       //    g.DrawString(ORGANIZATIONNAME, bottonFont, new SolidBrush(Color.Black), (float)addWidth, (float)addHeight, f);//top

       //    float height = g.MeasureString(ORGANIZATIONNAME, bottonFont, new PointF((float)addWidth, (float)addHeight), f).Height;
       //    float width = g.MeasureString(ORGANIZATIONNAME, bottonFont, new PointF((float)addWidth, (float)addHeight), f).Width;

       //    //g.DrawLine(new Pen(Color.Red), new Point( 50 + width / 2,0), new Point(50 + width / 2,500));

       //    //画上面的图标
       //    //g.DrawImage(Properties.Resources.PC, new Rectangle((int)(addWidth + width / 2 - 30)+1, 10, 60, 60));

       //    StringFormat f1 = new StringFormat();
       //    f1.Alignment = StringAlignment.Center;


       //    Font font2 = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

       //    //2.1画顶部的标签
       //    g.DrawString(catalogName, font2, new SolidBrush(Color.Black), (float)addWidth + width / 2 + 1, (float)addHeight + (float)height + 20, f1);//top

       //    float height2 = g.MeasureString(catalogName, bottonFont).Height;


          
       //    //2.1画顶部的标签
       //    g.DrawString(str, font2, new SolidBrush(Color.Black), (float)addWidth + width / 2 + 1, (float)addHeight + (float)height + height2 + 20, f1);//top

       //    int w = (int)(addWidth + width / 2 + 1);
       //    int h = (int)(addHeight + height + height2 + 20);

       //    //g.DrawLine(new Pen(Color.Red), new Point(0, h), new Point(200, h));
       //    //g.DrawLine(new Pen(Color.Red), new Point(0, h+20), new Point(300, h+20));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, h+35), new Point(350, h+35));
       //    MessageBox.Show(h.ToString(), (h + 35).ToString());
       //    //g.DrawLine(new Pen(Color.Red), new Point(0, h + 40), new Point(400, h + 40));
       //}

       //public static void DrawBox2(Graphics g, string str)
       //{
       //    int startX = 108 + 10 + 30;
       //    int startY = 20;


       //    //2.画标签             
       //    g.SmoothingMode = SmoothingMode.HighQuality;
       //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
       //    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
       //    g.CompositingQuality = CompositingQuality.HighQuality;

       //    //g.DrawLine(new Pen(Color.Red),new Point(0,0),new Point(320,120));

       //    string cerStr = "超低渗透油藏研究中心信息技术室";
       //    string catalogName = "单井库";



       //    int addWidth = 0 + startX;
       //    int addHeight = 0 + startY;

       //    //1.画竖排文字
       //    StringFormat f = new StringFormat();
       //    f.Alignment = StringAlignment.Far;
       //    f.FormatFlags = StringFormatFlags.DirectionVertical;

       //    //2.1画顶部的标签
       //    Font bottonFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
       //    g.DrawString(cerStr, bottonFont, new SolidBrush(Color.Black), (float)addWidth, (float)addHeight, f);//top

       //    float height = g.MeasureString(cerStr, bottonFont, new PointF((float)addWidth, (float)addHeight), f).Height;
       //    float width = g.MeasureString(cerStr, bottonFont, new PointF((float)addWidth, (float)addHeight), f).Width;

       //    //g.DrawLine(new Pen(Color.Red), new Point( 50 + width / 2,0), new Point(50 + width / 2,500));

       //    //画上面的图标
       //    //g.DrawImage(Properties.Resources.PC, new Rectangle((int)(addWidth + width / 2 - 30)+1, 10, 60, 60));

       //    StringFormat f1 = new StringFormat();
       //    f1.Alignment = StringAlignment.Center;


       //    Font font2 = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

       //    //2.1画顶部的标签
       //    g.DrawString(catalogName, font2, new SolidBrush(Color.Black), (float)addWidth + width / 2 + 1, (float)addHeight + (float)height + 20, f1);//top

       //    float height2 = g.MeasureString(catalogName, bottonFont).Height;



       //    //2.1画顶部的标签
       //    g.DrawString(str, font2, new SolidBrush(Color.Black), (float)addWidth + width / 2 + 1, (float)addHeight + (float)height + height2 + 20, f1);//top
       //}

       //public static void DrawBox3(Graphics g, string str)
       //{
       //    int startX = 30;
       //    int startY = 364 + 20;


       //    //2.画标签             
       //    g.SmoothingMode = SmoothingMode.HighQuality;
       //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
       //    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
       //    g.CompositingQuality = CompositingQuality.HighQuality;

       //    //g.DrawLine(new Pen(Color.Red),new Point(0,0),new Point(320,120));

       //    string cerStr = "超低渗透油藏研究中心信息技术室";
       //    string catalogName = "单井库";



       //    int addWidth = 0 + startX;
       //    int addHeight = 0 + startY;

       //    //1.画竖排文字
       //    StringFormat f = new StringFormat();
       //    f.Alignment = StringAlignment.Far;
       //    f.FormatFlags = StringFormatFlags.DirectionVertical;

       //    //2.1画顶部的标签
       //    Font bottonFont = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
       //    g.DrawString(cerStr, bottonFont, new SolidBrush(Color.Black), (float)addWidth, (float)addHeight, f);//top

       //    float height = g.MeasureString(cerStr, bottonFont, new PointF((float)addWidth, (float)addHeight), f).Height;
       //    float width = g.MeasureString(cerStr, bottonFont, new PointF((float)addWidth, (float)addHeight), f).Width;

       //    //g.DrawLine(new Pen(Color.Red), new Point( 50 + width / 2,0), new Point(50 + width / 2,500));

       //    //画上面的图标
       //    //g.DrawImage(Properties.Resources.PC, new Rectangle((int)(addWidth + width / 2 - 30)+1, 10, 60, 60));

       //    StringFormat f1 = new StringFormat();
       //    f1.Alignment = StringAlignment.Center;


       //    Font font2 = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

       //    //2.1画顶部的标签
       //    g.DrawString(catalogName, font2, new SolidBrush(Color.Black), (float)addWidth + width / 2 + 1, (float)addHeight + (float)height + 20, f1);//top

       //    float height2 = g.MeasureString(catalogName, bottonFont).Height;



       //    //2.1画顶部的标签
       //    g.DrawString(str, font2, new SolidBrush(Color.Black), (float)addWidth + width / 2 + 1, (float)addHeight + (float)height + height2 + 20, f1);//top
       //}

       //public static void DrawBox4(Graphics g, string str)
       //{
       //    int startX = 108 + 10 + 30;
       //    int startY = 364 + 20;


       //    //2.画标签             
       //    g.SmoothingMode = SmoothingMode.HighQuality;
       //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
       //    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
       //    g.CompositingQuality = CompositingQuality.HighQuality;

       //    //g.DrawLine(new Pen(Color.Red),new Point(0,0),new Point(320,120));

       //    string cerStr = "超低渗透油藏研究中心信息技术室";
       //    string catalogName = "单井库";



       //    int addWidth = 0 + startX;
       //    int addHeight = 0 + startY;

       //    //1.画竖排文字
       //    StringFormat f = new StringFormat();
       //    f.Alignment = StringAlignment.Far;
       //    f.FormatFlags = StringFormatFlags.DirectionVertical;

       //    //2.1画顶部的标签
       //    Font bottonFont = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
       //    g.DrawString(cerStr, bottonFont, new SolidBrush(Color.Black), (float)addWidth, (float)addHeight, f);//top

       //    float height = g.MeasureString(cerStr, bottonFont, new PointF((float)addWidth, (float)addHeight), f).Height;
       //    float width = g.MeasureString(cerStr, bottonFont, new PointF((float)addWidth, (float)addHeight), f).Width;

       //    //g.DrawLine(new Pen(Color.Red), new Point( 50 + width / 2,0), new Point(50 + width / 2,500));

       //    //画上面的图标
       //    //g.DrawImage(Properties.Resources.PC, new Rectangle((int)(addWidth + width / 2 - 30)+1, 10, 60, 60));

       //    StringFormat f1 = new StringFormat();
       //    f1.Alignment = StringAlignment.Center;


       //    Font font2 = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

       //    //2.1画顶部的标签
       //    g.DrawString(catalogName, font2, new SolidBrush(Color.Black), (float)addWidth + width / 2 + 1, (float)addHeight + (float)height + 20, f1);//top

       //    float height2 = g.MeasureString(catalogName, bottonFont).Height;



       //    //2.1画顶部的标签
       //    g.DrawString(str, font2, new SolidBrush(Color.Black), (float)addWidth + width / 2 + 1, (float)addHeight + (float)height + height2 + 20, f1);//top
       //}

       //public static void Draw(Graphics g, string str)
       //{
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(200, 700));
          
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(306, 700));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(308, 700));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(310, 700));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(312, 700));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(10, 760));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(20, 765));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(30, 770));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(40, 775));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(50, 780)); 
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(60, 785));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(70, 790));
       //    g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(80, 795));

       //}



       public void DrawBar(Graphics g)
       {
           if (EncodeValue == "")
           {
               throw new Exception("条码值不能为空！");
           }

           int iBarWidth = 1;

           Pen pen = new Pen(ForeColor, iBarWidth);
           pen.Alignment = PenAlignment.Right;


           Matrix matrix1 = new Matrix();
           matrix1.Scale(0.75f, 1);
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

           g.ResetTransform();


           //2.画标签             
           g.SmoothingMode = SmoothingMode.HighQuality;
           g.InterpolationMode = InterpolationMode.HighQualityBicubic;
           g.PixelOffsetMode = PixelOffsetMode.HighQuality;
           g.CompositingQuality = CompositingQuality.HighQuality;


           StringFormat f = new StringFormat();
           f.Alignment = StringAlignment.Far;

           //2.1画顶部的标签
           Font topFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
           g.DrawString(TopStr, topFont, new SolidBrush(this.ForeColor), (float)(ToLeft + EncodeValue.Length * iBarWidth / 2) * 3 / 4, (float)ToTop, f);//top

           //2.2画底部的标签
           Font bottomFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
           g.DrawString(BottomStr, bottomFont, new SolidBrush(this.ForeColor), (float)(ToLeft + EncodeValue.Length * iBarWidth / 2) * 3 / 4, ToTop + BarHeight + 16, f);//buttom

           //2.3画右边的标签
           System.Drawing.Font font1 = new Font("微软雅黑", 16, FontStyle.Regular);
           StringFormat f1 = new StringFormat();
           f1.Alignment = StringAlignment.Far;
           int fontHeight = (int)g.MeasureString(RightStr, font1).Height;
           int fontWidth = (int)g.MeasureString(RightStr, font1).Width;
           float strHeight = (BarHeight - fontHeight) / 2;

           //2.31 画右下角的标签
           StringFormat f2 = new StringFormat();
           f2.Alignment = StringAlignment.Far;

           //本身这里的横坐标应该加上fontWidth / 2，但是因为右边的文字已经绽放了，所以宽度也就缩减了一半，所以应该除4
           g.DrawString(RightBottomStr, topFont, new SolidBrush(this.ForeColor), (ToLeft + EncodeValue.Length * iBarWidth + 5) * 3 / 4 + (fontWidth / 4), ToTop + BarHeight + 16, f2);//buttom

           //把右边的字体的长宽比缩放成1：2
           Matrix matrix = new Matrix();
           matrix.Scale(0.5f, 1);
           g.Transform = matrix;

           //缩放过后，绘制的坐标也会减小一半，所以应该*2,因为条形码缩放了0.75，所以长度应该再*0.75
           g.DrawString(RightStr, font1, new SolidBrush(this.ForeColor), (ToLeft + EncodeValue.Length * iBarWidth + 5) * 2 * 3 / 4, ToTop + 16 + strHeight, f1);

           //恢复全局变换矩阵
           g.ResetTransform();


           g.SmoothingMode = SmoothingMode.Default;
           g.InterpolationMode = InterpolationMode.Default;
           g.PixelOffsetMode = PixelOffsetMode.Default;
           g.CompositingQuality = CompositingQuality.Default;


           g.Save();

       }

       private void DrawBoxCode(Graphics g, string str,int left,int top,string cName)
       {
           string catalogName = cName == "" ? CATALOGNAME : cName;

           int addWidth = left;
           int addHeight = top;


           //设置画笔的属性             
           g.SmoothingMode = SmoothingMode.HighQuality;
           g.InterpolationMode = InterpolationMode.HighQualityBicubic;
           g.PixelOffsetMode = PixelOffsetMode.HighQuality;
           g.CompositingQuality = CompositingQuality.HighQuality;

           //设置顶部标签的格式
           StringFormat topFormat = new StringFormat();
           topFormat.Alignment = StringAlignment.Far;
           topFormat.FormatFlags = StringFormatFlags.DirectionVertical;

           //1.画顶部的标签
           Font topFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
           g.DrawString(ORGANIZATIONNAME, topFont, new SolidBrush(Color.Black), (float)addWidth, (float)addHeight, topFormat);//top

           //得到顶部标签的高度和宽度
           float topHeight = g.MeasureString(ORGANIZATIONNAME, topFont, new PointF((float)addWidth, (float)addHeight), topFormat).Height;
           float topWidth = g.MeasureString(ORGANIZATIONNAME, topFont, new PointF((float)addWidth, (float)addHeight), topFormat).Width;

           //设置底部文字的格式
           StringFormat bottomFormat = new StringFormat();
           bottomFormat.Alignment = StringAlignment.Far;
           Font bottomFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

           //2.1画底部的标签一
           g.DrawString(catalogName, bottomFont, new SolidBrush(Color.Black), (float)addWidth + topWidth / 2 + 1, (float)addHeight + (float)topHeight + 20, bottomFormat);//top

           //得到底部标签一的高度
           float height2 = g.MeasureString(catalogName, topFont).Height;

           //2.2画底部标签二
           g.DrawString(str, bottomFont, new SolidBrush(Color.Black), (float)addWidth + topWidth / 2 + 1, (float)addHeight + (float)topHeight + height2 + 20, bottomFormat);//top
       }

       public void DrawBoxCodeFour(Graphics g, List<string> strList,string cName)
       {
           string firstBoxCode = "";
           string secondBoxCode = "";
           string thirdBoxCode = "";
           string fourBoxCode = "";

           if (strList[0] != "")
           {
               firstBoxCode = strList[0];
           }
           if (strList[1] != "")
           {
               secondBoxCode = strList[1];
           }
           if (strList[2] != "")
           {
               thirdBoxCode = strList[2];
           }
           if (strList[3] != "")
           {
               fourBoxCode = strList[3];
           }


           if (firstBoxCode != "")
           {
               DrawBoxCode(g, firstBoxCode, LEFTPOSITION, TOPPOSITION, cName);
           }
           if (secondBoxCode != "")
           {
               DrawBoxCode(g, secondBoxCode, LEFTPOSITION + 108 + 10, TOPPOSITION, cName);
           }
           if (thirdBoxCode != "")
           {
               DrawBoxCode(g, thirdBoxCode, LEFTPOSITION, TOPPOSITION + 364,cName);
           }
           if (fourBoxCode != "")
           {
               DrawBoxCode(g, fourBoxCode, LEFTPOSITION + 108 + 10, TOPPOSITION + 364, cName);
           }
       }

       //public void DrawBoxCodeTwo(Graphics g, List<string> strList)
       //{
       //    string firstBoxCode = "";
       //    string secondBoxCode = "";

       //    if (strList[0] != "")
       //    {
       //        firstBoxCode = strList[0];
       //    }
       //    if (strList[1] != "")
       //    {
       //        secondBoxCode = strList[1];
       //    }


       //    if (firstBoxCode != "")
       //    {
       //        DrawBoxCode(g,firstBoxCode, LEFTPOSITION, TOPPOSITION);
       //    }
       //    if (secondBoxCode != "")
       //    {
       //        DrawBoxCode(g, secondBoxCode, LEFTPOSITION + 108 + 10, TOPPOSITION);
       //    }
         
       //}


       public void DrawBoxCodeOne(Graphics g, string str,string cName)
       {
           string catalogName = cName == "" ? CATALOGNAME : cName;

           int addWidth = LEFTPOSITION;
           int addHeight = TOPPOSITION + 10;


           //设置画笔的属性             
           g.SmoothingMode = SmoothingMode.HighQuality;
           g.InterpolationMode = InterpolationMode.HighQualityBicubic;
           g.PixelOffsetMode = PixelOffsetMode.HighQuality;
           g.CompositingQuality = CompositingQuality.HighQuality;

           //设置顶部标签的格式
           StringFormat topFormat = new StringFormat();
           topFormat.Alignment = StringAlignment.Far;
           topFormat.FormatFlags = StringFormatFlags.DirectionVertical;

          Font topFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

           //得到顶部标签的高度和宽度
           float topHeight = g.MeasureString(ORGANIZATIONNAME, topFont, new PointF((float)addWidth, (float)addHeight), topFormat).Height;
           float topWidth = g.MeasureString(ORGANIZATIONNAME, topFont, new PointF((float)addWidth, (float)addHeight), topFormat).Width;


           //平移Graphics对象到窗体中心
           g.TranslateTransform(addWidth,addHeight + topWidth);
           //设置Graphics对象的输出角度
           g.RotateTransform(270);

           g.DrawString(ORGANIZATIONNAME, topFont, new SolidBrush(Color.Black), 0, 0, topFormat);//top

           //恢复全局变换矩阵
           g.ResetTransform();

           //g.DrawLine(new Pen(Color.Red),new Point(0,0),new Point(addWidth,addHeight));

           //g.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(addWidth + (int)topHeight / 2,addHeight + (int)topWidth / 2));



           //设置底部文字的格式
           StringFormat bottomFormat = new StringFormat();
           bottomFormat.Alignment = StringAlignment.Far;
           Font bottomFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

           //平移Graphics对象到窗体中心
           g.TranslateTransform(addWidth+topHeight+20, addHeight + topWidth/2);
           //设置Graphics对象的输出角度
           g.RotateTransform(270);

           //2.1画底部的标签一
           g.DrawString(catalogName, bottomFont, new SolidBrush(Color.Black), 0, 0, bottomFormat);//top

           //恢复全局变换矩阵
           g.ResetTransform();


           //得到底部标签一的高度
           float height2 = g.MeasureString(catalogName, topFont).Height;

           //平移Graphics对象到窗体中心
           g.TranslateTransform(addWidth + topHeight +height2+ 20, addHeight + topWidth / 2);
           //设置Graphics对象的输出角度
           g.RotateTransform(270);

           //2.2画底部标签二
           g.DrawString(str, bottomFont, new SolidBrush(Color.Black), 0, 0, bottomFormat);//top
           //恢复全局变换矩阵
           g.ResetTransform();
       }
    }

}
