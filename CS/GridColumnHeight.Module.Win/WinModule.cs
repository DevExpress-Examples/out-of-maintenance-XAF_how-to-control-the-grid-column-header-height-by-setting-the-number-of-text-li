using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;


namespace GridColumnHeight.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class GridColumnHeightWindowsFormsModule : ModuleBase
    {
        public GridColumnHeightWindowsFormsModule()
        {
            InitializeComponent();
        }

        public override Schema GetSchema()
        {
            return XAFCommunity.Win.GridHeaderHeightHelper.GetGridHeaderHeightSchema();
            //return base.GetSchema();
        }
    }
}
