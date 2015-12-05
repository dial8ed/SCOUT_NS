using DevExpress.XtraEditors;
using SCOUT.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public class StationStepLookUpMapper : IMapper<RouteStationResult, LookUpEdit>
    {
        public LookUpEdit MapFrom(RouteStationResult result)
        {
            LookUpEdit lookup = new LookUpEdit();
            RouteStationStep step = result.Step;
            lookup.Properties.DataSource = step.ResultList.ResultListValues;
            step.ResultList.ResultListValues.DisplayableProperties = "This!;Value";
            lookup.Name = step.DisplayPrompt + "lookUp";
            lookup.Properties.NullText = "Select " + step.DisplayPrompt + " result";
            lookup.Properties.DisplayMember = "Value";
            lookup.Properties.ValueMember = "Value";
            lookup.DataBindings.Add("EditValue", result, "Result");
            lookup.EnterMoveNextControl = true;
            return lookup;
        }
    } 
}