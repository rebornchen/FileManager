﻿namespace CL.FileManager.Win.Controls
{
    partial class UCFileListView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.skinLV = new CCWin.SkinControl.SkinListView();
            this.SuspendLayout();
            // 
            // skinLV
            // 
            this.skinLV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinLV.Location = new System.Drawing.Point(0, 0);
            this.skinLV.Name = "skinLV";
            this.skinLV.OwnerDraw = true;
            this.skinLV.Size = new System.Drawing.Size(400, 300);
            this.skinLV.TabIndex = 0;
            this.skinLV.UseCompatibleStateImageBehavior = false;
            this.skinLV.View = System.Windows.Forms.View.Tile;
            // 
            // UCFileListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinLV);
            this.Name = "UCFileListView";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinListView skinLV;
    }
}
