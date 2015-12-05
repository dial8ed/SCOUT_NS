using DevExpress.XtraEditors;
using SCOUT.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public class StepLayoutTextMapper : IMapper<RouteStationStep, TextEdit>
    {
        public TextEdit MapFrom(RouteStationStep input)
        {
            TextEdit text = new TextEdit();
            text.Name = input.DisplayPrompt + "text";            
            return text;
        }
    }
}