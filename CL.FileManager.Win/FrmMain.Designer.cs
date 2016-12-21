namespace CL.FileManager.Win
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.skinMenuStrip1 = new CCWin.SkinControl.SkinMenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件检查ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinPnlBottom = new CCWin.SkinControl.SkinPanel();
            this.skinPnlCategory = new Win.Controls.ControlCategoryWithDel();
            this.skinPnlContent = new CCWin.SkinControl.SkinPanel();
            this.lblMessage = new CCWin.SkinControl.SkinLabel();
            this.skinSplitContainerMain = new CCWin.SkinControl.SkinSplitContainer();
            this.controlCategory1 = new CL.FileManager.Win.Controls.ControlCategory();
            this.ucFileListView = new Win.Controls.UCFileListView();


            this.skinMenuStrip1.SuspendLayout();
            this.skinPnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinSplitContainerMain)).BeginInit();
            this.skinSplitContainerMain.Panel1.SuspendLayout();
            this.skinSplitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinMenuStrip1
            // 
            this.skinMenuStrip1.Arrow = System.Drawing.Color.Black;
            this.skinMenuStrip1.Back = System.Drawing.Color.White;
            this.skinMenuStrip1.BackRadius = 4;
            this.skinMenuStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinMenuStrip1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinMenuStrip1.BaseFore = System.Drawing.Color.Black;
            this.skinMenuStrip1.BaseForeAnamorphosis = false;
            this.skinMenuStrip1.BaseForeAnamorphosisBorder = 4;
            this.skinMenuStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinMenuStrip1.BaseHoverFore = System.Drawing.Color.White;
            this.skinMenuStrip1.BaseItemAnamorphosis = true;
            this.skinMenuStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.BaseItemBorderShow = true;
            this.skinMenuStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinMenuStrip1.BaseItemDown")));
            this.skinMenuStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinMenuStrip1.BaseItemMouse")));
            this.skinMenuStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.BaseItemRadius = 4;
            this.skinMenuStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinMenuStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinMenuStrip1.Fore = System.Drawing.Color.Black;
            this.skinMenuStrip1.HoverFore = System.Drawing.Color.White;
            this.skinMenuStrip1.ItemAnamorphosis = true;
            this.skinMenuStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.ItemBorderShow = true;
            this.skinMenuStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.ItemRadius = 4;
            this.skinMenuStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.操作ToolStripMenuItem});
            this.skinMenuStrip1.Location = new System.Drawing.Point(4, 28);
            this.skinMenuStrip1.Name = "skinMenuStrip1";
            this.skinMenuStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinMenuStrip1.Size = new System.Drawing.Size(736, 25);
            this.skinMenuStrip1.SkinAllColor = true;
            this.skinMenuStrip1.TabIndex = 0;
            this.skinMenuStrip1.Text = "skinMenuStrip1";
            this.skinMenuStrip1.TitleAnamorphosis = true;
            this.skinMenuStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinMenuStrip1.TitleRadius = 4;
            this.skinMenuStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.FileToolStripMenuItem.Text = "文件";
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.导入ToolStripMenuItem.Text = "导入";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CategoryToolStripMenuItem,
            this.设置路径ToolStripMenuItem});
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.SettingsToolStripMenuItem.Text = "设置";
            // 
            // CategoryToolStripMenuItem
            // 
            this.CategoryToolStripMenuItem.Name = "CategoryToolStripMenuItem";
            this.CategoryToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.CategoryToolStripMenuItem.Text = "类型设置";
            this.CategoryToolStripMenuItem.Click += new System.EventHandler(this.CategoryToolStripMenuItem_Click);
            // 
            // 设置路径ToolStripMenuItem
            // 
            this.设置路径ToolStripMenuItem.Name = "设置路径ToolStripMenuItem";
            this.设置路径ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设置路径ToolStripMenuItem.Text = "设置路径";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件检查ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // 文件检查ToolStripMenuItem
            // 
            this.文件检查ToolStripMenuItem.Name = "文件检查ToolStripMenuItem";
            this.文件检查ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.文件检查ToolStripMenuItem.Text = "文件检查";
            // 
            // skinPnlBottom
            // 
            this.skinPnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.skinPnlBottom.Controls.Add(this.lblMessage);
            this.skinPnlBottom.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPnlBottom.DownBack = null;
            this.skinPnlBottom.Location = new System.Drawing.Point(4, 420);
            this.skinPnlBottom.MouseBack = null;
            this.skinPnlBottom.Name = "skinPnlBottom";
            this.skinPnlBottom.NormlBack = null;
            this.skinPnlBottom.Size = new System.Drawing.Size(736, 30);
            this.skinPnlBottom.TabIndex = 2;
            // 
            // ucFileListView
            // 
            this.ucFileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFileListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            
            // 
            // skinPnlCategory
            // 
            //this.skinPnlCategory.BackColor = System.Drawing.Color.Transparent;
            this.skinPnlCategory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinPnlCategory.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPnlCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPnlCategory.DownBack = null;
            //this.skinPnlCategory.Location = new System.Drawing.Point(4, 420);
            this.skinPnlCategory.MouseBack = null;
            this.skinPnlCategory.Name = "skinPnlCategory";
            this.skinPnlCategory.NormlBack = null;
            //this.skinPnlCategory.TabIndex = 2;
            // 
            // skinPnlContent
            // 
            //this.skinPnlContent.BackColor = System.Drawing.Color.Transparent;
            this.skinPnlContent.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.skinPnlContent.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPnlContent.DownBack = null;
            this.skinPnlContent.MouseBack = null;
            this.skinPnlContent.Name = "skinPnlContent";
            this.skinPnlContent.NormlBack = null;
            this.skinPnlContent.Controls.Add(this.ucFileListView);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.BorderColor = System.Drawing.Color.White;
            this.lblMessage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMessage.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblMessage.Location = new System.Drawing.Point(3, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 0;

            // 
            // skinSplitContainerMain
            // 
            this.skinSplitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainerMain.Location = new System.Drawing.Point(4, 53);
            this.skinSplitContainerMain.Name = "skinSplitContainerMain";
            // 
            // skinSplitContainerMain.Panel1
            // 
            this.skinSplitContainerMain.Panel1.Controls.Add(this.controlCategory1);
            this.skinSplitContainerMain.Size = new System.Drawing.Size(736, 367);
            this.skinSplitContainerMain.SplitterDistance = 243;
            this.skinSplitContainerMain.TabIndex = 3;
            // 
            // skinSplitContainerMain.Panel2
            // 
            this.skinSplitContainerMain.Panel2.Controls.Add(this.skinPnlContent);
            this.skinSplitContainerMain.Panel2.Controls.Add(this.skinPnlCategory);
            this.skinSplitContainerMain.TabIndex = 4;
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
            this.controlCategory1.Size = new System.Drawing.Size(243, 367);
            this.controlCategory1.TabIndex = 0;
            this.controlCategory1.OnCategroyButtonClick += new System.EventHandler(this.controlCategory1_OnCategroyButtonClick);
            
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 454);
            this.Controls.Add(this.skinSplitContainerMain);
            this.Controls.Add(this.skinPnlBottom);
            this.Controls.Add(this.skinMenuStrip1);
            this.MainMenuStrip = this.skinMenuStrip1;
            this.Name = "FrmMain";
            this.Text = "文件管理";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
            this.skinMenuStrip1.ResumeLayout(false);
            this.skinMenuStrip1.PerformLayout();
            this.skinPnlBottom.ResumeLayout(false);
            this.skinPnlBottom.PerformLayout();
            this.skinSplitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinSplitContainerMain)).EndInit();
            this.skinSplitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinMenuStrip skinMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private CCWin.SkinControl.SkinPanel skinPnlBottom;
        private CCWin.SkinControl.SkinSplitContainer skinSplitContainerMain;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CategoryToolStripMenuItem;
        private Controls.ControlCategory controlCategory1;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件检查ToolStripMenuItem;
        private CCWin.SkinControl.SkinLabel lblMessage;
        private Controls.ControlCategoryWithDel skinPnlCategory;
        private CCWin.SkinControl.SkinPanel skinPnlContent;
        private Controls.UCFileListView ucFileListView;
    }
}

