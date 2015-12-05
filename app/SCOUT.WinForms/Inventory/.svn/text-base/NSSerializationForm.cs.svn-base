using System;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using Inventory.UI;
using SCOUT.Core.Data;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.Inventory
{
    public partial class NSSerializationForm : XtraForm
    {
        private readonly string m_lotId;
        private InventoryItem m_inventoryItem;
        private XPCollection<NSLotIdSerial> m_serials;
        private IUnitOfWork m_session;

        public NSSerializationForm(string lotId)
        {
            InitializeComponent();
            m_lotId = lotId;

            m_session = Scout.Core.Data.GetUnitOfWork();
            Bind();
            WireEvents();
        }

        private void WireEvents()
        {
            snText.Validated += snText_Validated;
            snText.EnterMoveNextControl = true;
            revText.Validated += revText_Validated;
            revText.EnterMoveNextControl = true;
            Closing += NSSerializationForm_Closing;
            snGrid.EmbeddedNavigator.ButtonClick += EmbeddedNavigator_ButtonClick;
        }

        private void EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if(e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                NSLotIdSerial nsUnit = snView.GetFocusedRow() as NSLotIdSerial;
                if(nsUnit != null)
                {
                    if(Scout.Core.UserInteraction.Dialog.AskQuestion
                        ("Do you really want to delete " + nsUnit.SerialNumber + " ?") == DialogResult.Yes)
                    {
                        e.Handled = false;
                        RefreshCounts();
                        snText.Focus();
                        return;
                    }
                }

                e.Handled = true;
                  
            }
        }

        private void revText_Validated(object sender, EventArgs e)
        {
            revText.Text = revText.Text.ToUpper();
            ProcessScan(snText.Text);
        }

        private void NSSerializationForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                if (m_session.GetObjectsToDelete().Count > 0)
                {                                       
                    m_session.Commit();
                    m_session = null;
                }            
        }

        private void snText_Validated(object sender, EventArgs e)
        {
            if (snText.Text.Length == 0)
                return;

            FormatSN();
        }

        private void FormatSN()
        {
            snText.Text = snText.Text.ToUpper();
            if (new PPID2DValidator(snText.Text).Validate())
            {
                PPID2DParser parser = new PPID2DParser(snText.Text);
                snText.Text = parser.PPID;
                revText.Text = parser.Revision;
                ProcessScan(snText.Text);
            }
        }

        private void ProcessScan(string sn)
        {
            if (!Valid(sn)) return;
            ShowWarnings();
            SaveNewSerial(sn);
            LoadSerials();
            ClearAndInit();
        }

        private bool Valid(string sn)
        {
            if (IsNull())
            {
                ErrorInit();
                return false;
            }

            if (AlreadyExistsForLot(sn))
            {
                ErrorInit();
                return false;
            }

            if (AlreadyExistsInDiffLot(sn))
            {
                ErrorInit();
                return false;
            }

            if (ExceedsExpected())
            {
                ErrorInit();
                return false;
            }

            return true;
        }

        private void ShowWarnings()
        {
            string msg = CheckInputForWarnings(snText.Text);

            if (msg.Length > 0)
            {
                StubbornMessageBox msgBox = new StubbornMessageBox(msg, MessageBoxButtons.OK);
                msgBox.ShowDialog();
            }
        }

        private bool IsNull()
        {
            if (snText.Text.Length == 0)
            {
                MessageBox.Show("Serial number is required.", Application.ProductName, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return true;
            }

            return false;
        }

        private bool ExceedsExpected()
        {
            if (expectedText.Text == "0")
            {
                MessageBox.Show("There are no more expected serial numbers for this lot.",
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return true;
            }

            return false;
        }


        private string CheckInputForWarnings(string ppid)
        {
            StringBuilder msg = new StringBuilder();
           
            if (new PPIDValidator(ppid).Validate())
            {
                PPIDParser parser = new PPIDParser(ppid);             
                if (!parser.PN.Equals(m_inventoryItem.PartNumber))
                {
                    msg.AppendLine(
                        "The part number contained in the PPID does not match the part number of the associated inventory item");
                    msg.AppendLine();                        
                }

                Part part = PartService.GetPartByPartNumber(m_session, parser.PN);
                if (part == null)
                {
                    msg.AppendLine("The part number extracted from the PPID is not a valid part number.");
                    msg.AppendLine();
                }

                if (m_inventoryItem.PurchaseOrder == null)
                {
                    msg.AppendLine("This inventory item is not associated with a purchase order.");
                    msg.AppendLine();             
                } 
                else
                {
                    if (m_inventoryItem.PurchaseOrder.LineItemByPart(part) == null)
                    {
                        msg.AppendLine("The part number extracted from the PPID does not match a part number from the purchase order.");
                        msg.AppendLine();
                    }  
                }

                if(Scout.Core.Service<IInventoryService>()
                    .GetNSLotBySerialNumber(Scout.Core.Data.GetUnitOfWork(), ppid) != null)
                {
                    msg.AppendLine("This PPID is a multi-return");
                    msg.AppendLine();
                }

            }

            if(revText.Text.Contains("X"))
            {
                msg.AppendLine("This unit is a X revision");
                msg.AppendLine();
            }

            return msg.ToString();
        }

        private void ErrorInit()
        {
            snText.SelectAll();
            snText.Focus();
        }

        private void ClearAndInit()
        {
            snText.Text = "";
            revText.Text = "";
            snText.Focus();
        }

        private void SaveNewSerial(string sn)
        {
            NSLotIdSerial nsLotIdSerial = Scout.Core.Data.CreateEntity<NSLotIdSerial>(m_session);
            
            nsLotIdSerial.UserName = SCOUT.Core.Security.UserSecurity.CurrentUser.Login;
            nsLotIdSerial.TimeStamp = DateTime.Now;
            nsLotIdSerial.LotId = m_lotId;
            nsLotIdSerial.SerialNumber = sn;
            nsLotIdSerial.Revision = revText.Text;

            Scout.Core.Data.Save(m_session);
            
        }

        private bool AlreadyExistsForLot(string sn)
        {
            BinaryOperator lotFilter = new BinaryOperator("LotId", m_lotId);
            BinaryOperator snFilter = new BinaryOperator("SerialNumber", sn);

            GroupOperator groupOperator =
                new GroupOperator(new CriteriaOperator[] {lotFilter, snFilter});

            NSLotIdSerial nsLotIdSerial =
                m_session.FindObject<NSLotIdSerial>(groupOperator);

            if (nsLotIdSerial != null)
            {
                MessageBox.Show("This sn already exists for this lot.", Application.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return true;
            }

            return false;
        }

        private bool AlreadyExistsInDiffLot(string sn)
        {
            BinaryOperator lotFilter = new BinaryOperator("LotId", m_lotId, BinaryOperatorType.NotEqual);
            BinaryOperator snFilter = new BinaryOperator("SerialNumber", sn);

            GroupOperator groupOperator =
                new GroupOperator(new CriteriaOperator[] {lotFilter, snFilter});

            NSLotIdSerial nsLotIdSerial =
                m_session.FindObject<NSLotIdSerial>(groupOperator);

            if (nsLotIdSerial != null)
            {
                // Check if the lot is still in inventory
                if (Scout.Core.Service<IInventoryService>().GetItemById
                    (m_session, nsLotIdSerial.LotId) != null)
                {
                    MessageBox.Show("This sn already exists for a different lot.", Application.ProductName,
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return true;
                }
            }

            return false;
        }

        private void Bind()
        {
            lotIdText.Text = m_lotId;
            m_inventoryItem = m_session.GetObjectByKey<InventoryItem>(m_lotId);
            LoadSerials();
            m_serials.CollectionChanged += m_serials_CollectionChanged;
        }

        private void m_serials_CollectionChanged(object sender, XPCollectionChangedEventArgs e)
        {
            RefreshCounts();
        }

        private void RefreshCounts()
        {
            totalText.Text = m_serials.Count.ToString();
            expectedText.Text = (m_inventoryItem.Qty - m_serials.Count).ToString();  
        }

        private void LoadSerials()
        {
            BinaryOperator filterCriteria =
                new BinaryOperator("LotId", m_lotId);

            m_serials = new XPCollection<NSLotIdSerial>(
                m_session as XpoUnitOfWork,
                filterCriteria);

            m_serials.DeleteObjectOnRemove = true;
            snGrid.DataSource = m_serials;
            m_serials_CollectionChanged(null, null);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAndInit();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ProcessScan(snText.Text);
        }

        private void exportExcelLink_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            Export.ExportGridToFile(snGrid,"xls");
        }
    }
}