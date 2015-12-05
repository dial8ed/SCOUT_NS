using System.Drawing;
using DevExpress.XtraEditors;
using SCOUT.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public class StationStepTextEditMapper : IMapper<RouteStationResult, TextEdit> 
    {
        public TextEdit MapFrom(RouteStationResult result)
        {
            TextEdit text = new TextEdit();
            text.Name = result.Step.DisplayPrompt + "text";
            text.DataBindings.Add("Text", result, "Result");
            text.EnterMoveNextControl = true;

            if (result.Step.Required)
                text.Font = new Font("Verdana", 8.25F, FontStyle.Bold);

            return text;
        }
    }
}