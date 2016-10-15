using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Web;
using NPOI.HSSF.Util;

namespace CL.Common
{
    /// <summary>
    /// NPOI工具方法（gezhonglei)
    /// <remarks>主要用于规则数据以Excel为载体，以流输出到客户端</remarks>
    /// </summary>
    public class NPOIUtil
    {
        /// <summary>
        /// 用于指定字段渲染的特殊处理。
        /// 一般字段如果不在DoubleField和DateFields中指定时,都默认以String类型处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class TextRender<T>
        {
            private Func<T, String> func;

            public TextRender(Func<T, String> func = null)
            {
                this.func = func;
            }

            public String ValueRender(T obj)
            {
                return func != null ? func(obj) : obj.ToString();
            }
        }

        public abstract class NPOIBaseHandler
        {
            ////用于排序
            //class KeyValueComparer : IComparer<KeyValuePair<int, string>>
            //{
            //    public int Compare(KeyValuePair<int, string> x, KeyValuePair<int, string> y)
            //    {
            //        return x.Key < y.Key ? -1 : x.Key > y.Key ? 1 : x.Value.CompareTo(y.Value);
            //    }
            //}

            /// <summary>
            /// 以List中的顺序、输出所有字段
            /// </summary>
            public List<String> AllFields = new List<string>();
            /// <summary>
            /// 日期类型
            /// </summary>
            public List<String> DateTimeFields = new List<string>();
            /// <summary>
            /// 数字类型
            /// </summary>
            public List<String> DoubleFields = new List<string>();

            /// <summary>
            /// SUM
            /// </summary>
            protected List<String> ColSumFields = null;
            protected int ColOffsetFromDatas = 1;
            protected bool KeepRowFormula = false;
            protected Dictionary<String, List<String>> RowSumFields = new Dictionary<String, List<String>>();
            protected List<KeyValuePair<int, string>> RowSumPos = new List<KeyValuePair<int, string>>();
            protected static string SumFieldPrefix = "sumfields.index";

            /// <summary>
            /// 指定字段渲染成不同的字符串（其它类型通过Excel模板定制）
            /// </summary>
            protected Dictionary<String, TextRender<Object>> TextFields = new Dictionary<string, TextRender<Object>>();


            /// <summary>
            /// 自动识别类型
            /// </summary>
            public Boolean TypeDetectable = false;


            /// <summary>
            /// 需要特殊特殊处理字符串输出
            /// </summary>
            /// <param name="field">字段名（DataTable）或属性名（List)</param>
            /// <param name="render">渲染工具</param>
            public void AddSpecialRender(string field, TextRender<Object> render)
            {
                TextFields.Add(field.ToLower(), render);
            }

            public void AfterInit()
            {
                if (RowSumPos.Count > 0)
                {
                    foreach (var sumfield in RowSumPos)
                    {
                        if (sumfield.Key == -1 || sumfield.Key >= AllFields.Count)
                        {//索引不在AllField的有效范围内，追加到最后
                            AllFields.Add(sumfield.Value);
                        }
                        else if (sumfield.Key < AllFields.Count)
                        {
                            AllFields.Insert(sumfield.Key, sumfield.Value);
                        }
                    }
                }
            }

            /// <summary>
            /// 写一行
            /// </summary>
            /// <param name="row">行对象</param>
            /// <param name="cOffset">起始行</param>
            /// <param name="value">取值</param>
            protected void WriteToRow(IRow row, int cOffset, Func<String, Object> func)
            {
                ICell cell;
                int cStart = cOffset;
                List<string> tmpFields = new List<string>();
                List<string> pos;
                //写内容
                foreach (string field in AllFields)
                {
                    cell = row.GetCell(cOffset++);

                    //如果是统计字段（而不是数据中提供的字段）则添加行统计
                    if (RowSumFields.ContainsKey(field))
                    {
                        tmpFields = RowSumFields[field];
                        pos = new List<string>();
                        foreach (var item in tmpFields)
                        {
                            if (AllFields.Contains(item))
                            {
                                pos.Add(((char)('A' + cStart + AllFields.IndexOf(item))).ToString() + (row.RowNum + 1));
                            }
                        }
                        cell.SetCellFormula(string.Join("+", pos));
                        continue;
                    }

                    TextRender<object> textRender = null;
                    if (TextFields.Count > 0 && TextFields.TryGetValue(field, out textRender))
                    {
                        cell.SetCellValue(textRender.ValueRender(func(field)));
                    }
                    else if (DateTimeFields.Contains(field))
                    {
                        if (func(field) != null)
                            if (!string.IsNullOrEmpty(func(field).ToString()))
                                cell.SetCellValue(DateTime.Parse(func(field).ToString()));
                    }
                    else if (DoubleFields.Contains(field))
                    {
                        cell.SetCellValue(func(field) != null ? Double.Parse(func(field).ToString()) : 0);
                    }
                    else
                    {
                        if (func(field) != null)
                            cell.SetCellValue(func(field).ToString());
                    }
                }
            }

