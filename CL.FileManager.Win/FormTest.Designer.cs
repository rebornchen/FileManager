namespace CL.FileManager.Win
{
    partial class FormTest
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
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.buttonWithDel1 = new CL.FileManager.Win.Controls.ButtonWithDel();
            this.SuspendLayout();
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.BaseColor = System.Drawing.Color.Transparent;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.Image = global::CL.FileManager.Win.Properties.Resources.icon_del1;
            this.skinButton1.IsDrawBorder = false;
            this.skinButton1.Location = new System.Drawing.Point(63, 140);
            this.skinButton1.MouseBack = null;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Size = new System.Drawing.Size(20, 20);
            this.skinButton1.TabIndex = 0;
            this.skinButton1.UseVisualStyleBackColor = false;
            // 
            // buttonWithDel1
            // 
            this.buttonWithDel1.BackColor = System.Drawing.Color.Transparent;
            this.buttonWithDel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.buttonWithDel1.DownBack = null;
            this.buttonWithDel1.Location = new System.Drawing.Point(24, 74);
            this.buttonWithDel1.MouseBack = null;
            this.buttonWithDel1.Name = "buttonWithDel1";
            this.buttonWithDel1.NormlBack = null;
            this.buttonWithDel1.ShowDelete = true;
            this.buttonWithDel1.Size = new System.Drawing.Size(200, 23);
            this.buttonWithDel1.TabIndex = 1;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonWithDel1);
            this.Controls.Add(this.skinButton1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton skinButton1;
        private Controls.ButtonWithDel buttonWithDel1;
    }
}