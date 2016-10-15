using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using System.Web;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;


namespace CL.Common
{
    public class NPOIStyle
    {
        public HSSFWorkbook Hssfworkbook = new HSSFWorkbook();

        #region 单元格细边框(重复方法)
        ///// <summary>
        ///// 单元格细边框，并居中
        ///// </summary>
        //public  ICellStyle CellThin(HSSFWorkbook Hssfworkbook)
        //{
        //    ICellStyle _CellThin = Hssfworkbook.CreateCellStyle();
        //        _CellThin.BorderBottom = BorderStyle.Thin;
        //        _CellThin.BorderLeft = BorderStyle.Thin;
        //        _CellThin.BorderRight = BorderStyle.Thin;
        //        _CellThin.BorderTop = BorderStyle.Thin;
        //        _CellThin.Alignment = HorizontalAlignment.Center;
        //        _CellThin.VerticalAlignment = VerticalAlignment.Center;

        //    return _CellThin; 
        //}
        #endregion

        #region 表头样式
        /// <summary>
        /// 大标题 并居中,单元格无边框
        /// </summary>
        private ICellStyle _CellHeader = null;
        public ICellStyle CellHeader
        {
            get
            {
                _CellHeader = Hssfworkbook.CreateCellStyle();
                _CellHeader.Alignment = HorizontalAlignment.Center;
                _CellHeader.VerticalAlignment = VerticalAlignment.Center;
                IFont font = Hssfworkbook.CreateFont();
                font.FontHeight = 18 * 18;
                font.Boldweight = 15 * 15;
                _CellHeader.SetFont(font);
                return _CellHeader;
            }
        }
        #endregion

        #region 居中
        private ICellStyle _CellCenter = null;
        /// <summary>
        /// 单元格细边框，并居中
        /// </summary>
        public ICellStyle CellCenter
        {
            get
            {
                _CellCenter = Hssfworkbook.CreateCellStyle();
                _CellCenter.BorderBottom = BorderStyle.Thin;
                _CellCenter.BorderLeft = BorderStyle.Thin;
                _CellCenter.BorderRight = BorderStyle.Thin;
                _CellCenter.BorderTop = BorderStyle.Thin;
                _CellCenter.Alignment = HorizontalAlignment.Center;
                _CellCenter.VerticalAlignment = VerticalAlignment.Center;
                return _CellCenter;
            }
        }

        private ICellStyle _CellCenterPublic = null;
        /// <summary>
        /// 单元格细边框，并居中
        /// </summary>
        public ICellStyle CellCenterPublic
        {
            set
            {
                _CellCenterPublic = value;
            }
            get
            {
                if (_CellCenterPublic != null) return _CellCenterPublic;
                else
                {
                    _CellCenterPublic = Hssfworkbook.CreateCellStyle();
                    _CellCenterPublic.BorderBottom = BorderStyle.Thin;
                    _CellCenterPublic.BorderLeft = BorderStyle.Thin;
                    _CellCenterPublic.BorderRight = BorderStyle.Thin;
                    _CellCenterPublic.BorderTop = BorderStyle.Thin;
                    _CellCenterPublic.Alignment = HorizontalAlignment.Center;
                    _CellCenterPublic.VerticalAlignment = VerticalAlignment.Center;
                    return _CellCenterPublic;
                }
            }
        }
        #endregion

        #region 单元格上面为中等粗线，其他为细边框
        private ICellStyle _CellTopMedium = null;
        /// <summary>
        /// 单元格上面为中等粗线，其他为细边框
        /// </summary>
        public ICellStyle CellTopMedium
        {
            get
            {
                _CellTopMedium = Hssfworkbook.CreateCellStyle();
                _CellTopMedium.BorderBottom = BorderStyle.Thin;
                _CellTopMedium.BorderLeft = BorderStyle.Thin;
                _CellTopMedium.BorderRight = BorderStyle.Thin;
                _CellTopMedium.BorderTop = BorderStyle.Medium;
                _CellTopMedium.WrapText = true;
                _CellTopMedium.Alignment = HorizontalAlignment.Center;
                _CellTopMedium.VerticalAlignment = VerticalAlignment.Center;
                return _CellTopMedium;
            }
        }
        #endregion

