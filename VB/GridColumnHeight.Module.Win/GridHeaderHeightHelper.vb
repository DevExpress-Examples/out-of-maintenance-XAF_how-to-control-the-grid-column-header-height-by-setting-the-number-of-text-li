Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraGrid.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid
Imports DevExpress.ExpressApp.Win.Editors

Namespace XAFCommunity.Win
	Public NotInheritable Class GridHeaderHeightHelper
		Private Sub New()
		End Sub
		Friend Shared Function GetGridHeaderHeightSchema() As Schema
			Const schema As String = "<Element Name=""Application"">" & ControlChars.CrLf & "	                <Element Name=""Views"">" & ControlChars.CrLf & "		                <Element Name=""ListView"">" & ControlChars.CrLf & "                            <Attribute Name=""HeaderRows"" IsNewNode=""True""/>" & ControlChars.CrLf & "		                </Element>" & ControlChars.CrLf & "		                <Element Name=""LookupListView"">" & ControlChars.CrLf & "                            <Attribute Name=""HeaderRows"" IsNewNode=""True""/>" & ControlChars.CrLf & "		                </Element>" & ControlChars.CrLf & "	                </Element>" & ControlChars.CrLf & "                </Element>"

			Return New Schema(New DictionaryXmlReader().ReadFromString(schema))
		End Function

		''' <summary>
		''' Computes a suitable height for the column header based upon the number of column header lines required.
		''' </summary>
		''' <param name="view"></param>
		''' <param name="minHeaderHeight"></param>
		''' <param name="lineCount"></param>
		''' <returns></returns>
		Friend Shared Function CalcMinColumnRowHeight(ByVal view As GridView, ByVal minHeaderHeight As Integer, ByVal lineCount As Integer) As Integer
			Dim maxY As Integer = 0
			minHeaderHeight = Math.Max(minHeaderHeight, 12)

			If view IsNot Nothing AndAlso lineCount > 1 Then
				Dim viewInfo As GridViewInfo = TryCast(view.GetViewInfo(), GridViewInfo)
				Dim graphic As Graphics = viewInfo.GInfo.AddGraphics(Nothing)

				Try
					Dim e As New GridColumnInfoArgs(viewInfo.GInfo.Cache, Nothing)
					e.InnerElements.Add(New DrawElementInfo(New GlyphElementPainter(), New GlyphElementInfoArgs(view.Images, 0, Nothing), StringAlignment.Near))
					If view.CanShowFilterButton(Nothing) Then
						e.InnerElements.Add(viewInfo.Painter.ElementsPainter.FilterButton, New GridFilterButtonInfoArgs())
					End If
					e.SetAppearance(viewInfo.PaintAppearance.HeaderPanel)
					maxY = viewInfo.Painter.ElementsPainter.Column.CalcObjectMinBounds(e).Height
					If view.OptionsView.AllowHtmlDrawHeaders Then
						Dim dummyCaption As String = New StringBuilder("Ûj").Insert(0, "Ûj" & Constants.vbLf, lineCount - 1).ToString()
						e.UseHtmlTextDraw = True
						e.Caption = dummyCaption
						maxY = Math.Max(maxY, viewInfo.Painter.ElementsPainter.Column.CalcObjectMinBounds(e).Height)
					End If
				Finally
					viewInfo.GInfo.ReleaseGraphics()
				End Try
			End If
			Return Math.Max(maxY, minHeaderHeight)
		End Function

		Friend Shared Sub SetGridEditorHeaderHeight(ByVal listEditor As GridListEditor, ByVal lineCount As Integer)
			If listEditor IsNot Nothing Then
				Dim gridControl As GridControl = TryCast(listEditor.Control, GridControl)
				If gridControl IsNot Nothing Then
					Dim gridView As GridView = TryCast(gridControl.FocusedView, GridView)
					If gridView IsNot Nothing Then
						gridView.OptionsView.AllowHtmlDrawHeaders = True
						gridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
						Dim columnHeaderHeight As Integer = GridHeaderHeightHelper.CalcMinColumnRowHeight(gridView, -1, lineCount)
						gridView.ColumnPanelRowHeight = columnHeaderHeight
					End If
				End If
			End If
		End Sub

	End Class
End Namespace
