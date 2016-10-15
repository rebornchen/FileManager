namespace CL.AffSSNManage.DXWin.Views.Category
{
    partial class XUCCategory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvCategory = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.增加根节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加子节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvCategory
            // 
            this.tvCategory.ContextMenuStrip = this.contextMenuStrip1;
            this.tvCategory.LabelEdit = true;
            this.tvCategory.Location = new System.Drawing.Point(61, 30);
            this.tvCategory.Name = "tvCategory";
            this.tvCategory.Size = new System.Drawing.Size(197, 214);
            this.tvCategory.TabIndex = 0;
            this.tvCategory.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvCategory_AfterLabelEdit);
            this.tvCategory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvCategory_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加根节点ToolStripMenuItem,
            this.增加子节点ToolStripMenuItem,
            this.编辑ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 增加根节点ToolStripMenuItem
            // 
            this.增加根节点ToolStripMenuItem.Name = "增加根节点ToolStripMenuItem";
            this.增加根节点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.增加根节点ToolStripMenuItem.Text = "增加根节点";
            this.增加根节点ToolStripMenuItem.Click += new System.EventHandler(this.增加根节点ToolStripMenuItem_Click);
            // 
            // 增加子节点ToolStripMenuItem
            // 
            this.增加子节点ToolStripMenuItem.Name = "增加子节点ToolStripMenuItem";
            this.增加子节点ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.增加子节点ToolStripMenuItem.Text = "增加子节点";
            this.增加子节点ToolStripMenuItem.Click += new System.EventHandler(this.增加子节点ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // XUCCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvCategory);
            this.Name = "XUCCategory";
            this.Size = new System.Drawing.Size(506, 267);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvCategory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加根节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加子节点ToolStripMenuItem;


    }
}
