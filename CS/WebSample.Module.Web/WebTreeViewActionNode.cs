using DevExpress.ExpressApp.Actions;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp.Utils;

namespace WebSample.Module.Web {
    public class WebTreeViewActionNode : TreeNode {
        private SingleChoiceAction action;
        private ChoiceActionItem itemValue;
        public WebTreeViewActionNode(SingleChoiceAction action, ChoiceActionItem itemValue, TreeView owner)
            : base(owner, false) {
            this.action = action;
            this.itemValue = itemValue;
            if (itemValue != null) {
                this.Text = itemValue.Caption;
                this.ImageUrl = ImageLoader.Instance.GetImageInfo(itemValue.Info.GetAttributeValue(DevExpress.ExpressApp.NodeWrappers.VisualItemInfoNodeWrapper.ImageNameAttribute)).ImageUrl;
                this.SelectAction = TreeNodeSelectAction.Select;
            }
        }
        public void ExecuteAction() {
            action.DoExecute(itemValue);
        }
    }
}
