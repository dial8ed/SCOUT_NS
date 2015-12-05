using SCOUT.Core.Data;
using SCOUT.Core.Mvc;
using SCOUT.WinForms.Bom;

namespace SCOUT.WinForms.Core
{
    public class PartsManageBomConfigurationCommand : Command
    {
        private BomConfiguration m_configuration;
        public PartsManageBomConfigurationCommand(params object[] input) : base(input)
        {
            m_configuration = (BomConfiguration) input[0];
        }

        public override void Execute()
        {
            BomConfigurationModel model = 
                new BomConfigurationModel(m_configuration);

            BomConfigurationView view = new BomConfigurationView();
           
            BomConfigurationController controller =
                new BomConfigurationController(model, view);

            ViewLoader.Instance().ShowForm(view, false);

        }
    }
}