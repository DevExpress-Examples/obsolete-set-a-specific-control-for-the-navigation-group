Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Namespace WebSample.Module.Web
	Partial Public Class NavBarViewChangingController
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim choiceActionItem1 As New DevExpress.ExpressApp.Actions.ChoiceActionItem()
			Dim choiceActionItem2 As New DevExpress.ExpressApp.Actions.ChoiceActionItem()
			Dim choiceActionItem3 As New DevExpress.ExpressApp.Actions.ChoiceActionItem()
			Me.singleChoiceAction1 = New DevExpress.ExpressApp.Actions.SingleChoiceAction(Me.components)
			' 
			' singleChoiceAction1
			' 
			Me.singleChoiceAction1.Caption = "MyAction"
			Me.singleChoiceAction1.Category = "MyMenu"
			Me.singleChoiceAction1.Id = "01551fd6-1b4f-449d-bf8c-71172a297f59"
			choiceActionItem1.Caption = "Contact"
			choiceActionItem1.Data = "Contact"
			choiceActionItem1.ImageName = "BO_Person"
			choiceActionItem2.Caption = "Address"
			choiceActionItem2.Data = "ContactAddress"
			choiceActionItem2.ImageName = "BO_Address"
			choiceActionItem1.Items.Add(choiceActionItem2)
			choiceActionItem3.Caption = "Phone"
			choiceActionItem3.Data = "Phone"
			choiceActionItem3.ImageName = "BO_Note"
			choiceActionItem1.Items.Add(choiceActionItem3)
			Me.singleChoiceAction1.Items.Add(choiceActionItem1)
'			Me.singleChoiceAction1.Execute += New DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(singleChoiceAction1_Execute);

		End Sub
		#End Region
		Private WithEvents singleChoiceAction1 As DevExpress.ExpressApp.Actions.SingleChoiceAction
	End Class
End Namespace
