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
    public partial class FormTest : CCSkinMain
    {
        public FormTest()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup2", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("ttttt");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("eee");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("ddd");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("ADSas");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("fffff");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("zxcv");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("sdfs");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("dd");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("sadf");
            this.skinListView1 = new CCWin.SkinControl.SkinListView();
            this.SuspendLayout();
            // 
            // skinListView1
            // 
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "ListViewGroup2";
            listViewGroup2.Name = "listViewGroup2";
            this.skinListView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup1;
            listViewItem3.Group = listViewGroup1;
            listViewItem4.Group = listViewGroup1;
            listViewItem5.Group = listViewGroup1;
            listViewItem6.Group = listViewGroup2;
            listViewItem7.Group = listViewGroup2;
            listViewItem8.Group = listViewGroup2;
            listViewItem9.Group = listViewGroup2;
            this.skinListView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.skinListView1.Location = new System.Drawing.Point(48, 93);
            this.skinListView1.Name = "skinListView1";
            this.skinListView1.OwnerDraw = true;
            this.skinListView1.Size = new System.Drawing.Size(442, 175);
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
    }
}