            /// <summary>
            /// 从指定位置写Sheet
            /// </summary>
            /// <param name="sheet">Excel的Sheet</param>
            /// <param name="rowStart">开始行</param>
            /// <param name="colStart">开始列</param>
            /// <param name="rownum">是否显示行号</param>
            /// <returns>返回输出最后一行数据的位置</returns>
            public abstract int Write(ISheet sheet, int rowStart = 0, int colStart = 0, bool rownum = true);

            public abstract List<String> GetDefaultFields();

            /// <summary>
            /// 设置列总计
            /// </summary>
            /// <param name="fields">需要列总计的字段</param>
            /// <param name="rOffset">总计行与最后一行数据的间隔：默认1表示相邻</param>
            /// <param name="keepFormula">导出Excel是否保留公式</param>
            public void SetColumnSumFields(List<string> fields, bool keepFormula = false, int rOffset = 1)
            {
                ColSumFields = fields;
                this.ColOffsetFromDatas = rOffset > 1 ? rOffset : this.ColOffsetFromDatas;
                this.KeepRowFormula = keepFormula;
            }

            /// <summary>
            /// 写列汇总
            /// </summary>
            /// <param name="sheet">Excel中一个Sheet</param>
            /// <param name="rowStart">数据起始行</param>
            /// <param name="rowEnd">数据终止行</param>
            /// <param name="colStart">列起始行</param>
            public void WriteColumnSum(ISheet sheet, int rowStart, int rowEnd, int colStart, bool rownum)
            {
                colStart += rownum ? 1 : 0;

                //设置列汇总
                int cOffset = 0;
                ICell cell;
                string wordStr;
                if (this.ColSumFields != null)
                {
                    HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(sheet.Workbook);
                    foreach (var field in ColSumFields)
                    {
                        cOffset = AllFields.IndexOf(field);
                        if (cOffset > -1)
                        {
                            wordStr = ((char)(colStart + cOffset + 'A')).ToString();
                            cell = sheet.GetRow(rowEnd + ColOffsetFromDatas).GetCell(colStart + cOffset);
                            if (cell != null)
                            {
                                cell.SetCellFormula("SUM(" + wordStr + (rowStart + 1) + ":" + wordStr + (rowEnd + 1) + ")");
                                if (KeepRowFormula)
                                {
                                    e.EvaluateFormulaCell(cell);
                                }
                                else
                                {
                                    e.EvaluateInCell(cell);
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// 添加列，指定由已有的哪些列累加.默认缀到数据最后一列输出
            /// </summary>
            /// <param name="fields">需要累加的字段</param>
            public void AddRowSumField(List<String> subFields)
            {
                AddRowSumField(-1, subFields);
            }

            /// <summary>
            /// 添加列，指定由已有的哪些列累加
            /// </summary>
            /// <param name="index">指定位置，index必须大于等于0，且必须小于数据源输出字段个数，否则追加到最后位置</param>
            /// <param name="sumField">累加字段名</param>
            /// <param name="fields">需要累加的字段</param>
            public void AddRowSumField(int index, List<String> fields)
            {
                string sumField = SumFieldPrefix + RowSumFields.Count;
                AddRowSumField(sumField, index, fields);
            }

            /// <summary>
            /// 添加列，指定由已有的哪些列累加（注意指定列名，不可为数据源中已有字段名）
            /// </summary>
            /// <param name="sumField">指定字段名，不可为数据源中已有字段名</param>
            /// <param name="index">指定位置，index必须大于等于0，且必须小于数据源输出字段个数，否则追加到最后位置</param>
            /// <param name="fields">累加和由哪些字段组成</param>
            public void AddRowSumField(string sumField, int index, List<String> fields)
            {
                RowSumPos.Add(new KeyValuePair<int, string>(index < 0 ? -1 : index, sumField));
                RowSumFields.Add(sumField, fields);
            }
        }

        /// <summary>
        /// 用于处理Datatable输出Excel的配置。
        /// 字段名大小写不敏感。
        /// </summary>
        public class NPOIDataTableHandler : NPOIBaseHandler
        {
            protected DataTable dt;

            public NPOIDataTableHandler(DataTable dt, List<String> fields = null, bool typeDetective = true)
            {
                this.dt = dt;
                this.TypeDetectable = typeDetective;
                if (fields != null && fields.Count > 0)
                {
                    this.AllFields = fields;
                }
            }

            /// <summary>
            /// 初始化参数
            /// </summary>
            private void init()
            {
                //FieldName convert to lower case
                DateTimeFields.ForEach(p => p = p.ToLower());
                DoubleFields.ForEach(p => p = p.ToLower());
                AllFields.ForEach(p => p = p.ToLower());


                if (AllFields.Count == 0)
                {
                    AllFields = this.GetDefaultFields();
                }

                //自动识别
                if (TypeDetectable)
                {
                    foreach (String field in AllFields)
                    {
                        Type type = dt.Columns[field].DataType;
                        if (typeof(DateTime) == type)
                        {
                            DateTimeFields.Add(field);
                        }
                        else if (NPOIUtil.NumberType(type))
                        {
                            DoubleFields.Add(field);
                        }
                    }
                }

            }

            public void Write(ISheet sheet, DataTable dt, int rowStart = 0, int colStart = 0, bool rownum = true)
            {
                //初始化参数
                init();
                AfterInit();//初始化之后的操作

                int rOffset = 0;
                int cOffset = 0;
                int length = AllFields.Count > 0 ? AllFields.Count + (rownum ? 1 : 0) : dt.Columns.Count;
                ICell cell;
                IRow row;

                foreach (DataRow dr in dt.Rows)
                {
                    //创建一行
                    sheet.ShiftRows(rowStart + rOffset + 1, sheet.LastRowNum, 1);//下一行到最后一行，移动一行的距离
                    row = sheet.CreateRow(rowStart + rOffset + 1);//创建下一行供后面使用，写数据时仍使用当前行
                    for (int i = colStart; i < length + colStart; i++)
                    {
                        cell = row.CreateCell(colStart + i);
                        cell.CellStyle = sheet.GetRow(rowStart).GetCell(colStart + i).CellStyle;//上一行的Style
                    }

                    cOffset = colStart;    //initial

                    //写行号
                    if (rownum)
                    {
                        cell = sheet.GetRow(rowStart + rOffset).GetCell(cOffset++);
                        cell.SetCellValue(rOffset + 1);
                    }

                    this.WriteToRow(sheet.GetRow(rowStart + rOffset), cOffset++, field => dr[field]);

                    #region

                    ////写内容
                    //foreach (string columnName in AllFields)
                    //{
                    //    cell = sheet.GetRow(rowStart + rOffset).GetCell(cOffset++);

                    //    TextRender<object> textRender = null;
                    //    if (TextFields.Count > 0 && TextFields.TryGetValue(columnName, out textRender))
                    //    {
                    //        cell.SetCellValue(textRender.ValueRender(dr[columnName]));
                    //    }
                    //    else if (DateTimeFields.Contains(columnName))
                    //    {
                    //        cell.SetCellValue(DateTime.Parse(dr[columnName].ToString()));
                    //    }
                    //    else if (DoubleFields.Contains(columnName))
                    //    {
                    //        cell.SetCellValue(Double.Parse(dr[columnName].ToString()));
                    //    }
                    //    else
                    //    {
                    //        cell.SetCellValue(dr[columnName].ToString());
                    //    }
                    //}
                    #endregion

                    rOffset++;
                }
                //将所有“行公式”转换成值单元
                HSSFFormulaEvaluator.EvaluateAllFormulaCells(sheet.Workbook);//
                //sheet.RemoveRow(sheet.GetRow(rowStart + rOffset));
                if (rowStart + rOffset + 1 <= sheet.LastRowNum)
                {
                    sheet.ShiftRows(rowStart + rOffset + 1, sheet.LastRowNum, -1);
                }
            }

            /// <summary>
            /// 将DataTable中指定的值全部写到指定的行列
            /// </summary>
            /// <param name="sheet">Excel中的一个Sheet对象</param>
            /// <param name="dt">数据集</param>
            /// <param name="rowStart">开始行</param>
            /// <param name="colStart">开始列</param>
            /// <param name="rownum">是否输出行号</param>
            public override int Write(ISheet sheet, int rowStart = 0, int colStart = 0, bool rownum = true)
            {
                init();//初始化操作
                AfterInit();//初始化之后的操作

                int rOffset = 0;
                int cOffset = 0;
                int length = AllFields.Count > 0 ? AllFields.Count + (rownum ? 1 : 0) : dt.Columns.Count;
                ICell cell;
                IRow row;

                foreach (DataRow dr in dt.Rows)
                {
                    //创建一行
                    if (rowStart + rOffset + 1 <= sheet.LastRowNum)
                    {
                        sheet.ShiftRows(rowStart + rOffset + 1, sheet.LastRowNum, 1);//下一行到最后一行，移动一行的距离
                    }
                    row = sheet.CreateRow(rowStart + rOffset + 1);//创建下一行供后面使用，写数据时仍使用当前行
                    for (int i = colStart; i < length + colStart; i++)
                    {
                        cell = row.CreateCell(colStart + i);
                        cell.CellStyle = sheet.GetRow(rowStart).GetCell(colStart + i).CellStyle;//上一行的Style
                    }

                    cOffset = colStart;    //initial

                    //写行号
                    if (rownum)
                    {
                        cell = sheet.GetRow(rowStart + rOffset).GetCell(cOffset++);
                        cell.SetCellValue(rOffset + 1);
                    }

                    //写一行数据
                    this.WriteToRow(sheet.GetRow(rowStart + rOffset), cOffset++, field => dr[field]);

                    rOffset++;
                }
                //将所有“行公式”转换成值单元
                HSSFFormulaEvaluator.EvaluateAllFormulaCells(sheet.Workbook);//
                sheet.RemoveRow(sheet.GetRow(rowStart + rOffset));
                if (rowStart + rOffset + 1 <= sheet.LastRowNum)
                {
                    sheet.ShiftRows(rowStart + rOffset + 1, sheet.LastRowNum, -1);
                }
                return rowStart + rOffset - 1;
            }

            public override List<string> GetDefaultFields()
            {
                List<string> list = new List<string>();
                foreach (DataColumn column in dt.Columns)
                {
                    list.Add(column.ColumnName.ToLower());
                }
                return list;
            }
        }

        /// <summary>
        /// 用于处理List的Excel输出配置。
        /// 注意：字段名大小敏感。
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        public class NPOIDataListHandler<T> : NPOIBaseHandler
        {
            protected List<T> list;

            public NPOIDataListHandler (){}

            public NPOIDataListHandler(List<T> list, List<String> fields = null, bool typeDetective = true)
            {
                this.list = list;
                this.TypeDetectable = typeDetective;
                if (fields != null)
                {
                    this.AllFields = fields;
                }
            }

            private void init()
            {
                if (AllFields.Count == 0)
                {
                    AllFields = GetDefaultFields();
                }
                //自动识别
                if (TypeDetectable)
                {
                    foreach (String field in AllFields)
                    {
                        Type type = typeof(T).GetProperty(field).PropertyType;
                        if (typeof(DateTime) == type || typeof(DateTime?) == type)
                        {
                            DateTimeFields.Add(field);
                        }
                        else if (NPOIUtil.NumberType(type))
                        {
                            DoubleFields.Add(field);
                        }
                    }
                }
            }

            public override int Write(ISheet sheet, int rowStart = 0, int colStart = 0, bool rownum = true)
            {

                init();//初始化操作
                AfterInit();//初始化之后的操作

                int rOffset = 0;
                int cOffset = 0;
                int length = AllFields.Count > 0 ? AllFields.Count + (rownum ? 1 : 0) : list.Count;
                ICell cell;
                IRow row;

                foreach (var model in list)
                {
                    //创建一行
                    if (rowStart + rOffset + 1 <= sheet.LastRowNum)
                    {
                        sheet.ShiftRows(rowStart + rOffset, sheet.LastRowNum, 1);//下一行到最后一行，移动一行的距离
                    }
                    row = sheet.CreateRow(rowStart + rOffset + 1);//创建下一行供后面使用，写数据时仍使用当前行
                    for (int i = colStart; i < length + colStart; i++)
                    {
                        cell = row.CreateCell(colStart + i);
                        cell.CellStyle = sheet.GetRow(rowStart - 1).GetCell(colStart + i).CellStyle;//上一行的Style
                    }

                    cOffset = colStart;    //initial

                    //写行号
                    if (rownum)
                    {
                        cell = sheet.GetRow(rowStart + rOffset).GetCell(cOffset++);
                        cell.SetCellValue(rOffset + 1);
                    }

                    //写一行数据
                    this.WriteToRow(sheet.GetRow(rowStart + rOffset + 1), cOffset++, field => model.GetType().GetProperty(field).GetValue(model, null));
                    rOffset++;

                    //无效,为什么？
                    //sheet.GetRow(rowStart + rOffset).HeightInPoints = sheet.GetRow(rowStart).HeightInPoints;//设置行高:HeigntInPoints是Excel能显示高度尺度
                }
                //将所有“行公式”转换成值单元
                HSSFFormulaEvaluator.EvaluateAllFormulaCells(sheet.Workbook);
                sheet.RemoveRow(sheet.GetRow(rowStart));
                //if (rowStart + rOffset + 1 <= sheet.LastRowNum)
                //{
                //    sheet.ShiftRows(rowStart + rOffset + 1, sheet.LastRowNum, -1);//sheet.RemoveRow(sheet.GetRow(rowStart + rOffset));
                //}
                return rowStart + rOffset - 1;
            }

            public int WriteSheet(ISheet sheet, List<T> list, List<string> AllFields, int rowStart = 0, int colStart = 0, bool rownum = true)
            {

                int rOffset = 0;
                int cOffset = 0;
                int length = AllFields.Count > 0 ? AllFields.Count + (rownum ? 1 : 0) : list.Count;
                ICell cell;
                IRow row;

                foreach (var model in list)
                {
                    //创建一行
                    if (rowStart + rOffset<= sheet.LastRowNum)
                    {
                        sheet.ShiftRows(rowStart + rOffset, sheet.LastRowNum, 1);//下一行到最后一行，移动一行的距离
                    }
                    row = sheet.CreateRow(rowStart + rOffset);//创建下一行供后面使用，写数据时仍使用当前行
                    for (int i = colStart; i < length + colStart; i++)
                    {
                        cell = row.CreateCell(colStart + i);
                        cell.CellStyle = sheet.GetRow(rowStart).GetCell(colStart + i).CellStyle;//上一行的Style
                    }

                    cOffset = colStart;    //initial

                    //写行号
                    if (rownum)
                    {
                        cell = sheet.GetRow(rowStart + rOffset).GetCell(cOffset++);
                        cell.SetCellValue(rOffset + 1);
                    }

                    //写一行数据
                    this.WriteToRow(sheet.GetRow(rowStart + rOffset), cOffset++, field => model.GetType().GetProperty(field).GetValue(model, null));
                    rOffset++;

                    //无效,为什么？
                    sheet.GetRow(rowStart + rOffset).HeightInPoints = sheet.GetRow(rowStart).HeightInPoints;//设置行高:HeigntInPoints是Excel能显示高度尺度
                }
                //将所有“行公式”转换成值单元
                HSSFFormulaEvaluator.EvaluateAllFormulaCells(sheet.Workbook);
                //sheet.RemoveRow(sheet.GetRow(rowStart));
                return rowStart + rOffset;
            }

            public override List<string> GetDefaultFields()
            {
                List<string> list = new List<string>();
                System.Reflection.PropertyInfo[] props = typeof(T).GetProperties();
                foreach (var prop in props)
                {
                    list.Add(prop.Name);
                }
                return list;
            }
        }
         
        /// <summary>
        /// 根据List的数据源返回实例
        /// </summary>
        /// <typeparam name="T">数据源泛型类型</typeparam>
        /// <param name="list">数据源</param>
        /// <param name="fields">所有输出字段，注意字段的名称和顺序，字段为泛型的属性名，大小写必须匹配且</param>
        /// <param name="typeDetective">是否自动检测输出字段类型，否则输出都是字符串</param>
        /// <returns></returns>
        public static NPOIDataListHandler<T> NewInstance<T>(List<T> list, List<String> fields = null, bool typeDetective = false)
        {
            return new NPOIDataListHandler<T>(list, fields, typeDetective);
        }

        /// <summary>
        /// 根据Datatable的数据源返回实例
        /// </summary>
        /// <param name="list">数据源</param>
        /// <param name="fields">所有输出字段</param>
        /// <param name="typeDetective">是否自动检测输出字段类型，否则输出都是字符串</param>
        /// <returns></returns>
        public static NPOIDataTableHandler NewInstance(DataTable dt, List<String> fields = null, bool typeDetective = false)
        {
            return new NPOIDataTableHandler(dt, fields, typeDetective);
        }

        //public static ISheet CreateSheet(string sheetname = null)
        //{
        //    HSSFWorkbook hssfworkbook = new HSSFWorkbook();
        //    ISheet sheet = hssfworkbook.CreateSheet(sheetname != null ? sheetname : "Sheet1");
        //    return sheet;
        //}

        //public static ISheet Write(ISheet sheet,NPOIBaseHandler hander, string title, int rowStart = 0, int colStart = 0, bool rownum = true, List<String> headers = null)
        //{
        //    IRow row = null;
        //    int rOffset = 0;
        //    if(headers == null){
        //        headers = hander.GetDefaultFields();
        //    }

        //    //Title
        //    if (false == string.IsNullOrEmpty(title))
        //    {
        //        SetRegionValue(title, sheet, rOffset++, 0, headers.Count);
        //    }
        //    //Header
        //    row = sheet.CreateRow(rOffset);
        //    ICellStyle style = sheet.Workbook.CreateCellStyle();
        //    style.Alignment = HorizontalAlignment.Center;
        //    style.VerticalAlignment = VerticalAlignment.Center;
        //    IFont font = sheet.Workbook.CreateFont();
        //    font.FontHeight = 18 * 18;
        //    font.Boldweight = 15 * 15;
        //    style.SetFont(font);
        //    style.FillBackgroundColor = HSSFColor.LIGHT_BLUE.index;

        //    SetHeaders(headers, row, colStart++, style);

        //    Create(sheet, colStart, 1, headers.Count, colStart);

        //    //Data
        //    hander.Write(sheet, rOffset, colStart, rownum);
        //    return sheet;
        //}

        //public static bool WriteToBrowser(ISheet sheet, string filename){
        //    if(HttpContext.Current != null && HttpContext.Current.Response != null){
        //        HttpResponse Response = HttpContext.Current.Response;
        //        Response.Clear();
        //        sheet.Workbook.Write(Response.OutputStream);
        //        Response.ContentType = "application/octet-stream";
        //        Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\";");
        //        return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// 将DataTable中的值按指定位置导出为Excel
        /// </summary>
        /// <param name="dt">DataTable数据集</param>
        /// <param name="templetePath">模板路径</param>
        /// <param name="filename">输出文件名</param>
        /// <param name="rowStart">(可选)起始行</param>
        /// <param name="colStart">(可选)起始列</param>
        /// <param name="rownum">(可选)是否列号</param>
        public static void ExportAsExcel(NPOIBaseHandler handler, string templetePath, string filename, int rowStart = 0, int colStart = 0, bool rownum = true)
        {
            if (HttpContext.Current != null && HttpContext.Current.Response != null)
            {
                HttpResponse Response = HttpContext.Current.Response;

                using (FileStream fs = new FileStream(templetePath, FileMode.Open, FileAccess.Read))
                {
                    HSSFWorkbook hssfworkbook = new HSSFWorkbook(fs);
                    ISheet sheet = hssfworkbook.GetSheetAt(0);

                    int rowEnd = handler.Write(sheet, rowStart, colStart, rownum);
                    handler.WriteColumnSum(sheet, rowStart, rowEnd, colStart, rownum);

                    //发送到前台
                    Response.Clear();
                    hssfworkbook.Write(Response.OutputStream);
                    Response.ContentType = "application/octet-stream";
                    Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置输出流为简体中文
                    Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\";");
                    fs.Close();
                }
            }
        }
        public static void SaveSheet(NPOIBaseHandler handler, ref  ISheet sheet, int rowStart = 0, int colStart = 0, bool rownum = true)
        {
            if (HttpContext.Current != null && HttpContext.Current.Response != null)
            {
                int rowEnd = handler.Write(sheet, rowStart, colStart, rownum);
                handler.WriteColumnSum(sheet, rowStart, rowEnd, colStart, rownum);
            }
        }

        public void SaveWeekSheet<T>(NPOIBaseHandler handler, ref  ISheet sheet, List<T> list, List<string> AllFields, int rowStart = 0, int colStart = 0, bool rownum = true)
        {
            if (HttpContext.Current != null && HttpContext.Current.Response != null)
            {
                NPOIDataListHandler<T> datalistHandler = new NPOIDataListHandler<T>();
                int rowEnd = datalistHandler.WriteSheet(sheet, list, AllFields,rowStart, colStart, rownum);
                
                handler.WriteColumnSum(sheet, rowStart, rowEnd, colStart, rownum);
            }
        }

        public static ICell GetCell(ISheet sheet, int rowIndex, int colIndex, bool createIfNull = true)
        {
            IRow row = sheet.GetRow(rowIndex);
            if (row == null)
            {
                if (createIfNull) { row = sheet.CreateRow(rowIndex); }
                else
                {
                    return null;
                }
            }
            ICell cell = row.GetCell(colIndex);
            if (cell == null)
            {
                if (createIfNull) { cell = row.CreateCell(colIndex); }
                else
                {
                    return null;
                }
            }
            return cell;
        }

        /// <summary>
        /// 合并单元格并给区域填值。
        /// </summary>
        /// <param name="value">单元格的值</param>
        /// <param name="cell">起始单元格</param>
        /// <param name="colStart"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static int SetRegionValue(object value, ISheet sheet, int rStart, int cStart, int columns, int rows = 1, bool isBlank = true)
        {
            if (isBlank)
            {
                Create(sheet, rStart, rows, columns, rStart);
            }
            return SetMergeRegion(sheet, rStart, rStart + rows - 1, columns, cStart + columns - 1, value);
        }

        /// <summary>
        /// 设置Header
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="row"></param>
        /// <param name="colStart"></param>
        /// <param name="style"></param>
        public static void SetHeaders(List<String> headers, IRow row, int colStart = 0, ICellStyle style = null)
        {
            ICell cell;
            for (int i = 0; i < headers.Count; i++)
            {
                cell = row.GetCell(colStart + i);
                if (cell == null) { cell = row.CreateCell(colStart + i); }
                cell.SetCellValue(headers[i]);
                cell.CellStyle = style;
            }
        }

        /// <summary>
        /// 给指定位置设置值或公式
        /// </summary>
        /// <param name="type">Cell类型：值类型、公式类型</param>
        /// <param name="value">Cell值</param>
        /// <param name="sheet">Excel的一个Sheet</param>
        /// <param name="rowIndex">行号</param>
        /// <param name="colIndex">列号</param>
        /// <returns></returns>
        public static bool SetCell(CellType type, object value, ISheet sheet, int rowIndex, int colIndex)
        {
            ICell cell = GetCell(sheet, rowIndex, colIndex, true);
            if (CellType.Formula.Equals(type))
            {
                cell.SetCellFormula(value.ToString());
                return true;
            }
            return SetCellValue(cell, value);
        }

        /// <summary>
        /// 从rowStart行开始,创建columns行row列的空间,完全复制来自styleFromRow行单元格的样式
        /// </summary>
        /// <param name="sheet">Excel的Sheet</param>
        /// <param name="rowStart">开始行</param>
        /// <param name="rows">行数</param>
        /// <param name="columns">列数</param>
        /// <param name="colStart">开始列</param>
        /// <param name="styleFromRow">样式来源列</param>
        public static void Create(ISheet sheet, int rowStart, int rows, int columns, int colStart = 0, int styleFromRow = -1)
        {
            ICell cell;
            IRow row;
            IRow styleRow = styleFromRow != -1 ? sheet.GetRow(styleFromRow) : null;
            for (int rOffset = 0; rOffset < rows; rOffset++)
            {
                row = sheet.CreateRow(rowStart + rOffset);
                for (int i = colStart; i < columns; i++)
                {
                    cell = row.CreateCell(colStart + i);
                    //复制Style
                    if (styleRow != null)
                    {
                        cell.CellStyle = styleRow.GetCell(colStart + i).CellStyle;//指定行的Style
                    }
                }
            }
        }

        /// <summary>
        /// 移除行：删除行空间和样式外
        /// </summary>
        /// <param name="sheet">Excel的一个Sheet对象</param>
        /// <param name="rowStart">开始行</param>
        /// <param name="rows">行数</param>
        public static void RemoveRow(ISheet sheet, int rowStart, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                sheet.RemoveRow(sheet.GetRow(rowStart + i));//删除样式和Cell
            }
            sheet.ShiftRows(rowStart + rows + 1, sheet.LastRowNum, rows);//移除空间
        }

        /// <summary>
        /// 给指定Cell设置值
        /// </summary>
        /// <param name="cell">Excel单元格</param>
        /// <param name="value">值对象</param>
        /// <returns></returns>
        public static bool SetCellValue(ICell cell, Object value)
        {
            if (cell != null && value != null)
            {
                if (value.GetType() == typeof(DateTime) || value.GetType() == typeof(DateTime?))
                {
                    cell.SetCellValue((DateTime)value);
                }
                else if (value.GetType() == typeof(Boolean) || value.GetType() == typeof(Boolean?))
                {
                    cell.SetCellValue((Boolean)value);
                }
                else if (value.GetType() == typeof(IRichTextString))
                {
                    cell.SetCellValue((Boolean)value);
                }
                else if (NPOIUtil.NumberType(value.GetType()))
                {
                    cell.SetCellValue(Double.Parse(value.ToString()));
                }
                else
                {
                    cell.SetCellValue(value.ToString());
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 设置指定Cell的值
        /// </summary>
        /// <param name="sheet">Excel的一个Sheet对象</param>
        /// <param name="rowIndex">行号</param>
        /// <param name="colIndex">列号</param>
        /// <param name="value">值对象</param>
        /// <returns></returns>
        public static bool SetCellValue(ISheet sheet, int rowIndex, int colIndex, Object value)
        {
            return SetCellValue(sheet.GetRow(rowIndex).Cells[colIndex], value);
        }

        /// <summary>
        /// 判断是否是数值类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool NumberType(Type type)
        {
            List<Type> NumberTypes = new List<Type>(new Type[] { 
                typeof(Int16), typeof(Int32), typeof(Int64), typeof(float), typeof(Double), typeof(Decimal),
                typeof(Int16?),typeof(Int32?),typeof(Int64?), typeof(float?), typeof(Double?), typeof(Decimal?)
            });
            return NumberTypes.Contains(type);
        }

        /// <summary>
        /// 设置合并区域，并设置值
        /// </summary>
        /// <param name="sheet">Excel的Sheet</param>
        /// <param name="rowStart">开始行</param>
        /// <param name="rowEnd">结束行</param>
        /// <param name="colStart">开始列</param>
        /// <param name="colEnd">结束列</param>
        /// <param name="obj">值对象</param>
        /// <returns>MergeRegion的索引</returns>
        public static int SetMergeRegion(ISheet sheet, int rowStart, int rowEnd, int colStart, int colEnd, Object obj = null)
        {
            try
            {
                int index = sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(rowStart, rowEnd, colStart, colEnd));

                if (obj != null)
                {
                    ICell cell = sheet.GetRow(rowStart).GetCell(colStart);
                    NPOIUtil.SetCellValue(cell, obj);
                }
                return index;
            }
            catch { return -1; }
        }
    }
}
