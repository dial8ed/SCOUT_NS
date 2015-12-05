using System;
using SCOUT.Core.Data;
using SCOUT.Core.Mvc;
using SCOUT.WinForms.Materials;

namespace SCOUT.WinForms.Core
{
    public class MaterialsConsumeBomConfigurationCommand : Command, IOutputCommand<bool>, IDisposable
    {
        private BomConfiguration m_configuration;
        private bool m_consumptionSuccessful;
        private MaterialsConsumptionModel m_model;
        private MaterialsConsumptionController m_controller;


        public MaterialsConsumeBomConfigurationCommand(params object[] input)
            : base(input)
        {
            m_configuration = input[0] as BomConfiguration;
        }

        public override void Execute()
        {
            MaterialsConsumptionModel m_model = 
                new MaterialsConsumptionModel(m_configuration);

            PartsConsumptionView m_view = 
                new PartsConsumptionView();   

            MaterialsConsumptionController controller =
                new MaterialsConsumptionController(m_model,m_view);

            m_controller.PersistenceSave += Controller_OnPersistenceSaved;
            
            ViewLoader.Instance().ShowForm(m_view, false);
                        
        }

        private void Controller_OnPersistenceSaved(object sender, ActionRequestEventArgs e)
        {
            m_consumptionSuccessful = true;   
        }


        public bool Output
        {
            get { return m_consumptionSuccessful; }
        }

        public void Dispose()
        {
            m_controller.PersistenceSave -= Controller_OnPersistenceSaved;
        }
    }
}