using System;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Views
{
    public partial class ResolveDfileItemView : Form
    {
        private DfileItem m_dfileItem;
        private IUnitOfWork m_uow;
        private Order m_actionOrder;
        
        public ResolveDfileItemView(DfileItem item)
        {
            InitializeComponent();
            m_dfileItem = item;
            m_uow = m_dfileItem.Session;
            LoadActionTypes();
            BindDfileDetails();
            WireEvents();
        }

        public Order ActionOrder
        {
            get { return m_actionOrder; }
            set
            {
                m_actionOrder = value;
                if(m_actionOrder != null)
                {                    
                    orderIdText.Text = m_actionOrder.Id.ToString();
                    poRmaText.Text = m_actionOrder.RMA;
                    poPoText.Text = m_actionOrder.PO;                    
                }                
                else
                {
                    SetInvalidOrderState();
                }
            }
        }

        private void SetInvalidOrderState()
        {
            Scout.Core.UserInteraction.Dialog.ShowMessage
                ("Order Id:" + orderIdText.Text + " is not a valid order.", UserMessageType.Error);

            m_dfileItem.ActionOrder = null;
            orderIdText.Text = "";
            poRmaText.Text = "";
            poPoText.Text = "";            
        }

        public int OrderId
        {           
            set
            {
                if (value == 0)
                    ActionOrder = null;
                else
                    ActionOrder = Scout.Core.Data.Get<Order>(m_uow).ById(value);                
            }
        }

        private void WireEvents()
        {
            actionLookUp.EditValueChanged += actionLookUp_EditValueChanged;
            orderIdText.Validated += orderIdText_Validated;
        }

        void orderIdText_Validated(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(orderIdText.Text))
            {
                int orderId = Int32.Parse(orderIdText.Text);
                OrderId = orderId;                
            }
        }

        void actionLookUp_EditValueChanged(object sender, EventArgs e)
        {            
            switch ((DfileAction) actionLookUp.EditValue)
            {
                case DfileAction.NoAction:
                    EnableReceivingEditors(false);
                    EnableShippingEditors(false);
                    break;

                case DfileAction.Receive:
                    EnableReceivingEditors(true);
                    EnableShippingEditors(false);
                    resolutionText.Focus();
                    break;

                case DfileAction.ReturnToCustomer:
                    EnableShippingEditors(true);
                    EnableReceivingEditors(true);
                    resolutionText.Focus();
                    break;
            }                                         
        }

        private void EnableShippingEditors(bool enable)
        {
            shippingTab.PageVisible = enable;
        }

        private void EnableReceivingEditors(bool enable)
        {
            receivingTab.PageVisible = enable;
            radioGroup1.SelectedIndex = 0;
        }

        private void LoadActionTypes()
        {            
            actionLookUp.Properties.DataSource = Enum.GetValues(typeof (DfileAction));
            actionLookUp.EditValue = m_dfileItem.Action;
        }

        private void BindDfileDetails()
        {
            serialNumberText.DataBindings.Add("Text", m_dfileItem, "SerialNumber");
            partNumberText.Text = m_dfileItem.Part.PartNumber;
            reasonText.DataBindings.Add("Text", m_dfileItem, "Reason");
            createDateText.DataBindings.Add("Text", m_dfileItem, "CreatedDate");
            disableDfileCheck.DataBindings.Add("Checked", m_dfileItem, "DisableDfileAtReceipt");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(radioGroup1.SelectedIndex)
            {
                case 0:
                    ActionOrder = m_dfileItem.IncomingOrder;
                    orderIdText.Enabled = false;
                    break;

                case 1:
                    orderIdText.Enabled = true;
                    orderIdText.Text = "";
                    poPoText.Text = "";
                    poRmaText.Text = "";
                    break;
            }                  
        }

        private void resolveButton_Click(object sender, EventArgs e)
        {
            if (Scout.Core.Service<IDfileService>()
                .ResolveItem(m_dfileItem,
                            resolutionText.Text,
                            Security.Security.CurrentUser.Login,
                            (DfileAction)actionLookUp.EditValue, ActionOrder)) ;
            
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
                
        }

        private void closeWithNoActionButton_Click(object sender, EventArgs e)
        {
            if (Scout.Core.Service<IDfileService>()
                .CloseDfileWithNoAction(m_dfileItem, 
                                        resolutionText.Text, 
                                        Security.Security.CurrentUser.Login))
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }

        }
    }
}
