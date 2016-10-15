using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CL.Common.Print
{
    #region Enums
    public enum TYPE : int { UNSPECIFIED, UPCA, UPCE, UPC_SUPPLEMENTAL_2DIGIT, UPC_SUPPLEMENTAL_5DIGIT, EAN13, EAN8, Interleaved2of5, Standard2of5, Industrial2of5, CODE39, CODE39Extended, Codabar, PostNet, BOOKLAND, ISBN, JAN13, MSI_Mod10, MSI_2Mod10, MSI_Mod11, MSI_Mod11_Mod10, Modified_Plessey, CODE11, USD8, UCC12, UCC13, LOGMARS, CODE128, CODE128A, CODE128B, CODE128C, ITF14, CODE93 };
    public enum SaveTypes : int { JPG, BMP, PNG, GIF, TIFF, UNSPECIFIED };
    #endregion
    /// <summary>
    /// This class was designed to give developers and easy way to generate a barcode image from a string of data.
    /// </summary>
    public class Barcode
    {
        #region Variables
        private string Raw_Data = "";
        private string Formatted_Data = "";
        private string Encoded_Value = "";
        private string _Country_Assigning_Manufacturer_Code = "N/A";
        private TYPE Encoded_Type = TYPE.UNSPECIFIED;
        private Image Encoded_Image = null;
        private Color _ForeColor = Color.Black;
        private Color _BackColor = Color.White;
        private int _Width = 300;
        private int _Height = 150;
        private bool bEncoded = false;
        private string archAdd;
        private string showTextButtom;
        private string showTextTop;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.  Does not populate the raw data.  MUST be done via the RawData property before encoding.
        /// </summary>
        public Barcode()
        {
            //constructor
        }//Barcode
        /// <summary>
        /// Constructor. Populates the raw data. No whitespace will be added before or after the barcode.
        /// </summary>
        /// <param name="data">String to be encoded.</param>
        public Barcode(string data)
        {
            //constructor
            this.Raw_Data = data;
        }//Barcode
        public Barcode(string data, TYPE iType)
        {
            this.Raw_Data = data;
            this.Encoded_Type = iType;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the formatted data.
        /// </summary>
        public string FormattedData
        {
            get { return Formatted_Data; }
        }//FormattedData
        /// <summary>
        /// Gets or sets the raw data to encode.
        /// </summary>
        public string RawData
        {
            get { return Raw_Data; }
            set { Raw_Data = value; bEncoded = false; }
        }//RawData
        /// <summary>
        /// Gets the encoded value.
        /// </summary>
        public string EncodedValue
        {
            get { return Encoded_Value; }
        }//EncodedValue

        /// <summary>
        /// Gets or sets the Encoded Type (ex. UPC-A, EAN-13 ... etc)
        /// </summary>
        public TYPE EncodedType
        {
            set { Encoded_Type = value; }
            get { return Encoded_Type; }
        }//EncodedType
        /// <summary>
        /// Gets the Image of the generated barcode.
        /// </summary>
        public Image EncodedImage
        {
            get { if (bEncoded) return Encoded_Image; else return null; }
        }//EncodedImage
        /// <summary>
        /// Gets or sets the color of the bars. (Default is black)
        /// </summary>
        public Color ForeColor
        {
            get { return this._ForeColor; }
            set { this._ForeColor = value; }
        }//ForeColor
        /// <summary>
        /// Gets or sets the background color. (Default is white)
        /// </summary>
        public Color BackColor
        {
            get { return this._BackColor; }
            set { this._BackColor = value; }
        }//BackColor
        /// <summary>
        /// Gets or sets the width of the image to be drawn. (Default is 300 pixels)
        /// </summary>
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        /// <summary>
        /// Gets or sets the height of the image to be drawn. (Default is 150 pixels)
        /// </summary>
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public string ArchAdd
        {
            get { return archAdd; }
            set { archAdd = value; }
        }

        public string ShowTextButtom
        {
            get { return showTextButtom; }
            set { showTextButtom = value; }
        }

        public string ShowTextTop
        {
            get { return showTextTop; }
            set { showTextTop = value; }
        }
        #endregion

        #region General Encode

        public Image Encode(string StringToEncode, string archAddress)
        {
            this.Width = 435;
            this.Height = 65;
            this.Encoded_Type = TYPE.CODE39;
            this.ForeColor = Color.Black;
            this.BackColor = Color.White;

            this.ShowTextButtom = StringToEncode;
            this.ArchAdd = archAddress;
            this.Raw_Data = StringToEncode.Substring(0, StringToEncode.LastIndexOf("("));
            this.ShowTextTop = string.Format("总登记号:{0}", GetNum(StringToEncode));
            return Encode();
        }

        private string GetNum(string strEncode)
        {
            //对于31007-k1111-00001-001的编号，需要返回00001回去，也就是倒数第二节的内容
            string str = strEncode.Substring(0, strEncode.LastIndexOf("-"));
            return str.Substring(str.LastIndexOf("-") + 1);
        }
        private Image Encode()
        {
            if (Raw_Data.Trim() == "")
                throw new Exception("EENCODE-1: Input data not allowed to be blank.");

            if (this.EncodedType == TYPE.UNSPECIFIED)
                throw new Exception("EENCODE-2: Symbology type not allowed to be unspecified.");

            this.Encoded_Value = "";
            IBarcode ibarcode;

            ibarcode = new Code39(Raw_Data);
            this.Encoded_Value = ibarcode.Encoded_Value;
            this.Raw_Data = ibarcode.RawData;
            this.Formatted_Data = ibarcode.FormattedData;

            return (Image)Generate_Image();
        }//Encode
        #endregion

        #region Image Functions

        private Bitmap Generate_Image()
        {
            if (Encoded_Value == "") throw new Exception("EGENERATE_IMAGE-1: Must be encoded first.");
            Bitmap b = null;


            b = new Bitmap(Width, Height);

            int iBarWidth = Width / Encoded_Value.Length;
            int shiftAdjustment = (Width % Encoded_Value.Length) / 2;//算出图上离左右的距离
            shiftAdjustment = 5;
            iBarWidth = 1;

            if (iBarWidth <= 0)
                throw new Exception("EGENERATE_IMAGE-2: Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel)");

            //draw image
            int pos = 0;

            using (Graphics g = Graphics.FromImage(b))
            {
                //clears the image and colors the entire background
                g.Clear(BackColor);

                //lines are fBarWidth wide so draw the appropriate color line vertically
                Pen pen = new Pen(ForeColor, iBarWidth);
                pen.Alignment = PenAlignment.Right;

                while (pos < Encoded_Value.Length)
                {
                    if (Encoded_Value[pos] == '1')
                        g.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment, 0), new Point(pos * iBarWidth + shiftAdjustment, Height));

                    pos++;
                }//while
            }//using
            Label_Generic((Image)b);


            Encoded_Image = (Image)b;
            bEncoded = true;

            return b;
        }//Generate_Image

        private Image Label_Generic(Image img)
        {
            try
            {
                System.Drawing.Font font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

                using (Graphics g = Graphics.FromImage(img))
                {
                    g.DrawImage(img, (float)0, (float)0);

                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;

                    //color a background color box at the bottom of the barcode to hold the string of data
                    g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(0, img.Height - 16, img.Width, 16));
                    g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(0, 0, img.Width, 16));

                    //draw datastring under the barcode image
                    StringFormat f = new StringFormat();
                    f.Alignment = StringAlignment.Near;

                    string strLabelText = (this.FormattedData.Trim() != "") ? this.FormattedData : this.RawData;

                    g.DrawString(ShowTextButtom, font, new SolidBrush(this.ForeColor), (float)(Encoded_Value.Length / 2) + 5, img.Height - 16, f);//buttom

                    Font font3 = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                    g.DrawString(ShowTextTop, font3, new SolidBrush(this.ForeColor), (float)(Encoded_Value.Length / 2) + 5, 0, f);//top



                    System.Drawing.Font font1 = new Font("微软雅黑", 16, FontStyle.Regular);
                    StringFormat f1 = new StringFormat();
                    f1.Alignment = StringAlignment.Near;
                    int fontHeight = (int)g.MeasureString("档案资料中心", font1).Height;
                    int fontWidth = (int)g.MeasureString("档案资料中心", font1).Width;
                    float strHeight = (this.Height - 32 - fontHeight) / 2;


                    //g.DrawString("档案资料中心", font1, new SolidBrush(this.ForeColor), Encoded_Value.Length + 5, 16 + strHeight, f1);




                    //g.Transform = null;


                    StringFormat f2 = new StringFormat();
                    f2.Alignment = StringAlignment.Near;
                    g.DrawString(ArchAdd, font, new SolidBrush(this.ForeColor), Encoded_Value.Length + 5 + (fontWidth / 4), img.Height - 16, f2);//buttom

                    Matrix matrix = new Matrix();
                    matrix.Scale(0.5f, 1);
                    g.Transform = matrix;

                    //缩放过后，绘制的坐标也会减小一半，所以应该*2
                    g.DrawString("档案资料中心", font1, new SolidBrush(this.ForeColor), (Encoded_Value.Length + 5) * 2, 16 + strHeight, f1);

                    g.Save();
                }//using
                return img;
            }//try
            catch (Exception ex)
            {
                throw new Exception("ELABEL_GENERIC-1: " + ex.Message);
            }//catch
        }//Label_Generic

        #endregion

        #region Misc
        public static bool CheckNumericOnly(string Data)
        {
            //This function takes a string of data and breaks it into parts and trys to do Int64.TryParse
            //This will verify that only numeric data is contained in the string passed in.  The complexity below
            //was done to ensure that the minimum number of interations and checks could be performed.

            //9223372036854775808 is the largest number a 64bit number(signed) can hold so ... make sure its less than that by one place
            int STRING_LENGTHS = 18;

            string temp = Data;
            string[] strings = new string[(Data.Length / STRING_LENGTHS) + ((Data.Length % STRING_LENGTHS == 0) ? 0 : 1)];

            int i = 0;
            while (i < strings.Length)
                if (temp.Length >= STRING_LENGTHS)
                {
                    strings[i++] = temp.Substring(0, STRING_LENGTHS);
                    temp = temp.Substring(STRING_LENGTHS);
                }//if
                else
                    strings[i++] = temp.Substring(0);

            foreach (string s in strings)
            {
                long value = 0;
                if (!Int64.TryParse(s, out value))
                    return false;
            }//foreach

            return true;
        }//CheckNumericOnly
        #endregion
    }//Barcode Class
}
