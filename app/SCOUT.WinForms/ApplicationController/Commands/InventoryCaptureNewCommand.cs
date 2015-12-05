using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.WinForms.Inventory;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Loads capture creation form and returns the newly created capture
    /// </summary>
    public class InventoryCaptureNewCommand : Command, IOutputCommand<InventoryCapture>
    {
        private InventoryCapture m_capture;
        private IUnitOfWork m_session;
        
        public InventoryCaptureNewCommand(params object[] input) : base(input)
        {
            m_session = input[0] as IUnitOfWork;
        }

        public override void Execute()
        {
            m_capture = Scout.Core.Data.CreateEntity<InventoryCapture>(m_session);

            ViewLoader.Instance()
                .CreateFormWithArgs<InventoryCaptureManager>(true, m_capture);              
        }

        public InventoryCapture Output
        {
            get
            {
                return m_capture;
            }
        }
    }
}