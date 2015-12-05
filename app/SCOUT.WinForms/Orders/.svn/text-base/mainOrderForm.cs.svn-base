using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using SCOUT.Core.Data;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;
using SCOUT.WinForms.Orders;
using Padding=DevExpress.XtraLayout.Utils.Padding;

namespace SCOUT.WinForms
{
    public partial class mainOrderForm : DevExpress.XtraEditors.XtraForm
    {
        #region fields

        private Order m_order;
        private List<IValidationControl> m_validationControls;

        #endregion

        #region .ctor

        public mainOrderForm()
        {
            InitializeComponent();
            Setup();
            Bind();
        }

        public mainOrderForm(Order order)
        {
            InitializeComponent();
            m_order = order;
            Setup();
            SetupTemplateMode(order);
        try
        {
            Bind();
        }
        catch (Exception ex)
        {

            throw ex;
            MessageBox.Show(ex.Message);
        }
        }

        private void SetupTemplateMode(Order order)
        {
            if (!order.IsTemplate)
                return;

            saveAndNewButton.Visibility = BarItemVisibility.Never;
            copyDetailsButton.Visibility = BarItemVisibility.Never;
            copyTopLevelRollup.Visibility = BarItemVisibility.Never;
            poLayout.Visibility = LayoutVisibility.Never;
            rmaLayout.Visibility = LayoutVisibility.Never;
            otherLayout.Text = "Template Name";
        }

        private void Bind()
        {
            rmaText.DataBindings.Add("Text", m_order, "RMA");
            poText.DataBindings.Add("Text", m_order, "PO");
            otherText.DataBindings.Add("Text", m_order, "Other");            
            LoadOrderTypeModules(m_order.OrderType);
            Text = string.Format("Order Id: {0}", m_order.Id);
        }

        private void Setup()
        {
            Closing += mainOrderForm_Closing;
        }

        private void mainOrderForm_Closing(object sender, CancelEventArgs e)
        {
            if (m_order.HasDirtyContracts())
            {
                if (
                    MessageBox.Show("This order has un-saved changes. Would you like to save now?", "SCOUT",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!Save())
                        e.Cancel = true;
                }
            }
        }

        #endregion

        #region eventss

