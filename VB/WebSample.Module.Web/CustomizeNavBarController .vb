Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Web.Templates.ActionContainers
Imports DevExpress.Web.ASPxNavBar
Imports DevExpress.ExpressApp.SystemModule
Imports System.Web.UI.WebControls

Namespace WebSample.Module.Web
	Partial Public Class NavBarViewChangingController
		Inherits WindowController
		Public Sub New()
			InitializeComponent()
			RegisterActions(components)
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			AddHandler Window.TemplateChanged, AddressOf Window_TemplateChanged
		End Sub
		Private Sub Window_TemplateChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim navBarControl As NavigationBarActionContainer = FindNavBarControl()
			If navBarControl IsNot Nothing Then
				ConfigureNavBar(navBarControl)
			End If
		End Sub
		Private Function FindNavBarControl() As NavigationBarActionContainer
			If Window.Template IsNot Nothing AndAlso Window.IsMain Then
				For Each actionContainer As Object In Window.Template.GetContainers()
					If TypeOf actionContainer Is NavigationBarActionContainer Then
						Return CType(actionContainer, NavigationBarActionContainer)
					End If
				Next actionContainer
			End If
			Return Nothing
		End Function
		Private nodes() As TreeNode
		Private Sub ConfigureNavBar(ByVal navBarControl As NavigationBarActionContainer)
			navBarControl.BeginUpdate()
			Try
				Dim navGroup As NavBarGroup = navBarControl.Groups.FindByText("Data")
				Dim treeView As New MyTreeView(singleChoiceAction1.Items, singleChoiceAction1, nodes)
				nodes = New TreeNode(treeView.Nodes.Count - 1){}
				treeView.Nodes.CopyTo(nodes, 0)
				navGroup.ContentTemplate = treeView
			Finally
				navBarControl.EndUpdate()
			End Try
		End Sub
		Private Sub singleChoiceAction1_Execute(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventArgs) Handles singleChoiceAction1.Execute
			If e.SelectedChoiceActionItem.Data IsNot Nothing Then
				Dim objectType As Type = ReflectionHelper.FindType(e.SelectedChoiceActionItem.Data.ToString())
				Dim viewID As String = Application.GetListViewId(objectType)
				Dim collectionSource As CollectionSourceBase = Application.CreateCollectionSource(Application.CreateObjectSpace(), objectType, viewID)
				e.ShowViewParameters.TargetWindow = TargetWindow.Current
				e.ShowViewParameters.Context = TemplateContext.ApplicationWindow
				e.ShowViewParameters.CreatedView = Application.CreateListView(viewID, collectionSource, True)
			End If
		End Sub
	End Class
End Namespace
