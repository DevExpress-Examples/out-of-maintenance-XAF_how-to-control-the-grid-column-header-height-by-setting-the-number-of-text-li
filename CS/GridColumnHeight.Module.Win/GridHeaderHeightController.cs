using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.Persistent.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using XAFCommunity.Win;

namespace GridColumnHeight.Module.Win
{
    public partial class GridHeaderHeightController : ViewController
    {
        public GridHeaderHeightController()
        {
            InitializeComponent();
            RegisterActions(components);

            TargetViewType = ViewType.ListView;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            View.ControlsCreated += View_ControlsCreated;
        }

        protected override void OnDeactivating()
        {
            View.ControlsCreated -= View_ControlsCreated;
            base.OnDeactivating();
        }

        void View_ControlsCreated(object sender, EventArgs e)
        {
            DictionaryAttribute attr = this.View.Info.GetAttribute("HeaderRows");
            if (attr!= null) 
            {
                int lines;
                if (int.TryParse(attr.Value, out lines))
                {
                    SetColumnHeadingRowHeight(View as ListView, lines);
                }
            }
        }

        /// <summary>
        /// Configures the supplied ListView grid to show word wrapped column captions.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="lineCount">The number of lines of text required in the column header.</param>
        internal static void SetColumnHeadingRowHeight(ListView view, int lineCount)
        {
            if (view != null && lineCount > 1)
            {
                GridListEditor listEditor = view.Editor as GridListEditor;
                if (listEditor != null)
                    GridHeaderHeightHelper.SetGridEditorHeaderHeight(listEditor, lineCount);
            }
        }
    }
}