        private bool Save()
        {
            Focus();

            // Check if another order already exists with the same order identifiers            
            Order existingOrder = OrderService
                    .OrderWithIdentifiersExists(
                    m_order.RMA, 
                    m_order.PO, 
                    m_order.Other,
                    m_order.Id);

            if (existingOrder != null)
            {
                if (MessageBox.Show(
                        "Another order exists with these identifiers. Would you like to cancel saving and view this order?",
                        Application.ProductName,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mainOrderForm form = new mainOrderForm(existingOrder);
                    form.WindowState = FormWindowState.Maximized;
                    form.MdiParent = MdiParent;
                    form.Show();
                    form.Focus();

                    return false;
                }
            }

            if (!EditorsAreValid() || !String.IsNullOrEmpty(m_order.Error))
            {
                ShowContractErrors();
                return false;
            }

            try
            {
                Scout.Core.Data.Save(m_order.Session);
                return true;
            }
            catch (Exception ex)
            {
                InfoBox ib = new InfoBox();
                ib.Icon = MessageBoxIcon.Error;
                ib.Show("Error saving order:\r{0}", ex.Message);
                return false;
            }
        }

        private void ShowContractErrors()
        {
            InfoBox infoBox = new InfoBox();
            infoBox.Buttons = MessageBoxButtons.OK;
            infoBox.Icon = MessageBoxIcon.Error;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(m_order.Error);

            foreach (IValidationControl control in m_validationControls)
            {
                stringBuilder.Append(control.Error());
            }
            

            infoBox.Show("{0}", stringBuilder.ToString());
        }

        private bool EditorsAreValid()
        {
            foreach (IValidationControl validationControl in m_validationControls)
            {
                if (validationControl.IsValid() == false)
                    return false;
            }
            return true;
        }

        private void VerifySaveClose()
        {
            InfoBox ib = new InfoBox();
            DialogResult ans;           
            ib.Buttons = MessageBoxButtons.YesNo;

            if (m_order.IsTemplate)
                ans = ib.Show(TemplateSavedMessage());
            else
                ans = ib.Show(OrderSavedMessage());

            if (ans == DialogResult.Yes)
                Close();
        }

        private string OrderSavedMessage()
        {
            Text = "Order " + m_order.Id;

            return String.Format("The order {0} has been saved successfully.\n" +
                                 "Do you wish to close this window?",
                                 m_order.Id);
        }

        private string TemplateSavedMessage()
        {
            return String.Format("The template {0} has been saved successfully.\n" +
                                 "Do you wish to close this window?",
                                 m_order.Other);

        }

        #endregion

        #region methods

        private void LoadOrderTypeModules(OrderType orderType)
        {
            contractsControlGroup.TabPages.Clear();
            m_validationControls = new List<IValidationControl>();

            List<Type> contractTypes = m_order.ContractTypes;

            if (contractTypes.Contains(typeof (PurchaseOrder)))
            {
                foreach (ContractBase contract in m_order.Contracts)
                {
                    if (contract.GetType() == typeof (PurchaseOrder))
                    {
                        PurchaseOrderControl poControl = new PurchaseOrderControl((PurchaseOrder) contract);
                        m_validationControls.Add(poControl);
                        CreateTabPage(poControl, "Purchase Order");
                    }
                }
            }

            if (contractTypes.Contains(typeof (SalesOrder)))
            {
                foreach (ContractBase contract in m_order.Contracts)
                {
                    if (contract.GetType() == typeof (SalesOrder))
                    {
                        SalesOrderControl soControl = new SalesOrderControl((SalesOrder) contract);
                        m_validationControls.Add(soControl);
                        CreateTabPage(soControl, "Sales Order");
                    }
                }
            }

            if (contractsControlGroup.TabPages.Count > 0)
                contractsControlGroup.SelectedTabPageIndex = 0;
        }

        private void CreateTabPage(Control control, string text)
        {
            // new tab page control group
            LayoutControlGroup layoutControlGroup = new LayoutControlGroup();
            layoutControlGroup.Text = text;

            // new layout item for the tabpage
            LayoutControlItem layoutControlItem = new LayoutControlItem(layoutControlGroup);
            layoutControlItem.Control = control;
            layoutControlItem.TextVisible = false;
            layoutControlItem.FillControlToClientArea = true;
            layoutControlItem.Name = text;
            layoutControlItem.Padding = new Padding(1);

            // add the layout item to the tab page
            layoutControlGroup.Items.AddRange(new BaseLayoutItem[] {layoutControlItem});

            // add the new tab page to the main layout
            contractsControlGroup.TabPages.AddRange(new BaseLayoutItem[] {layoutControlGroup});
        }

        #endregion

        private void saveButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
                VerifySaveClose();
        }

        private void copyItemsButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SalesOrder salesOrder = (SalesOrder) m_order.GetContract<SalesOrder>();
            PurchaseOrder purchaseOrder = (PurchaseOrder) m_order.GetContract<PurchaseOrder>();

            if (salesOrder == null | purchaseOrder == null)
            {
                MessageBox.Show("This order does not contain a sales order and a purchase order",
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (salesOrder.CartItems.Count > 0)
            {
                purchaseOrder.CopyItemsFromSalesOrder(salesOrder);
            }
            else
            {
                salesOrder.CopyItemsFromPurchaseOrder(purchaseOrder);
            }
        }

        private void closeButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void saveAndNewButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                VerifySaveClose();

                if (m_order.CreatedFromTemplate)
                    FrontController.GetInstance().RunCommand(OrdersCommands.New_FromTemplate);
                else                
                    ViewLoader.Instance().CreateFormWithArgs<mainOrderForm>(true,
                            OrderService.CreateOrderAsArg(m_order.OrderType));                
            }
        }

        private void copyTopLevelRollup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SalesOrder salesOrder = (SalesOrder) m_order.GetContract<SalesOrder>();
            PurchaseOrder purchaseOrder = (PurchaseOrder) m_order.GetContract<PurchaseOrder>();

            if (salesOrder == null | purchaseOrder == null)
            {
                MessageBox.Show("This order does not contain a sales order and a purchase order",
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            salesOrder.RollupLineItemsFromPurchaseOrder(purchaseOrder);            
        }
    }
}