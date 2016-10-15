//-----------------------------------------------------------------------------
// 文 件 名: PrintMaterialBarCode
// 作    者：[xiao rui]
// 创建时间：2014/9/24 18:03:03
// 描    述：
// 版    本：
//-----------------------------------------------------------------------------
// 历史更新纪录
//-----------------------------------------------------------------------------
// 版    本：           修改时间：           修改人：          
// 修改内容：
//-----------------------------------------------------------------------------
// Copyright (C) 武汉侏罗纪技术开发有限公司
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Zen.Barcode;
using System.Drawing.Printing;
using TestPlanModel;
using System.Drawing.Drawing2D;

namespace CL.Common.Print
{
    /// <summary>
    /// Added by xiaorui,PrintMaterialBarCode
    /// </summary>
    public class PrintMaterialBarCode
    {

        #region 私有字段
        public SymbologyTestPlan _testPlan;
        private IEnumerator<SymbologyTestCase> _testIterator;
        private int imageWidth = 250;//整个图片的宽度，包括里面的：条码矩阵宽度+两侧空白区域的宽度
        private int imageHeight = 80;//整个图片的高度，包括里面的：条码矩阵高度+间隔+条码文本高度+上下两侧空白区域的宽度
        private int _maxBarHeight = 47;//条码矩阵高度
        private int _maxBarWidth = 120;//条码矩阵宽度，这个宽度不起作用，实际是根据Linesize 的宽度决定的
        private int _barcodeTexttopmargin = 3;
        private int _barcodeColumns = 2;
        private int _barcodesPerPage = 20;
        private int _barcodePadding = 10;
        int top = 2;                                                                //条码左边坐标
        int left = 2;   
        private Font _barcodeFont;

        #endregion
       
        public PrintMaterialBarCode()
        {

        }

        /// <summary>
        /// added by xiao rui,生成条码图片
        /// </summary>
        /// <param name="barcode">barcode数组
        /// </param>
        /// <returns></returns>
        //public List<Bitmap> CreateBarcodeImage(string[] barcode)
        //{

        //    if (barcode == null || barcode.Length == 0) return null;
        //    if (_testPlan == null)
        //    {
        //        _testPlan = new SymbologyTestPlan();
        //    }
            
        //    _testPlan.AddTestCase(BarcodeSymbology.Code128, barcode.ToList());
        //    _testIterator = _testPlan.GetTestCases(_maxBarHeight).ToList();
        //    //_barcodeFont = new Font("Verdana", 8, FontStyle.Regular);
        //    _barcodeFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            

        //    List<Bitmap> images = new List<Bitmap>();

        //    //不同条码产生不同的编码图片
        //    for (int i = 0; i < _testIterator.Count; i++)
        //    {
        //        Bitmap image = new Bitmap(imageWidth, imageHeight);
        //        Graphics g = Graphics.FromImage(image);
        //        PointF topLeft = new PointF(top,left);
                
                
        //        //g.ScaleTransform(0.7f, 1);//此方法缩放barcode图片，x*0.7,y*1
        //        //g.ScaleTransform(0.95f, 0.95f);//此方法缩放barcode图片，x*0.7,y*1
        //        g.ScaleTransform(0.9f,1 ,System.Drawing.Drawing2D.MatrixOrder.Append);
        //        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                
        //        g.DrawImage(_testIterator[i].BarcodeImage, topLeft);//在图片top,left坐标点开始绘制height=_maxBarHeight的barcode 图片。
        //        //PointF textLocation = new PointF(topLeft.X, topLeft.Y);
        //        PointF textLocation = new PointF();//barcode 下面文字部分的坐标
        //        // Adjust text position
        //        textLocation.X = left;//文字左边距
        //        textLocation.Y = top + _testIterator[i].BarcodeImage.Height + _barcodeTexttopmargin;//文字上边距+图片高度+间隔
                
        //        // Determine text area
        //        string barcodeLabelText = _testIterator[i].BarcodeText;
                
        //        // Draw text
        //        //e.Graphics.DrawString(barcodeLabelText, _barcodeFont,
        //        //    SystemBrushes.WindowText, textLocation);
        //        g.DrawString(barcodeLabelText, _barcodeFont,
        //           SystemBrushes.WindowText, textLocation);
        //        images.Add(image);
        //        g.Dispose();
        //    }
        //    return images;
        //}

        public List<Bitmap> CreateBarcodeImage(string[] barcode)
        {

            if (barcode == null || barcode.Length == 0) return null;
            if (_testPlan == null)
            {
                _testPlan = new SymbologyTestPlan();
            }
            
            _testPlan.AddTestCase(BarcodeSymbology.Code128, barcode.ToList());
            _testIterator = _testPlan.GetTestCases(_maxBarHeight).GetEnumerator();
            _barcodeFont = new Font("Verdana", 8, FontStyle.Regular);


            // Determine printable region for each barcode and label
            int numLines = _barcodesPerPage / _barcodeColumns;
            if ((_barcodesPerPage % _barcodeColumns) != 0)
            {
                ++numLines;
            }

            // Determine size to allocate for each barcode
            SizeF barcodeArea = new SizeF();
            barcodeArea.Width =
                (imageWidth / _barcodeColumns);
            barcodeArea.Height =
                (imageHeight / numLines);


            List<Bitmap> images = new List<Bitmap>();

            //不同条码产生不同的编码图片
            for (int index = 0; index < _barcodesPerPage; ++index)
            {
                // Fetch the next test
                if (!_testIterator.MoveNext())
                {
                    break;
                }

                Bitmap image = new Bitmap(imageWidth, imageHeight);
                Graphics g = Graphics.FromImage(image);
                
                // Determine placement rectangle
                PointF topLeft = new PointF(
                    ((index % _barcodeColumns) * barcodeArea.Width) + left,
                    ((index / _barcodeColumns) * barcodeArea.Height) + top);
                RectangleF drawRectangle = new RectangleF(
                    topLeft, barcodeArea);

                PointF textLocation = new PointF(topLeft.X, topLeft.Y);

                // Render barcode image and label
                using (SymbologyTestCase testCase = _testIterator.Current)
                {
                    PointF imageLocation = new PointF(topLeft.X, topLeft.Y);
                    imageLocation.X += (drawRectangle.Width - testCase.BarcodeImage.Width) / 2;
                    imageLocation.Y += _barcodePadding;

                    // 
                    g.Clear(Color.White);
                    //g.ScaleTransform(0.7f, 1);
                    //e.Graphics.DrawImage(testCase.BarcodeImage, imageLocation);
                    g.DrawImage(testCase.BarcodeImage, new Point(top, left));

                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    //恢复全局变换矩阵
                    //g.ResetTransform();
                    // Adjust text position
                    textLocation.Y += (_barcodePadding * 2) + testCase.BarcodeImage.Height;

                    // Determine text area
                    string barcodeLabelText = testCase.BarcodeText;
                    SizeF textSize = g.MeasureString(barcodeLabelText, _barcodeFont);
                    textLocation.X += (drawRectangle.Width - textSize.Width) / 2;

                    // Draw text
                    //e.Graphics.DrawString(barcodeLabelText, _barcodeFont,
                    //    SystemBrushes.WindowText, textLocation);
                    g.DrawString(barcodeLabelText, _barcodeFont,
                       SystemBrushes.WindowText, new Point(6, 50));

                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;

                    images.Add(image);
                }
            }
            return images;
        }


    }
}
