using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp.Actions;

namespace WebSample.Module.Web {
    public class MyTreeView : TreeView, ITemplate {
        SingleChoiceAction action;
        public MyTreeView(ChoiceActionItemCollection items, SingleChoiceAction action, TreeNode[] nodes) {
            Nodes.Clear();
            this.action = action;
            if (nodes != null) {
                foreach (TreeNode node in nodes) {
                    Nodes.Add(node);
                }
            }
            else {
                CreateNodes(items, Nodes);
            }
            this.SelectedNodeChanged += new EventHandler(WebTreeListActionContainer_SelectedNodeChanged);
        }

        void WebTreeListActionContainer_SelectedNodeChanged(object sender, EventArgs e) {
            if (SelectedNode is WebTreeViewActionNode) {
                (SelectedNode as WebTreeViewActionNode).ExecuteAction();
            }
        }
        private void CreateNodes(ChoiceActionItemCollection items, TreeNodeCollection nodes) {
            foreach (ChoiceActionItem item in items) {
                WebTreeViewActionNode node = new WebTreeViewActionNode(action, item, this);
                nodes.Add(node);
                CreateNodes(item.Items, node.ChildNodes);
            }
        }
        #region ITemplate Members
        public void InstantiateIn(Control container) {
            container.Controls.Add(this);
        }
        #endregion
    }
}
