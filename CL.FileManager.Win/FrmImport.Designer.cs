namespace CL.FileManager.Win
{
    partial class FrmImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDirectory = new CCWin.SkinControl.SkinTextBox();
            this.lblDirectory = new CCWin.SkinControl.SkinLabel();
            this.btnImport = new CCWin.SkinControl.SkinButton();
            this.btnOK = new CCWin.SkinControl.SkinButton();
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.skinProgressBar1 = new CCWin.SkinControl.SkinProgressBar();
            this.lblImportInfo = new CCWin.SkinControl.SkinLabel();
            this.lblVal = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // txtDirectory
            // 
            this.txtDirectory.BackColor = System.Drawing.Color.Transparent;
            this.txtDirectory.DownBack = null;
            this.txtDirectory.Icon = null;
            this.txtDirectory.IconIsButton = false;
            this.txtDirectory.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtDirectory.IsPasswordChat = '\0';
            this.txtDirectory.IsSystemPasswordChar = false;
            this.txtDirectory.Lines = new string[0];
            this.txtDirectory.Location = new System.Drawing.Point(107, 51);
            this.txtDirectory.Margin = new System.Windows.Forms.Padding(0);
            this.txtDirectory.MaxLength = 32767;
            this.txtDirectory.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtDirectory.MouseBack = null;
            this.txtDirectory.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtDirectory.Multiline = false;
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.NormlBack = null;
            this.txtDirectory.Padding = new System.Windows.Forms.Padding(5);
            this.txtDirectory.ReadOnly = false;
            this.txtDirectory.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDirectory.Size = new System.Drawing.Size(359, 28);
            // 
            // 
            // 
            this.txtDirectory.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDirectory.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDirectory.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtDirectory.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtDirectory.SkinTxt.Name = "BaseText";
            this.txtDirectory.SkinTxt.Size = new System.Drawing.Size(349, 18);
            this.txtDirectory.SkinTxt.TabIndex = 0;
            this.txtDirectory.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtDirectory.SkinTxt.WaterText = "";
            this.txtDirectory.TabIndex = 1;
            this.txtDirectory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDirectory.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtDirectory.WaterText = "";
            this.txtDirectory.WordWrap = true;
            this.txtDirectory.Click += new System.EventHandler(this.txtDirectory_Click);
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.BackColor = System.Drawing.Color.Transparent;
            this.lblDirectory.BorderColor = System.Drawing.Color.White;
            this.lblDirectory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDirectory.Location = new System.Drawing.Point(35, 58);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(64, 17);
            this.lblDirectory.TabIndex = 2;
            this.lblDirectory.Text = "Directory:";
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnImport.DownBack = null;
            this.btnImport.Location = new System.Drawing.Point(479, 56);
            this.btnImport.MouseBack = null;
            this.btnImport.Name = "btnImport";
            this.btnImport.NormlBack = null;
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.DownBack = null;
            this.btnOK.Location = new System.Drawing.Point(377, 177);
            this.btnOK.MouseBack = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DownBack = null;
            this.btnCancel.Location = new System.Drawing.Point(479, 177);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // skinProgressBar1
            // 
            this.skinProgressBar1.Back = null;
            this.skinProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.skinProgressBar1.BarBack = null;
            this.skinProgressBar1.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinProgressBar1.ForeColor = System.Drawing.Color.Red;
            this.skinProgressBar1.Location = new System.Drawing.Point(38, 112);
            this.skinProgressBar1.Name = "skinProgressBar1";
            this.skinProgressBar1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinProgressBar1.Size = new System.Drawing.Size(516, 23);
            this.skinProgressBar1.TabIndex = 6;
            // 
            // lblImportInfo
            // 
            this.lblImportInfo.AutoSize = true;
            this.lblImportInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblImportInfo.BorderColor = System.Drawing.Color.White;
            this.lblImportInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportInfo.Location = new System.Drawing.Point(35, 138);
            this.lblImportInfo.Name = "lblImportInfo";
            this.lblImportInfo.Size = new System.Drawing.Size(0, 17);
            this.lblImportInfo.TabIndex = 7;
            // 
            // lblVal
            // 
            this.lblVal.AutoSize = true;
            this.lblVal.BackColor = System.Drawing.Color.Transparent;
            this.lblVal.BorderColor = System.Drawing.Color.White;
            this.lblVal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVal.ForeColor = System.Drawing.Color.Red;
            this.lblVal.Location = new System.Drawing.Point(107, 85);
            this.lblVal.Name = "lblVal";
            this.lblVal.Size = new System.Drawing.Size(0, 17);
            this.lblVal.TabIndex = 8;
            // 
            // FrmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 222);
            this.Controls.Add(this.lblVal);
            this.Controls.Add(this.lblImportInfo);
            this.Controls.Add(this.skinProgressBar1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Name = "FrmImport";
            this.Text = "Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private CCWin.SkinControl.SkinTextBox txtDirectory;
        private CCWin.SkinControl.SkinLabel lblDirectory;
        private CCWin.SkinControl.SkinButton btnImport;
        private CCWin.SkinControl.SkinButton btnOK;
        private CCWin.SkinControl.SkinButton btnCancel;
        private CCWin.SkinControl.SkinProgressBar skinProgressBar1;
        private CCWin.SkinControl.SkinLabel lblImportInfo;
        private CCWin.SkinControl.SkinLabel lblVal;
    }
}