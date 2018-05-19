Imports Microsoft.VisualBasic
Imports DevExpress.ExpressApp.Actions
Imports System.Web.UI.WebControls
Imports DevExpress.ExpressApp.Utils

Namespace WebSample.Module.Web
	Public Class WebTreeViewActionNode
		Inherits TreeNode
		Private action As SingleChoiceAction
		Private itemValue As ChoiceActionItem
		Public Sub New(ByVal action As SingleChoiceAction, ByVal itemValue As ChoiceActionItem, ByVal owner As TreeView)
			MyBase.New(owner, False)
			Me.action = action
			Me.itemValue = itemValue
			If itemValue IsNot Nothing Then
				Me.Text = itemValue.Caption
				Me.ImageUrl = ImageLoader.Instance.GetImageInfo(itemValue.Info.GetAttributeValue(DevExpress.ExpressApp.NodeWrappers.VisualItemInfoNodeWrapper.ImageNameAttribute)).ImageUrl
				Me.SelectAction = TreeNodeSelectAction.Select
			End If
		End Sub
		Public Sub ExecuteAction()
			action.DoExecute(itemValue)
		End Sub
	End Class
End Namespace
