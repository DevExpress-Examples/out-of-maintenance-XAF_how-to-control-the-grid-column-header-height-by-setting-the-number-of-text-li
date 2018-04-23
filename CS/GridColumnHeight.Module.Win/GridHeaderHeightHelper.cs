using System;
using System.Drawing;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.ExpressApp.Win.Editors;

namespace XAFCommunity.Win
{
    public static class GridHeaderHeightHelper
    {
        internal static Schema GetGridHeaderHeightSchema()
        {
            const string schema =
                @"<Element Name=""Application"">
	                <Element Name=""Views"">
		                <Element Name=""ListView"">
                            <Attribute Name=""HeaderRows"" IsNewNode=""True""/>
		                </Element>
		                <Element Name=""LookupListView"">
                            <Attribute Name=""HeaderRows"" IsNewNode=""True""/>
		                </Element>
	                </Element>
                </Element>";
            
            return new Schema(new DictionaryXmlReader().ReadFromString(schema));
        }

        /// <summary>
        /// Computes a suitable height for the column header based upon the number of column header lines required.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="minHeaderHeight"></param>
        /// <param name="lineCount"></param>
        /// <returns></returns>
        internal static int CalcMinColumnRowHeight(GridView view, int minHeaderHeight, int lineCount)
        {
            int maxY = 0;
            minHeaderHeight = Math.Max(minHeaderHeight, 12);

            if (view != null && lineCount > 1)
            {
                GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
                Graphics graphic = viewInfo.GInfo.AddGraphics(null);

                try
                {
                    GridColumnInfoArgs e = new GridColumnInfoArgs(viewInfo.GInfo.Cache, null);
                    e.InnerElements.Add(new DrawElementInfo(new GlyphElementPainter(), new GlyphElementInfoArgs(view.Images, 0, null), StringAlignment.Near));
                    if (view.CanShowFilterButton(null))
                        e.InnerElements.Add(viewInfo.Painter.ElementsPainter.FilterButton, new GridFilterButtonInfoArgs());
                    e.SetAppearance(viewInfo.PaintAppearance.HeaderPanel);
                    maxY = viewInfo.Painter.ElementsPainter.Column.CalcObjectMinBounds(e).Height;
                    if (view.OptionsView.AllowHtmlDrawHeaders)
                    {
                        string dummyCaption = new StringBuilder("Ûj").Insert(0, "Ûj\n", lineCount - 1).ToString();
                        e.UseHtmlTextDraw = true;
                        e.Caption = dummyCaption;
                        maxY = Math.Max(maxY, viewInfo.Painter.ElementsPainter.Column.CalcObjectMinBounds(e).Height);
                    }
                }
                finally
                {
                    viewInfo.GInfo.ReleaseGraphics();
                }
            }
            return Math.Max(maxY, minHeaderHeight);
        }

        internal static void SetGridEditorHeaderHeight(GridListEditor listEditor, int lineCount)
        {
            if (listEditor != null)
            {
                GridControl gridControl = listEditor.Control as GridControl;
                if (gridControl != null)
                {
                    GridView gridView = gridControl.FocusedView as GridView;
                    if (gridView != null)
                    {
                        gridView.OptionsView.AllowHtmlDrawHeaders = true;
                        gridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        int columnHeaderHeight =
                            GridHeaderHeightHelper.CalcMinColumnRowHeight(gridView, -1, lineCount);
                        gridView.ColumnPanelRowHeight = columnHeaderHeight;
                    }
                }
            }
        }

    }
}
