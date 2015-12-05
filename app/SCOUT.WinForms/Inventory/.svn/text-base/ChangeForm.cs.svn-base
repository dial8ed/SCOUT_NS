using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Inventory
{
    public partial class ChangeForm : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private InventoryItem m_item;
        private Part m_newPart;
        private IUnitOfWork m_session;
        private string m_lotId;

        #endregion

        public ChangeForm(string lotId)
        {
            InitializeComponent();
            m_lotId = lotId;
            m_session = Scout.Core.Data.GetUnitOfWork();
            Bind();
            WireEvents();
        }

        private void Bind()
        {
            if (!string.IsNullOrEmpty(m_lotId))
            {
                lotEdit.Text = m_lotId;
                lotEdit_Validated(null, null);
            }                
        }

        private void WireEvents()
        {
            newPartNumberEdit.Validated += newPartNumberEdit_Validated;            
        }

        void newPartNumberEdit_Validated(object sender, EventArgs e)
        {
            if(newPartNumberEdit.Text.Length ==0) return;
            m_newPart = PartService.GetPartByPartNumber(m_session, newPartNumberEdit.Text);
        }

        #region Utility Functions

        private void SetLotId(string lotId)
        {
            // Validated that the lot exists.
            m_item = Scout.Core.Service<IInventoryService>().GetItemById(m_session, lotId);
                
            if (m_item == null)
            {
                MessageBox.Show("Lot id not found in inventory", Application.ProductName, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                okBtn.Enabled = false;
                return;
            }

            okBtn.Enabled = true;
            lotEdit.EditValue = lotId;
            oldPartNumberEdit.EditValue = m_item.PartNumber;
        }

        private void PrintLabel()
        {            
            Scout.Core.Service<IInventoryService>().PrintTravelerLabel(m_item);
        }

        #endregion

        #region Events

        private void okBtn_Click(object sender, EventArgs e)
        {
            // guard 
            if (newPartNumberEdit.EditValue == null)
                return;

            if(new PartNumberChangeScript(m_item, m_newPart).Run())
            {
                PrintLabel();
                DialogResult = DialogResult.OK;
                ClearFields();               
            }       

        }

        private void ClearFields()
        {
            m_item = null;            
            lotEdit.Text = null;
            oldPartNumberEdit.Text = null;
            newPartNumberEdit.Text = null;
            lotEdit.Focus();
        }

        #endregion

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void lotEdit_Validated(object sender, EventArgs e)
        {
            if (lotEdit.Text.Length > 0)
            {
                SetLotId(lotEdit.Text);
            }
        }
    }
}