        #region 单元格下面为中等粗线，其他为细边框
        private ICellStyle _CellBottomMedium = null;
        /// <summary>
        /// 单元格下面为中等粗线，其他为细边框
        /// </summary>
        public ICellStyle CellBottomMedium
        {
            get
            {
                _CellBottomMedium = Hssfworkbook.CreateCellStyle();
                _CellBottomMedium.BorderBottom = BorderStyle.Medium;
                _CellBottomMedium.BorderLeft = BorderStyle.Thin;
                _CellBottomMedium.BorderRight = BorderStyle.Thin;
                _CellBottomMedium.BorderTop = BorderStyle.Thin;
                _CellBottomMedium.Alignment = HorizontalAlignment.Center;
                return _CellBottomMedium;
            }
        }
        #endregion

        #region 单元格左面为中等粗线，其他为细边框
        private ICellStyle _CellLeftMedium = null;
        /// <summary>
        /// 单元格左面为中等粗线，其他为细边框
        /// </summary>
        public ICellStyle CellLeftMedium
        {
            get
            {
                _CellLeftMedium = Hssfworkbook.CreateCellStyle();
                _CellLeftMedium.BorderBottom = BorderStyle.Thin;
                _CellLeftMedium.BorderLeft = BorderStyle.Medium;
                _CellLeftMedium.BorderRight = BorderStyle.Thin;
                _CellLeftMedium.BorderTop = BorderStyle.Thin;
                _CellLeftMedium.Alignment = HorizontalAlignment.Center;
                return _CellLeftMedium;
            }
        }
        #endregion

        #region 单元格右面为中等粗线，其他为细边框
        private ICellStyle _CellRightMedium = null;
        /// <summary>
        /// 单元格右面为中等粗线，其他为细边框
        /// </summary>
        public ICellStyle CellRightMedium
        {
            get
            {
                _CellRightMedium = Hssfworkbook.CreateCellStyle();
                _CellRightMedium.BorderBottom = BorderStyle.Thin;
                _CellRightMedium.BorderLeft = BorderStyle.Thin;
                _CellRightMedium.BorderRight = BorderStyle.Medium;
                _CellRightMedium.BorderTop = BorderStyle.Thin;
                _CellRightMedium.VerticalAlignment = VerticalAlignment.Center;
                _CellRightMedium.Alignment = HorizontalAlignment.Center;
                return _CellRightMedium;
            }
        }
        #endregion


        #region 单元格左上角为中等粗线，其他为细边框
        private ICellStyle _CellLeftTopMedium = null;
        /// <summary>
        /// 单元格左上角为中等粗线，其他为细边框
        /// </summary>
        public ICellStyle CellLeftTopMedium
        {
            get
            {
                _CellLeftTopMedium = Hssfworkbook.CreateCellStyle();
                _CellLeftTopMedium.BorderBottom = BorderStyle.Thin;
                _CellLeftTopMedium.BorderLeft = BorderStyle.Medium;
                _CellLeftTopMedium.BorderRight = BorderStyle.Thin;
                _CellLeftTopMedium.BorderTop = BorderStyle.Medium;
                _CellLeftTopMedium.Alignment = HorizontalAlignment.Center;
                return _CellLeftTopMedium;
            }
        }
        #endregion

        #region 单元格左下角为中等粗线，其他为细边框
        private ICellStyle _CellLeftBottomMedium = null;
        /// <summary>
        /// 单元格左下角为中等粗线，其他为细边框
        /// </summary>
        public ICellStyle CellLeftBottomMedium
        {
            get
            {
                _CellLeftBottomMedium = Hssfworkbook.CreateCellStyle();
                _CellLeftBottomMedium.BorderBottom = BorderStyle.Medium;
                _CellLeftBottomMedium.BorderLeft = BorderStyle.Medium;
                _CellLeftBottomMedium.BorderRight = BorderStyle.Thin;
                _CellLeftBottomMedium.BorderTop = BorderStyle.Thin;
                _CellLeftBottomMedium.VerticalAlignment = VerticalAlignment.Center;
                _CellLeftBottomMedium.Alignment = HorizontalAlignment.Center;
                return _CellLeftBottomMedium;
            }
        }
        #endregion

