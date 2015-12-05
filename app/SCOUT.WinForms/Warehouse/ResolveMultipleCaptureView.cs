using System.Windows.Forms;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Warehouse
{
    public partial class ResolveMultipleCaptureView : Form
    {
        private InventoryHold m_hold;        
        private ICaptureService m_service;
        private UnitOfWork m_unitOfWork;
        
        public ResolveMultipleCaptureView(InventoryHold hold)
        {
            m_hold = hold;
            m_service = Scout.Core.Service<ICaptureService>();
            m_unitOfWork = m_service.Providers.Data.GetUnitOfWork();

            InitializeComponent();
            Bind();
        }

        private void Bind()
        {
            serialNumberText.Text = m_hold.Item.SerialNumber;

            capturesGrid.DataSource =                
                    m_service.Repository.GetCapturesFromCommaIdString
                    (m_unitOfWork, m_hold.MultipleCaptureIds);        
        }

        private void executeCaptureButton_Click(object sender, System.EventArgs e)
        {
           InventoryCapture capture = capturesView.GetFocusedRow() as InventoryCapture;
            if(capture != null)
            {
                m_service.ExecuteMultipleHighPriorityCapture(capture, m_hold.Item);
                Close();
            }                
        }
    }
}
