using System;
using SCOUT.Core.Mvc;
using SCOUT.WinForms.Bom;

namespace SCOUT.WinForms.Core
{
    public class PartsManageBomMasterCommand : Command
    {
        private int m_partModelId;

        public PartsManageBomMasterCommand(params object[] input) : base(input)
        {
            m_partModelId = (int)input[0];
        }


        public override void Execute()
        {            
            BomMasterModel model = new BomMasterModel(m_partModelId);
            BomMasterView view = new BomMasterView();
            BomMasterController controller = new BomMasterController(model, view);     
            ViewLoader.Instance().ShowForm(view, false);                          
        }
    }
}