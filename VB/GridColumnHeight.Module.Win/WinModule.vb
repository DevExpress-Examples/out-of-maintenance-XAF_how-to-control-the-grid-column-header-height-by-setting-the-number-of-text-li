Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model

Namespace GridColumnHeight.Module.Win
    Public Interface IModelListViewHeaderRows
        Inherits IModelNode
        Property HeaderRows() As Integer
    End Interface

    <ToolboxItemFilter("Xaf.Platform.Win")> _
    Partial Public NotInheritable Class GridColumnHeightWindowsFormsModule
        Inherits ModuleBase
        Public Sub New()
            InitializeComponent()
        End Sub
        Public Overrides Sub ExtendModelInterfaces(ByVal extenders As ModelInterfaceExtenders)
            MyBase.ExtendModelInterfaces(extenders)
            extenders.Add(Of IModelListView, IModelListViewHeaderRows)()
        End Sub
    End Class
End Namespace
