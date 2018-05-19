using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;
using DevExpress.Web.ASPxNavBar;
using DevExpress.ExpressApp.SystemModule;
using System.Web.UI.WebControls;

namespace WebSample.Module.Web{
    public partial class NavBarViewChangingController : WindowController {
        public NavBarViewChangingController() {
            InitializeComponent();
            RegisterActions(components);
        }
        protected override void OnActivated() {
            base.OnActivated();
            Window.TemplateChanged += new EventHandler(Window_TemplateChanged);
        }
        void Window_TemplateChanged(object sender, EventArgs e) {
            NavigationBarActionContainer navBarControl = FindNavBarControl();
            if (navBarControl != null) {
                ConfigureNavBar(navBarControl);
            }
        }
        private NavigationBarActionContainer FindNavBarControl() {
            if (Window.Template != null && Window.IsMain) {
                foreach (object actionContainer in Window.Template.GetContainers()) {
                    if (actionContainer is NavigationBarActionContainer) {
                        return (NavigationBarActionContainer)actionContainer;
                    }
                }
            }
            return null;
        }
        TreeNode[] nodes;
        private void ConfigureNavBar(NavigationBarActionContainer navBarControl) {
            navBarControl.BeginUpdate();
            try {
                NavBarGroup navGroup = navBarControl.Groups.FindByText("Data");
                MyTreeView treeView = new MyTreeView(singleChoiceAction1.Items, singleChoiceAction1, nodes);
                nodes = new TreeNode[treeView.Nodes.Count];
                treeView.Nodes.CopyTo(nodes, 0);
                navGroup.ContentTemplate = treeView;
            }
            finally {
                navBarControl.EndUpdate();
            }
        }
        void singleChoiceAction1_Execute(object sender, DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventArgs e) {
            if (e.SelectedChoiceActionItem.Data != null) {
                Type objectType = ReflectionHelper.FindType(e.SelectedChoiceActionItem.Data.ToString());
                string viewID = Application.GetListViewId(objectType);
                CollectionSourceBase collectionSource = Application.CreateCollectionSource(Application.CreateObjectSpace(), objectType, viewID);
                e.ShowViewParameters.TargetWindow = TargetWindow.Current;
                e.ShowViewParameters.Context = TemplateContext.ApplicationWindow;
                e.ShowViewParameters.CreatedView = Application.CreateListView(viewID, collectionSource, true);
            }
        }
    }
}
