using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Mvc
{
    public interface IBomMasterView : IPassiveView
    {
        PartModel PartModel { set;}
        ICollection<BomComponentCategory> BomComponentCategories { get; set; }
        ICollection<BomMasterComponent> BomMasterComponents { get; set; }
        ICollection<BomConfiguration> BomConfigurations { get; set; }

        void ManageConfiguration(BomConfiguration configuration);

        event EventHandler<SingleChoiceActionRequestEventArgs<BomConfiguration>> 
            EditBomConfiguration;

        event EventHandler<SingleChoiceActionRequestEventArgs<BomConfiguration>>
            DeleteBomConfiguration;
                                            
    }
}