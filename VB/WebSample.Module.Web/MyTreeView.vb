Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.ExpressApp.Actions

Namespace WebSample.Module.Web
	Public Class MyTreeView
		Inherits TreeView
		Implements ITemplate
		Private action As SingleChoiceAction
		Public Sub New(ByVal items As ChoiceActionItemCollection, ByVal action As SingleChoiceAction, ByVal nodes() As TreeNode)
			Me.Nodes.Clear()
			Me.action = action
			If nodes IsNot Nothing Then
				For Each node As TreeNode In nodes
					Me.Nodes.Add(node)
				Next node
			Else
				CreateNodes(items, Me.Nodes)
			End If
			AddHandler SelectedNodeChanged, AddressOf WebTreeListActionContainer_SelectedNodeChanged
		End Sub

		Private Sub WebTreeListActionContainer_SelectedNodeChanged(ByVal sender As Object, ByVal e As EventArgs)
			If TypeOf SelectedNode Is WebTreeViewActionNode Then
				TryCast(SelectedNode, WebTreeViewActionNode).ExecuteAction()
			End If
		End Sub
		Private Sub CreateNodes(ByVal items As ChoiceActionItemCollection, ByVal nodes As TreeNodeCollection)
			For Each item As ChoiceActionItem In items
				Dim node As New WebTreeViewActionNode(action, item, Me)
				nodes.Add(node)
				CreateNodes(item.Items, node.ChildNodes)
			Next item
		End Sub
		#Region "ITemplate Members"
		Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
			container.Controls.Add(Me)
		End Sub
		#End Region
	End Class
End Namespace
