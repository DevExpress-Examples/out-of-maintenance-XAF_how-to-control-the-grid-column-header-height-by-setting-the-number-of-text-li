Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace GridColumnHeight.Module
	<NavigationItem()> _
	Public Class Invoice
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)

		End Sub

		#Region "DocumentNumber"

		Private _documentNumber As String

		<Size(10), Indexed(), Index(0)> _
		Public Property DocumentNumber() As String
			Get
				Return _documentNumber
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("DocumentNumber", _documentNumber, value)
			End Set
		End Property

		#End Region

		#Region "DocumentChaseDate"

		Private _documentChaseDate As Nullable(Of DateTime)

		Public Property DocumentChaseDate() As Nullable(Of DateTime)
			Get
				Return _documentChaseDate
			End Get
			Set(ByVal value As Nullable(Of DateTime))
				SetPropertyValue(Of Nullable(Of DateTime))("DocumentChaseDate", _documentChaseDate, value)
			End Set
		End Property

		#End Region

		#Region "Lines"

		<Association()> _
		Public ReadOnly Property Lines() As XPCollection(Of InvoiceLine)
			Get
				Return GetCollection(Of InvoiceLine)("Lines")
			End Get
		End Property

		#End Region

		#Region "RelatedInvoice"

		Private _relatedInvoice As Invoice

		'    [DisplayName("RelatedInvoice")]
		Public Property RelatedInvoice() As Invoice
			Get
				Return _relatedInvoice
			End Get
			Set(ByVal value As Invoice)
				SetPropertyValue(Of Invoice)("RelatedInvoice", _relatedInvoice, value)
			End Set
		End Property

		#End Region

		#Region "SpaceWaster01"

		Private _spaceWaster01 As String

		Public Property SpaceWaster01() As String
			Get
				Return _spaceWaster01
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SpaceWaster01", _spaceWaster01, value)
			End Set
		End Property

		#End Region

		#Region "SpaceWaster02"

		Private _spaceWaster02 As String

		Public Property SpaceWaster02() As String
			Get
				Return _spaceWaster02
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SpaceWaster02", _spaceWaster02, value)
			End Set
		End Property

		#End Region

		#Region "SpaceWaster03"

		Private _spaceWaster03 As String

		Public Property SpaceWaster03() As String
			Get
				Return _spaceWaster03
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SpaceWaster03", _spaceWaster03, value)
			End Set
		End Property

		#End Region

		#Region "SpaceWaster04"

		Private _spaceWaster04 As String

		Public Property SpaceWaster04() As String
			Get
				Return _spaceWaster04
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SpaceWaster04", _spaceWaster04, value)
			End Set
		End Property

		#End Region

		#Region "SpaceWaster05"

		Private _spaceWaster05 As String

		Public Property SpaceWaster05() As String
			Get
				Return _spaceWaster05
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SpaceWaster05", _spaceWaster05, value)
			End Set
		End Property

		#End Region

		#Region "SpaceWaster06"

		Private _spaceWaster06 As String

		Public Property SpaceWaster06() As String
			Get
				Return _spaceWaster06
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SpaceWaster06", _spaceWaster06, value)
			End Set
		End Property

		#End Region

		#Region "SpaceWaster07"

		Private _spaceWaster07 As String

		Public Property SpaceWaster07() As String
			Get
				Return _spaceWaster07
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SpaceWaster07", _spaceWaster07, value)
			End Set
		End Property

		#End Region

		#Region "SpaceWaster08"

		Private _spaceWaster08 As String

		Public Property SpaceWaster08() As String
			Get
				Return _spaceWaster08
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SpaceWaster08", _spaceWaster08, value)
			End Set
		End Property

		#End Region

		#Region "SpaceWaster09"

		Private _spaceWaster09 As String

		Public Property SpaceWaster09() As String
			Get
				Return _spaceWaster09
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SpaceWaster09", _spaceWaster09, value)
			End Set
		End Property

		#End Region

		#Region "SpaceWaster10"

		Private _spaceWaster10 As String

		Public Property SpaceWaster10() As String
			Get
				Return _spaceWaster10
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("SpaceWaster10", _spaceWaster10, value)
			End Set
		End Property

		#End Region

	End Class
End Namespace
