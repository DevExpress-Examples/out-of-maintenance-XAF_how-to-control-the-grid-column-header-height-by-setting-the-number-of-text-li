Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports System.Reflection


Namespace GridColumnHeight.Module
	Public NotInheritable Partial Class GridColumnHeightModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Overrides Overloads Sub Setup(ByVal application As XafApplication)
			MyBase.Setup(application)
		End Sub
	End Class
End Namespace
