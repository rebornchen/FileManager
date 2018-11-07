using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CL.FileManager.Win
{
    public partial class FormTest : CCWin.CCSkinMain
    {
        public FormTest()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("qqqqq");
            this.skinListView1 = new CCWin.SkinControl.SkinListView();
            this.SuspendLayout();
            // 
            // skinListView1
            // 
            this.skinListView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.skinListView1.Location = new System.Drawing.Point(105, 91);
            this.skinListView1.Name = "skinListView1";
            this.skinListView1.OwnerDraw = true;
            this.skinListView1.Size = new System.Drawing.Size(352, 190);
            this.skinListView1.TabIndex = 0;
            this.skinListView1.UseCompatibleStateImageBehavior = false;
            // 
            // FormTest
            // 
            this.ClientSize = new System.Drawing.Size(553, 339);
            this.Controls.Add(this.skinListView1);
            this.Name = "FormTest";
            this.ResumeLayout(false);

        }

        private void LoadItems()
        {
            ListViewItem item = new ListViewItem();
            //item.
        }

    }
}
