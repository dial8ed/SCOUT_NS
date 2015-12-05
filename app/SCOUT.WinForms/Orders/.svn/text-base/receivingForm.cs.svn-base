using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms
{
    public partial class receivingForm : XtraForm
    {
        #region fields

        private IReceivingService m_receiving = Scout.Core.Service<IReceivingService>();
        private FrontController m_frontController = FrontController.GetInstance();
        private IMultiFieldIdentifier m_multiFieldIdentifier;
        private List<IMultiFieldIdentifier> m_multiIdentFieldList = new List<IMultiFieldIdentifier>();
        private Order m_order;
        private Part m_part;
        private PurchaseOrder m_purchaseOrder;        
        private XPCollection<ReceiptCondition> m_receiptConditions;
        private PartIdentType m_partIdentType;
        private ItemCustomFields m_customFields;
        private ICollection<DfileItem> m_dfileItems;
        private IUnitOfWork m_uow;
        private bool m_multiFieldScatterPostponed;

        #endregion

        #region .ctor

        public receivingForm()
        {
            InitializeComponent();
            Init();
        }

        public receivingForm(PurchaseOrder purchaseOrder)
        {
            InitializeComponent();            
            m_purchaseOrder = purchaseOrder;
            m_order = purchaseOrder.Order;
            m_uow = m_purchaseOrder.Session;
            Init();
        }

        #endregion

        #region methods

        private void Init()
        {
            serialNumberText.Enabled = false;
            quantityText.Enabled = false;
            LoadLists();
            WireEvents();
            Bind();
            LoadOrderProcessResults();
            cartLookup.Tag = ToteCommands.ToteCreate;
            LoadDfileUnits();
        }

        private void LoadDfileUnits()
        {                   
            m_dfileItems = Scout.Core.Service<IDfileService>()
                                    .Repository.GetActiveDfileItemsByIncomingOrder(m_uow, m_order.Id);

            m_uow.ReloadChangedObjects();

            dfileGrid.DataSource = m_dfileItems;

            if(m_dfileItems != null && m_dfileItems.Count > 0)
                dfileTab.Visibility = LayoutVisibility.Always;
            else 
                dfileTab.Visibility = LayoutVisibility.Never;
   
        }

        private void Bind()
        {
            purchaseOrderLabel.Text = string.Format(purchaseOrderLabel.Text, m_purchaseOrder.Order.Id);
            poLabel.Text = string.Format(poLabel.Text, m_order.PO);
            rmaLabel.Text = string.Format(rmaLabel.Text, m_order.RMA);
            otherLabel.Text = string.Format(otherLabel.Text, m_order.Other);
            siteLabel.Text = string.Format(siteLabel.Text, m_purchaseOrder.Shopfloorline.Parent.Label);
            sflLabel.Text = string.Format(sflLabel.Text, m_purchaseOrder.Shopfloorline.Label);
            domainLabel.Text = string.Format(domainLabel.Text, m_purchaseOrder.RecDomain.Label);
        }

        private void WireEvents()
        {
            multiIdentifierSelList.SelectedValueChanged += multiIdentifierSelList_SelectedValueChanged;
            multiIdentifierText.Validated += multiIdentifierText_Validated;
            multiIdentifierText.GotFocus += multiIdentifierText_GotFocus;
            multiIdentifierSelList.ButtonClick += multiIdentifierSelList_ButtonClick;
            partNumberText.Validated += partNumberText_Validated;
            partNumberText.GotFocus += delegate { partNumberText.SelectAll(); };
            cartLookup.ButtonClick += cartLookup_ButtonClick;
            cartLookup.GotFocus += cartLookup_GotFocus;
            serialNumberText.Validated += serialNumberText_Validated;
            customFieldsLayout.Leave += customFieldsLayout_Leave;            
        }

        void customFieldsLayout_Leave(object sender, EventArgs e)
        { 
            commentsText.Focus();
        }

        private void serialNumberText_Validated(object sender, EventArgs e)
        {
            if (serialNumberText.Text.Length == 0)
            {
                serialNumberText.Focus();
                return;
            }
              
            if (m_purchaseOrder.Shopfloorline.CustomFields.Count > 0)
            {
                if (!ValidCustomFields())
                {
                    customFieldsLayout.Focus();
                    return;
                }
            }

            serialNumberText.Text = serialNumberText.Text.ToUpper();
            if (batchReceiptCheck.Checked)
                Receive();
        }

        private bool ValidCustomFields()
        {
            if(m_customFields == null) return true;

            return m_customFields.RequiredFieldsAreValid(
                m_purchaseOrder.Shopfloorline.CustomFields);            
        }

        private void cartLookup_GotFocus(object sender, EventArgs e)
        {
            cartLookup.ShowPopup();
        }
        
        private void cartLookup_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                // TODO: Move to service layer                
                ToteCreateCommandArguments args =
                    new ToteCreateCommandArguments(m_purchaseOrder.Session, ToteType.Cart);

                IOutputCommand<Tote> command =
                    m_frontController
                        .RunCommand(ToteCommands.ToteCreate, args) as IOutputCommand<Tote>;
                //--->

                if (command != null && command.Output != null)
                {
                    LoadCartList();
                    cartLookup.EditValue = command.Output;
                }

                return;
            }

            if (e.Button.Kind == ButtonPredefines.Redo)
            {
                LoadCartList();
                return;
            }
        }

        // TODO: Move to service layer
        private void UpdatePartInfo()
        {
            m_part = PartService.GetPartByPartNumber(m_order.Session, partNumberText.Text);

            if (!ValidPart(m_part))
                return;

            if (!ReceivablePart(m_part))
                return;
            
            EnableReceiptEditors(true);
            LoadIdentTypeOptions(m_part);

            if(m_multiFieldScatterPostponed)
                ScatterMultiIdentifierFields(m_multiFieldIdentifier);
        }

        // TODO: Move to service layer
        private bool ReceivablePart(Part part)
        {
            if (!part.IsReceivable)
            {
                string msg =
                    String.Format("{0} is not a receivable part number.", partNumberText.Text);

                partNumberText.SelectAll();
                EnableReceiptEditors(false);
                Scout.Core.UserInteraction.Dialog.ShowMessage(msg, UserMessageType.Error);                
                partNumberText.Focus();
                return false;
            }

            return true;
        }

        private void LoadIdentTypeOptions(Part part)
        {
            m_partIdentType = 
                OrderService.GetReceivingIdentTypeFor(m_purchaseOrder, part);

            DeleteCustomFieldEditors();

            switch (m_partIdentType.Name.ToLower())
            {
                case "serialized":
                    quantityText.Text = "1";
                    serialNumberText.Enabled = true;
                    quantityText.Enabled = false;
                    serialNumberText.Focus();
                    LoadCustomFields(m_purchaseOrder.Shopfloorline.CustomFields);
                    break;

                case "nonserialized":
                    serialNumberText.Text = "";
                    serialNumberText.Enabled = false;
                    quantityText.Enabled = true;
                    quantityText.Focus();
                    batchReceiptCheck.Checked = false;
                    break;

                case "create uid":
                    quantityText.Text = "1";
                    serialNumberText.Enabled = false;
                    quantityText.Enabled = false;
                    batchReceiptCheck.Checked = false;
                    commentsText.Focus();
                    break;
            }

            quantityText.TabStop = quantityText.Enabled;
            serialNumberText.TabStop = serialNumberText.Enabled;
            trackingText.Text = m_partIdentType.Name;
            descriptionText.Text = part.Description;
        }

        // TODO: Move to service layer
        private bool ValidPart(Part part)
        {
            if (part == null)
            {
                string msg =
                    String.Format("{0} is not a valid part number.", partNumberText.Text);

                partNumberText.SelectAll();
                EnableReceiptEditors(false);
                MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                partNumberText.Focus();
                return false;
            }

            return true;
        }

        private void EnableReceiptEditors(bool enable)
        {            
            commentsText.Enabled = enable;
            receiveButton.Enabled = enable;
            serialNumberText.Enabled = enable;
            quantityText.Enabled = enable;

            if (!enable)
                partNumberText.BackColor = Color.Red;
            else
                partNumberText.BackColor = Color.White;
        }

        private void LoadOrderProcessResults()
        {
            try
            {
                expectedBinding.DataSource = m_purchaseOrder.ReceiptDeltas;
                processedBinding.DataSource = m_purchaseOrder.Receipts;
                processedGrid.DataSource = processedBinding;
                expectedGrid.DataSource = expectedBinding;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void LoadLists()
        {
            // TODO: Move to service layer
            m_multiIdentFieldList.Add(new PPIDIdentifier());
            m_multiIdentFieldList.Add(new PPID2DIdentifier());
            m_multiIdentFieldList.Add(new PPIDPNOnlyIdentifier());
            m_multiIdentFieldList.Add(new DellReceiptLpnIdentifier());
            multiIdentifierSelList.Properties.Items.AddRange(m_multiIdentFieldList);
            //--->
                       
            LoadCartList();
        }

        private void LoadCustomFields(XPCollection<CustomField> collection)
        {
            // Guard
            if(collection.Count == 0)
                return;

            m_customFields = Scout.Core.Data.CreateEntity<ItemCustomFields>(m_purchaseOrder.Session);

            customFieldsLayout.SuspendLayout();
            foreach (CustomField field in collection)
            {
                CreateCustomFieldTextBox(field);
            }            

            customFieldsLayout.ResumeLayout();
        }

        private void CreateCustomFieldTextBox(CustomField field)
        {
            TextEdit editor = new TextEdit();
            editor.Name = field.FieldName + "text";
            editor.Dock = DockStyle.Top;
            editor.EnterMoveNextControl = true;
            editor.TabStop = true;
            customFieldsLayout.AddItem(field.FieldName, editor);
            editor.Validated += editor_Validated;            
            editor.DataBindings.Add("Text", m_customFields, field.FieldName);
        }

        void editor_Validated(object sender, EventArgs e)
        {
            if(ValidCustomFields() && batchReceiptCheck.Checked)
                Receive();
        }

        private void LoadCartList()
        {
            cartLookup.Properties.DataSource = 
                Scout.Core.Service<IAreaService>().GetAllEmptyCarts(m_purchaseOrder.Session);
            
            cartLookup.Properties.DisplayMember = "Label";
            cartLookup.Properties.ValueMember = "This";
        }

        #endregion

        #region event handlers

        private void multiIdentifierText_GotFocus(object sender, EventArgs e)
        {
            multiIdentifierText.SelectAll();
        }

        private void partNumberText_Validated(object sender, EventArgs e)
        {
            partNumberText.Text = partNumberText.Text.Trim();
            partNumberText.Text = partNumberText.Text.ToUpper();

            if (partNumberText.Text.Length == 0)
            {
                partNumberText.BackColor = SystemColors.Window;
                descriptionText.Text = "";
                receiveButton.Enabled = false;
                partNumberText.Focus();
            }
            else
            {
                UpdatePartInfo();
            }
        }

        private void multiIdentifierSelList_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Undo)
            {
                multiIdentifierSelList.SelectedItem = null;
            }
        }

        private void multiIdentifierText_Validated(object sender, EventArgs e)
        {
            if (multiIdentifierText.Text.Length == 0)
                return;

            m_multiFieldIdentifier.CompleteIdentifier = multiIdentifierText.Text;
            if (m_multiFieldIdentifier.Validate())
            {
                if(m_multiFieldIdentifier.MultiFieldList["pn"] == "")
                {
                    m_multiFieldScatterPostponed = true;
                    partNumberText.Focus();
                    return;
                }

                ScatterMultiIdentifierFields(m_multiFieldIdentifier);
            }
        }

        private void ScatterMultiIdentifierFields(IMultiFieldIdentifier multiFields)
        {
            m_multiFieldScatterPostponed = false;
            serialNumberText.Text = multiFields.MultiFieldList["sn"];

            if (partNumberText.Text.Length == 0 || !partNumberText.Text.Equals(multiFields.MultiFieldList["pn"]) )
            {
                if(multiFields.MultiFieldList["pn"].Length > 0)
                    partNumberText.Text = multiFields.MultiFieldList["pn"];
            }
                
            StoreLineItemIdentifier();

            partNumberText_Validated(this, null);

            MapCustomFieldsFromMultiIdentifier();
                       
            serialNumberText.Focus();

            // Users want the serial number to be highlighted if the serial number came from
            // a pre-alert.
            if(multiFields is ICustomFieldsIdentifier)
            {
                serialNumberText.SelectAll();
                return;
            } 


            SendKeys.Send("{TAB}");
        }


        private void MapCustomFieldsFromMultiIdentifier()
        {
            if (m_multiFieldIdentifier is ICustomFieldsIdentifier && m_customFields != null)
            {
                Dictionary<string, string> source;
                source = ((ICustomFieldsIdentifier) m_multiFieldIdentifier).CustomFieldsDictionary;

                if (source.ContainsKey("DPS"))
                    m_customFields.DPS = source["DPS"];

                if (source.ContainsKey("PPID"))
                    m_customFields.PPID = source["PPID"];

                if (source.ContainsKey("Revision"))
                    m_customFields.Revision = source["Revision"];
                
            }                       
        }

        private void StoreLineItemIdentifier()
        {
            lineItemIdentifierText.Text = "";
            if (m_multiFieldIdentifier is ILineItemIdentifier)
                lineItemIdentifierText.Text = ((ILineItemIdentifier) m_multiFieldIdentifier).LineItemIdentifier;
           
        }

        private void multiIdentifierSelList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (multiIdentifierSelList.SelectedItem != null)
            {
                multiIdentifierText.Enabled = true;
                m_multiFieldIdentifier = (IMultiFieldIdentifier) multiIdentifierSelList.SelectedItem;
                multiIdentifierText.Text = "";
                multiIdentifierText.Focus();
                multiIdentifierText.SelectAll();
            }
            else
            {
                m_multiFieldIdentifier = null;
                multiIdentifierText.Enabled = false;
                multiIdentifierText.Text = "";
            }
        }

        #endregion

        // TODO: Move to service layer
        private void unReceiveLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            Receipt receipt = processedView.GetFocusedRow() as Receipt;
            if (receipt != null)
            {
                DialogResult ans;
                string delQuestion = "Are you sure you want to remove "
                                + receipt.UnitTrackingId +
                                " from this order?";

                if (Scout.Core.UserInteraction.Dialog.AskQuestion(delQuestion) == DialogResult.Yes)                
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        m_receiving.DeleteReceipt(receipt);
                        LoadOrderProcessResults();
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        private void ScatterReceipt(Receipt receipt)
        {
            serialNumberText.Text = receipt.SerialNumber;
            partNumberText.Text = receipt.PartNumber;
            quantityText.Text = receipt.Qty.ToString();            
            commentsText.Text = receipt.Comments;
            partNumberText_Validated(null, null);
        }
        
        private ReceiptFacts GatherFacts()
        {
            ReceiptFacts facts = new ReceiptFacts();
            facts.Session = m_purchaseOrder.Session;
            facts.SerialNumber = serialNumberText.Text;
            facts.Qty = Int32.Parse(quantityText.Text);            
            facts.Comments = commentsText.Text;
            facts.Part = m_part;
            facts.ReceivingCart = (Tote)cartLookup.EditValue;
            facts.RoutingRequired = m_purchaseOrder.RoutingRequired;
            facts.PurchaseOrder = m_purchaseOrder;
            facts.PurchaseLineItem = m_purchaseOrder.GetLineByPart(m_part);
            facts.LineItemIdentifier = lineItemIdentifierText.Text;
            facts.SourceType = m_purchaseOrder.SourceType ?? "PURREC";
            
            // Assign custom fields
            if (m_customFields != null)
                facts.CustomFields = m_customFields;

            return facts;
        }

        private void receiveButton_Click(object sender, EventArgs e)
        {
            Receive();
        }

        private void Receive()
        {
            ReceiptFacts facts = GatherFacts();
            
            if (m_receiving.ReceiveUnit(facts))
            {                                                                         
                m_purchaseOrder.ReceiptDeltas.Reload();
                expectedGrid.DataSource = m_purchaseOrder.ReceiptDeltas;
                    
                if (batchReceiptCheck.Checked)
                    BatchClear();
                else
                    Clear();                
            }

            LoadDfileUnits();

        }

        private void BatchClear()
        {            
            receiveButton.Enabled = false;            
            serialNumberText.Text = "";
            multiIdentifierText.Text = "";
            
            ClearCustomFields();

            partNumberText_Validated(null, null);
            
            if (multiIdentifierSelList.SelectedIndex > -1)
            {
                multiIdentifierText.Focus();
            }
            else
                serialNumberText.Focus();
        }

        private void Clear()
        {            
            m_part = null;
            trackingText.Text = "";
            descriptionText.Text = "";
            serialNumberText.Text = "";
            quantityText.Text = "1";
            commentsText.Text = "";
            receiveButton.Enabled = false;
            multiIdentifierText.Text = "";
            partNumberText.Text = "";
            
            if (multiIdentifierSelList.SelectedIndex > -1)
            {
                multiIdentifierText.Focus();
            }
            else
            {
                partNumberText.SelectAll();
                partNumberText.Focus();
            }

            ClearCustomFields();
        }

        private void DeleteCustomFieldEditors()
        {
            customFieldsLayout.Clear();
        }

        private void ClearCustomFields()
        {
            if(m_purchaseOrder.Shopfloorline.CustomFields.Count > 0)
            {
                DeleteCustomFieldEditors();                
            }           
        }

        private void exportLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            processedGrid.ShowPrintPreview();
        }

        private void printLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            Receipt receipt = processedView.GetFocusedRow() as Receipt;
            if (receipt != null)
            {
                m_receiving.PrintReceiveLabel(receipt);
            }
        }

        private void editReceiptLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            Receipt receipt = processedView.GetFocusedRow() as Receipt;
            if (receipt != null)
            {                
                ScatterReceipt(receipt);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (batchReceiptCheck.Checked)
                BatchClear();
            else
                Clear();
        }

        private void loadDfileItemForReceiving_Click(object sender, EventArgs e)
        {
            DfileItem item = dfileView.GetFocusedRow() as DfileItem;
            if(item != null)
            {
                if(item.Status == DfileStatus.Open)
                {
                    Scout.Core.UserInteraction.Dialog.ShowMessage
                        ("This Dfile item has to be resolved before it can be received.", UserMessageType.Information);

                    return;
                }

                LoadDfileItemForReceipt(item);
            }
        }

        private void LoadDfileItemForReceipt(DfileItem item)
        {
            serialNumberText.Text = item.SerialNumber;
            partNumberText.Text = item.Part.PartNumber;
            quantityText.Text = "1";            
            commentsText.Text = item.Comments;
            partNumberText_Validated(null, null);
            serialNumberText_Validated(null,null);
        }

        private void refreshDfileButton_Click(object sender, EventArgs e)
        {
            LoadDfileUnits();
        }
    }
}