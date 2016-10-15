using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CL.BLL;

namespace CL.AffSSNManage.DXWin.Views.Category
{
    public partial class XUCCategory : DevExpress.XtraEditors.XtraUserControl
    {
        public class TreeViewEditEventArgs : EventArgs
        {
            /// <summary>
            /// 父节点Id
            /// </summary>
            public int ParentId { get; set; }
        }
        /// <summary>
        /// 触发保存到数据库的操作
        /// </summary>
        public event System.EventHandler SaveToDBEvent;

        public XUCCategory()
        {
            InitializeComponent();
            BindTreeData();
            this.SaveToDBEvent += XUCCategory_SaveToDBEvent;
        }

        void XUCCategory_SaveToDBEvent(object sender, EventArgs e)
        {
            TreeNode node = sender as TreeNode;
            if (node == null)
            {
                return;
            }
            CategoryBiz categoryBiz = new CategoryBiz();
            if (node.Tag == null)
            {
                categoryBiz.Add(
                    new Model.Category()
                    {
                        ICId = categoryBiz.GetMaxNextId(),
                        CCategoryName = node.Text,
                        CRemark = String.Empty,
                        IParentId = 0
                    });
            }
            else
            {
                //categoryBiz.(
                //    new Model.Category()
                //    {
                //        ICId = Convert.ToInt32(node.Tag),
                //        CCategoryName = node.Text,
                //        CRemark = String.Empty,
                //        IParentId = 0
                //    });

            }

        }

        public void BindTreeData()
        {
            //加载树形数据


        }


        private TreeNode mySelectedNode;
        /* Get the tree node under the mouse pointer and  
            save it in the mySelectedNode variable. */
        private void tvCategory_MouseDown(object sender,
          System.Windows.Forms.MouseEventArgs e)
        {
            mySelectedNode = tvCategory.GetNodeAt(e.X, e.Y);
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            if (mySelectedNode != null && mySelectedNode.Parent != null)
            {
                tvCategory.SelectedNode = mySelectedNode;
                tvCategory.LabelEdit = true;
                if (!mySelectedNode.IsEditing)
                {
                    mySelectedNode.BeginEdit();
                }
            }
            else
            {
                MessageBox.Show("No tree node selected or selected node is a root node.\n" +
                   "Editing of root nodes is not allowed.", "Invalid selection");
            }
        }

        private void tvCategory_AfterLabelEdit(object sender,
                 System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
                    {
                        // Stop editing without canceling the label change. 
                        e.Node.Text = e.Label;
                        e.Node.EndEdit(false);
                        //触发保存的事件
                        if (SaveToDBEvent != null)
                        {
                            SaveToDBEvent(e.Node, null);
                        }
                    }
                    else
                    {
                        /* Cancel the label edit action, inform the user, and  
                           place the node in edit mode again. */
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\n" +
                           "The invalid characters are: '@','.', ',', '!'",
                           "Node Label Edit");
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    /* Cancel the label edit action, inform the user, and  
                       place the node in edit mode again. */
                    e.CancelEdit = true;
                    MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
                       "Node Label Edit");
                    e.Node.BeginEdit();
                }
            }
        }

        private void 增加根节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode root = new TreeNode();
            tvCategory.Nodes.Add(root);
            this.mySelectedNode = root;
            root.BeginEdit();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (mySelectedNode == null)
            {
                编辑ToolStripMenuItem.Enabled = false;
                增加子节点ToolStripMenuItem.Enabled = false;
            }
            else
            {
                编辑ToolStripMenuItem.Enabled = true;
                增加子节点ToolStripMenuItem.Enabled = true;
            }
        }

        private void 增加子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode();
            mySelectedNode.Nodes.Add(node);
            mySelectedNode.Expand();

            node.BeginEdit();
            mySelectedNode = node;

        }

    }
}
