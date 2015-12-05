using System;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Materials
{
    public partial class MaterialsReceivingForm : DevExpress.XtraEditors.XtraForm
    {
        private MaterialPurchaseOrder m_po;
        private Part m_receivePart;
        private string m_scannedPartNumber = "";

        public MaterialsReceivingForm(MaterialPurchaseOrder po)
        {
            InitializeComponent();
            m_po = po;
            Bind();
            WireEvents();
            ResetReceiving();
        }

        private Part ReceivePart
        {
            get { return m_receivePart; }
            set
            {
                m_receivePart = value;
                if (m_receivePart != null)
                    ScatterPartDetails();
                else
                    ClearPartDetails();                           
                }
        }

        private void ClearPartDetails()
        {
            descriptionText.Text = "";
            m_scannedPartNumber = "";
        }

        private void ScatterPartDetails()
        {          
            partNumberText.Text = m_receivePart.PartNumber;
            descriptionText.Text = m_receivePart.Description;
        }

        private void WireEvents()
        {
            receiveButton.Click += receiveButton_Click;
            partNumberText.Validated += partNumberText_Validated;
            lineItemsGrid.DoubleClick += lineItemsGrid_DoubleClick;
        }

        void lineItemsGrid_DoubleClick(object sender, EventArgs e)
        {
            MaterialPurchaseLineItem lineItem = 
                lineItemsView.GetFocusedRow() as MaterialPurchaseLineItem;

            if(lineItem == null)
                return;

            ReceivePart = lineItem.Part;          
        }

        void partNumberText_Validated(object sender, EventArgs e)
        {
            m_scannedPartNumber = "";
            // Guard
            if (string.IsNullOrEmpty(partNumberText.Text))
                return;

            m_scannedPartNumber = partNumberText.Text;

            ReceivePart = GetPartByPartNumber(partNumberText.Text); 
        }

        void receiveButton_Click(object sender, EventArgs e)
        {
            Receive();
            ResetReceiving();
        }

        private void ResetReceiving()
        {
            ReceivePart = null;
            receiveQtyText.Text = "";
            m_scannedPartNumber = "";
            partNumberText.SelectAll();
            partNumberText.Focus();
        }

        private void Receive()
        {            
            if (ReceivePart == null) return;

            if (MaterialService.ReceiveMaterial(
                     m_po, ReceivePart, Int32.Parse(receiveQtyText.Text), m_scannedPartNumber))
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Materials Received", UserMessageType.Information);                
            }
        }


        private Part GetPartByPartNumber(string partNumber)
        {
            return MaterialService.GetPartByPartNumber(m_po.Session,partNumber);
        }


        private void Bind()
        {
            supplierText.Text = m_po.Organization.Name;
            poText.Text = m_po.PO;
            rmaText.Text = m_po.RMA;
            otherText.Text = m_po.Other;
            receiveDomainText.Text = m_po.ReceiveDomain.ToString();
            lineItemsGrid.DataSource = m_po.LineItems;         
        }
    }
}