        #region 单元格右上角为中等粗线，其他为细边框
        private ICellStyle _CellRightTopMedium = null;
        /// <summary>
        /// 单元格右上角为中等粗线，其他为细边框
        /// </summary>
        public ICellStyle CellRightTopMedium
        {
            get
            {
                _CellRightTopMedium = Hssfworkbook.CreateCellStyle();
                _CellRightTopMedium.BorderBottom = BorderStyle.Thin;
                _CellRightTopMedium.BorderLeft = BorderStyle.Thin;
                _CellRightTopMedium.BorderRight = BorderStyle.Medium;
                _CellRightTopMedium.BorderTop = BorderStyle.Medium;
                _CellRightTopMedium.WrapText = true;
                _CellRightTopMedium.Alignment = HorizontalAlignment.Center;
                _CellRightTopMedium.VerticalAlignment = VerticalAlignment.Center;
                return _CellRightTopMedium;
            }
        }
        #endregion

        #region 单元格右下角为中等粗线，其他为细边框
        private ICellStyle _CellRightBottomMedium = null;
        /// <summary>
        /// 单元格右下角为中等粗线，其他为细边框
        /// </summary>
        public ICellStyle CellRightBottomMedium
        {
            get
            {
                _CellRightBottomMedium = Hssfworkbook.CreateCellStyle();
                _CellRightBottomMedium.BorderBottom = BorderStyle.Medium;
                _CellRightBottomMedium.BorderLeft = BorderStyle.Thin;
                _CellRightBottomMedium.BorderRight = BorderStyle.Medium;
                _CellRightBottomMedium.BorderTop = BorderStyle.Thin;
                _CellRightBottomMedium.VerticalAlignment = VerticalAlignment.Center;
                _CellRightBottomMedium.Alignment = HorizontalAlignment.Center;
                return _CellRightBottomMedium;
            }
        }
        #endregion

        #region 单元格上左右为中等粗线，其他为细边框
        /// <summary>
        /// 单元格上左右为中等粗线，其他为细边框
        /// </summary>
        public ICellStyle CellTopRLMedium(HSSFWorkbook Hssfworkbook)
        {
            ICellStyle _CellTopRLMedium = Hssfworkbook.CreateCellStyle();
            _CellTopRLMedium.BorderBottom = BorderStyle.Thin;
            _CellTopRLMedium.BorderLeft = BorderStyle.Medium;
            _CellTopRLMedium.BorderRight = BorderStyle.Medium;
            _CellTopRLMedium.BorderTop = BorderStyle.Medium;
            _CellTopRLMedium.VerticalAlignment = VerticalAlignment.Center;
            _CellTopRLMedium.Alignment = HorizontalAlignment.Center;
            return _CellTopRLMedium;
        }
        #endregion
        private IFont _FontCommon = null;
        /// <summary>
        /// 普通字体
        /// </summary>
        public IFont FontCommon(short color, short fontHeight, bool bold)
        {
            _FontCommon = Hssfworkbook.CreateFont();
            if (fontHeight > 0)
            {
                _FontCommon.FontHeight = fontHeight;
            }
            if (bold)
            {
                _FontCommon.Boldweight = (short)FontBoldWeight.Bold;
            }
            if (color > 0)
            {
                _FontCommon.Color = color;
            }
            return _FontCommon;
        }

        #region 转换编码

        public string UTF_FileName(string filename)
        {
            filename = HttpUtility.UrlEncode(filename, Encoding.UTF8);
            filename = filename.Replace("+", "%20");//转换完以后空格变加好了 再把加好变空格
            return filename;
        }
        #endregion


        #region NPOI_Init
        public void NPOI_Init(HSSFWorkbook Workbook, ICellStyle TitleStyle, ICellStyle TwoTitleStyle)
        {
            //初始化大标题样式
            TitleStyle = Workbook.CreateCellStyle();
            TitleStyle.Alignment = HorizontalAlignment.Center;
            IFont font = Workbook.CreateFont();
            font.Boldweight = 2;
            font.FontHeight = 30 * 30;
            TitleStyle.SetFont(font);

            //初始化第二标题样式
            TwoTitleStyle = Workbook.CreateCellStyle();
            TwoTitleStyle.Alignment = HorizontalAlignment.Center;
            TwoTitleStyle.FillForegroundColor = HSSFColor.PaleBlue.Index;
            //TwoTitleStyle.FillPattern = FillPatternType.SOLID_FOREGROUND;
        }
        #endregion


    }
}
