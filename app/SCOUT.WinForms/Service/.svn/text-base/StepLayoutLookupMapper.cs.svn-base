using DevExpress.XtraEditors;
using SCOUT.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public class StepLayoutLookupMapper : IMapper<RouteStationStep, LookUpEdit>
    {
        public LookUpEdit MapFrom(RouteStationStep input)
        {
            LookUpEdit lookup = new LookUpEdit();
            lookup.Properties.DataSource = input.ResultList.ResultListValues;
            input.ResultList.ResultListValues.DisplayableProperties = "This!;Value";
            lookup.Name = input.DisplayPrompt + "lookUp";

            return lookup;            
        }
    }
}