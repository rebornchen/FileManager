namespace CL.FileManager.Win
{
    partial class FrmAddFilesCategory
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
            this.skinSplitContainer1 = new CCWin.SkinControl.SkinSplitContainer();
            this.controlFileList1 = new CL.FileManager.Win.Controls.ControlFileList();
            this.controlCategory1 = new CL.FileManager.Win.Controls.ControlCategory();
            ((System.ComponentModel.ISupportInitialize)(this.skinSplitContainer1)).BeginInit();
            this.skinSplitContainer1.Panel1.SuspendLayout();
            this.skinSplitContainer1.Panel2.SuspendLayout();
            this.skinSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.Location = new System.Drawing.Point(4, 28);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            this.skinSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.controlFileList1);
            // 
            // skinSplitContainer1.Panel2
            // 
            this.skinSplitContainer1.Panel2.Controls.Add(this.controlCategory1);
            this.skinSplitContainer1.Size = new System.Drawing.Size(542, 301);
            this.skinSplitContainer1.SplitterDistance = 135;
            this.skinSplitContainer1.TabIndex = 0;
            // 
            // controlFileList1
            // 
            this.controlFileList1.Back = null;
            this.controlFileList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlFileList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.controlFileList1.FormattingEnabled = true;
            this.controlFileList1.Location = new System.Drawing.Point(0, 0);
            this.controlFileList1.Name = "controlFileList1";
            this.controlFileList1.Size = new System.Drawing.Size(542, 135);
            this.controlFileList1.TabIndex = 0;
            // 
            // controlCategory1
            // 
            this.controlCategory1.BackColor = System.Drawing.Color.Transparent;
            this.controlCategory1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.controlCategory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlCategory1.DownBack = null;
            this.controlCategory1.Location = new System.Drawing.Point(0, 0);
            this.controlCategory1.MouseBack = null;
            this.controlCategory1.Name = "controlCategory1";
            this.controlCategory1.NormlBack = null;
            this.controlCategory1.Size = new System.Drawing.Size(542, 162);
            this.controlCategory1.TabIndex = 0;
            this.controlCategory1.OnCategroyButtonClick += new System.EventHandler(this.controlCategory1_OnCategroyButtonClick);
            // 
            // FrmAddFilesCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 333);
            this.Controls.Add(this.skinSplitContainer1);
            this.Name = "FrmAddFilesCategory";
            this.Text = "添加文件类型";
            this.skinSplitContainer1.Panel1.ResumeLayout(false);
            this.skinSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinSplitContainer1)).EndInit();
            this.skinSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinSplitContainer skinSplitContainer1;
        private Controls.ControlFileList controlFileList1;
        private Controls.ControlCategory controlCategory1;
    }
}