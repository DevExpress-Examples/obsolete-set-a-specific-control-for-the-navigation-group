Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace WebSample.Module
	<NavigationItem("Data")> _
	Public Class Phone
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private _Comments As String
		Public Property Comments() As String
			Get
				Return _Comments
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Comments", _Comments, value)
			End Set
		End Property
		Private _Number As Integer
		Public Property Number() As Integer
			Get
				Return _Number
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Number", _Number, value)
			End Set
		End Property
		Private _Contact As Contact
		<Association("Contact-Phones")> _
		Public Property Contact() As Contact
			Get
				Return _Contact
			End Get
			Set(ByVal value As Contact)
				SetPropertyValue("Contact", _Contact, value)
			End Set
		End Property
	End Class
End Namespace
