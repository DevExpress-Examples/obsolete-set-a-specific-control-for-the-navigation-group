Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace WebSample.Module
	<NavigationItem("Data")> _
	Public Class ContactAddress
		Inherits DevExpress.Persistent.BaseImpl.Address
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _Contact As Contact
		<Association("Contact-Addresses")> _
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
