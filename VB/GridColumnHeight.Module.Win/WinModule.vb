Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel

Imports DevExpress.ExpressApp


Namespace GridColumnHeight.Module.Win
	<ToolboxItemFilter("Xaf.Platform.Win")> _
	Public NotInheritable Partial Class GridColumnHeightWindowsFormsModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Overrides Function GetSchema() As Schema
			Return XAFCommunity.Win.GridHeaderHeightHelper.GetGridHeaderHeightSchema()
			'return base.GetSchema();
		End Function
	End Class
End Namespace
