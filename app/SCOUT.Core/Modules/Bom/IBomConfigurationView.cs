using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Mvc
{
    public interface IBomConfigurationView : IPassiveView
    {
        ICollection<Shopfloorline> Shopfloorlines { set; }
        PartModel PartModel { set;}        
        BomMaster BomMaster { set; }
        BomConfiguration BomConfiguration { set;}

        event EventHandler<SingleChoiceActionRequestEventArgs<BomMasterComponent>>
            OnAddComponentToConfigurationRequest;

        event
            EventHandler<SingleChoiceActionRequestEventArgs<BomConfigurationItem>>
            OnRemoveBomConfigurationItemRequest;

    }
}