using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;
using SCOUT.WinForms.Orders;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Sales
{
    public partial class shippingForm : DevExpress.XtraEditors.XtraForm
    {        
        private InventoryItem m_Item;
        private Order m_order;
        private SalesOrder m_salesOrder;        
        private FrontController m_frontController = FrontController.GetInstance();
               
        public shippingForm(SalesOrder salesOrder)
        {
            InitializeComponent();

            m_salesOrder = salesOrder;
            m_order = m_salesOrder.Order;

            Init();
        }

        private void Init()
        {
            shipButton.Enabled = false;
            WireEvents();
            Bind();
            LoadOrderProcessResults();
            ManagePacklist();
        }

        private void ManagePacklist()
        {
            // Create a new packlist if the user does not want to append 
            // to an existing packlist for the day.
            Packlist packlist = m_salesOrder.GetTodaysPacklist();

            if (packlist != null)
            {
                string msg = "Packlist: " + packlist.PacklistId;
                msg += " exists for today. Would you like to append?";

                if(Scout.Core.UserInteraction.Dialog.AskQuestion(msg) == DialogResult.No)
                    m_salesOrder.NewPacklistUponShipment = true;                
            }
        }

        private void LoadOrderProcessResults()
        {
            expectedGrid.DataSource = m_salesOrder.ShipmentDeltas;
            processedGrid.DataSource = m_salesOrder.Shipments;
        }

        private void Bind()
        {
            rmaLabel.Text = string.Format(rmaLabel.Text, m_order.RMA);
            poLabel.Text = string.Format(poLabel.Text, m_order.PO);
            otherLabel.Text = string.Format(otherLabel.Text, m_order.Other);
            salesOrderLabel.Text = string.Format(salesOrderLabel.Text, m_salesOrder.Order.Id);
            notesText.Text = m_salesOrder.Notes;
            shipToText.Text = m_salesOrder.ShipToAddress;
            shipMethodText.Text = m_salesOrder.ShipMethod;

            LoadCartList();
            processMethod.Properties.DataSource = new string[] {"By LotId", "By Cart"};
            
        }

        private void LoadCartList()
        {
            cartLookup.Properties.DataSource =
                Scout.Core.Service<IAreaService>()
                    .GetAllTotes(m_salesOrder.Session);                
        }

        private void WireEvents()
        {
            lotIdText.Validated += lotIdText_Validated;
            processMethod.EditValueChanged += processMethod_EditValueChanged;
            cartLookup.EditValueChanged += cartLookup_EditValueChanged;
        }

        void cartLookup_EditValueChanged(object sender, EventArgs e)
        {
            Tote tote = cartLookup.EditValue as Tote;
            if(tote != null)
            {
                IOutputCommand<List<InventoryItem>> command = 
                    m_frontController.RunCommand(
                        ToteCommands.ToteContentsSelector,
                        tote
                        ) as IOutputCommand<List<InventoryItem>>;

                if(command != null)
                {
                    Scout.Core.Modules.Warehouse.Shipping.ProcessBulkShipments
                        (m_salesOrder,command.Output);

                    RefreshData();
                }                    
            }
        }

        void processMethod_EditValueChanged(object sender, EventArgs e)
        {
            if (processMethod.EditValue == null)
                return;

            switch (processMethod.EditValue.ToString())
            {                
                case "By LotId":
                    lotIdText.Enabled = true;
                    qtyText.Enabled = true;
                    cartLookup.Enabled = false;
                    cartLookup.EditValue = null;
                    lotIdText.Focus();
                    return;

                case "By Cart":
                    cartLookup.Enabled = true;
                    lotIdText.Enabled = false;
                    qtyText.Enabled = false;
                    cartLookup.Focus();
                    return;               
            }           
        }

        private void lotIdText_Validated(object sender, EventArgs e)
        {
            if (lotIdText.Text.Length <= 0)
                return;

            GetUnitDetails();
        }

        private void GetUnitDetails()
        {
            m_Item = null;

            var il = new InventoryLocator();               
            m_Item = il.LocateOrWarn(m_salesOrder.Session, lotIdText.Text);

            if (m_Item == null)
                return;
                
            lotDetailsText.Text = m_Item.DisplayTextDetails;
            shipButton.Enabled = true;

            // Ship the unit if it has a qty of 1
            if(m_Item.Qty == 1)
            {
                qtyText.Text = "1";
                shipButton_Click(null,null);
                return;
            }

            qtyText.Focus();

        }

        private void shipButton_Click(object sender, EventArgs e)
        {  
            if (Scout.Core.Modules.Warehouse.Shipping.Ship(m_salesOrder,
                                m_Item,
                                Int32.Parse(qtyText.Text)))
            {
                ClearFields();
                RefreshData();
            }
        }

        private void RefreshData()
        {
            m_salesOrder.ShipmentDeltas.Reload();
            expectedGrid.DataSource = m_salesOrder.ShipmentDeltas;
        }

        private void ClearFields()
        {
            lotIdText.Text = "";
            lotDetailsText.Text = "";
            qtyText.Text = "";
            shipButton.Enabled = false;
            m_Item = null;
            lotIdText.Focus();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void packlistManagerLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            PacklistMgrForm packlistForm = new PacklistMgrForm(m_salesOrder);
            packlistForm.ShowDialog();
        }

        private void hyperLinkEdit1_OpenLink(object sender, OpenLinkEventArgs e)
        {
            Export.ExportGridToFile(processedGrid, "xls");
        }

        private void cartLookup_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if(e.Button.Kind == ButtonPredefines.Redo)
            {
                LoadCartList();
            }
        }

        private void undoShipmentLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            // Guard
            if(processedView.SelectedRowsCount == 0)
                return;

            List<Shipment> selectedShipments = new List<Shipment>();
            int[] rowHandles = processedView.GetSelectedRows();

            for (int i = 0; i < rowHandles.Length; i++)
            {
                selectedShipments.Add(processedView.GetRow(rowHandles[i]) as Shipment);
            }

           Scout.Core.Modules.Warehouse
                .Shipping.UndoShipments
                (m_salesOrder.Session, selectedShipments);
                
            RefreshData();
        }

    }
}