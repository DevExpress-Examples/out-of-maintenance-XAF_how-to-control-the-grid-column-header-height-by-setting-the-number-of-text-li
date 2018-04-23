using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;


namespace GridColumnHeight.Module.Win
{
    public interface IModelListViewHeaderRows : IModelNode
    {
        int HeaderRows { get; set; }
    }

    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class GridColumnHeightWindowsFormsModule : ModuleBase
    {
        public GridColumnHeightWindowsFormsModule()
        {
            InitializeComponent();
        }

        public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
        {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<IModelListView, IModelListViewHeaderRows>();
        }
    }
}
