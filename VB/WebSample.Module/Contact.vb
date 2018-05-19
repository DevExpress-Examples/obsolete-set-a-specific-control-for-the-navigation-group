Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace WebSample.Module
	<NavigationItem("Data")> _
	Public Class Contact
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private _Name As String
		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _Name, value)
			End Set
		End Property
		Private _Email As String
		Public Property Email() As String
			Get
				Return _Email
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Email", _Email, value)
			End Set
		End Property
		<Association("Contact-Phones"), Aggregated> _
		Public ReadOnly Property Phones() As XPCollection(Of Phone)
			Get
				Return GetCollection(Of Phone)("Phones")
			End Get
		End Property
		<Association("Contact-Addresses")> _
		Public ReadOnly Property Addresses() As XPCollection(Of ContactAddress)
			Get
				Return GetCollection(Of ContactAddress)("Addresses")
			End Get
		End Property
	End Class
End Namespace
