Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.Persistent.Base
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports XAFCommunity.Win

Namespace GridColumnHeight.Module.Win
	Partial Public Class GridHeaderHeightController
		Inherits ViewController
		Public Sub New()
			InitializeComponent()
			RegisterActions(components)

			TargetViewType = ViewType.ListView
		End Sub

		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			AddHandler View.ControlsCreated, AddressOf View_ControlsCreated
		End Sub

		Protected Overrides Sub OnDeactivated()
			RemoveHandler View.ControlsCreated, AddressOf View_ControlsCreated
			MyBase.OnDeactivated()
		End Sub

		Private Sub View_ControlsCreated(ByVal sender As Object, ByVal e As EventArgs)
            Dim modelListViewHeaderRows As IModelListViewHeaderRows = CType(Me.View.Model, IModelListViewHeaderRows)
            If modelListViewHeaderRows IsNot Nothing Then
                SetColumnHeadingRowHeight(TryCast(View, ListView), modelListViewHeaderRows.HeaderRows)
            End If
		End Sub

		''' <summary>
		''' Configures the supplied ListView grid to show word wrapped column captions.
		''' </summary>
		''' <param name="view"></param>
		''' <param name="lineCount">The number of lines of text required in the column header.</param>
		Friend Shared Sub SetColumnHeadingRowHeight(ByVal view As ListView, ByVal lineCount As Integer)
			If view IsNot Nothing AndAlso lineCount > 1 Then
				Dim listEditor As GridListEditor = TryCast(view.Editor, GridListEditor)
				If listEditor IsNot Nothing Then
					GridHeaderHeightHelper.SetGridEditorHeaderHeight(listEditor, lineCount)
				End If
			End If
		End Sub
	End Class
End Namespace