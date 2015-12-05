using System;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Inventory
{
    public partial class HoldResolutionForm : DevExpress.XtraEditors.XtraForm
    {
        private InventoryCapture m_capture;
        private InventoryHold m_hold;
        private InventoryItem m_item;
        private IUnitOfWork m_session;

        public HoldResolutionForm(InventoryHold hold)
        {
            InitializeComponent();
            m_item = hold.Item;
            m_hold = hold;
            Bind();
        }

        private void Bind()
        {
            m_hold = m_item.Hold;
            m_capture = m_hold.Capture;
            m_session = m_item.Session;

            snText.DataBindings.Add("Text", m_item, "SerialNumber");
            messageText.DataBindings.Add("Text", m_capture, "Message");
            createdByText.DataBindings.Add("Text", m_capture, "CreatedBy");
            createDateText.DataBindings.Add("Text", m_capture, "CreatedDate");
            resolutionText.DataBindings.Add("Text", m_hold, "Resolution");
            descriptionText.DataBindings.Add("Text", m_capture, "Description");
            criteriaText.DataBindings.Add("Text", m_capture, "Criteria");
            domainLookup.Properties.DataSource = m_item.Shopfloorline.Domains;

            SetDefaultMoveToDomain();
        }

        private void SetDefaultMoveToDomain()
        {
            Receipt r = ReceivingService.GetReceipt(m_item);
            if(r != null)
            {
                domainLookup.EditValue = r.PurchaseOrder.RecDomain;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resolveButton_Click(object sender, EventArgs e)
        {
            m_hold.Resolution = resolutionText.Text;
            IInventoryService service = Scout.Core.Service<IInventoryService>();

            try
            {
                if (Scout.Core.Service<ICaptureService>().ReleaseHold
                    (m_hold, domainLookup.EditValue as Domain))
                {

                    if(m_hold.Capture.ReleaseStation != null)
                    {
                        Scout.Core.Service<IShopfloorService>().MoveUnitToNewStation
                            (m_item.CurrentProcess, m_hold.Capture.ReleaseStation);
                    }

                    Scout.Core.Data.Save(m_session);                   
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}