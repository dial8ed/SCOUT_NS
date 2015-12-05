using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SCOUT.Core;
using SCOUT.Core.Data;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.Inventory
{
    public partial class InventoryTransactionForm : XtraForm
    {
        private readonly IUnitOfWork m_session;
        private Shopfloorline m_shopfloorline;
        private TransactionSpecification m_spec;
        private string m_transRef;
        private TransactionType m_transType;

        public InventoryTransactionForm()
        {
            InitializeComponent();
            m_session = Scout.Core.Data.GetUnitOfWork();
            InitLists();
            WireEvents();
            Setup();
        }


        private bool ProgramIsRequired { get; set; }


        private void WireEvents()
        {
            sflSelList.SelectedValueChanged += sflSelList_SelectedValueChanged;
            transferTypeSelList.SelectedValueChanged += transferTypeSelList_SelectedValueChanged;
            sourceSelList.SelectedValueChanged += sourceSelList_SelectedValueChanged;
            destinationSelList.SelectedValueChanged += destinationSelList_SelectedValueChanged;
        }

        void destinationSelList_SelectedValueChanged(object sender, EventArgs e)
        {
            if(destinationSelList.EditValue != null)
            {
                if(m_spec is ShopfloorlineTransactionSpecification)
                {
                    Domain d = destinationSelList.EditValue as Domain;
                    if (d == null)
                        return;

                    ProgramIsRequired = d.Parent.IsProgramRequired;

                    if(ProgramIsRequired)
                    {
                        programSelList.Properties.ReadOnly = false;
                        programSelList.Properties.DataSource = d.Parent.ProgramList;
                        return;
                    }

                    programSelList.Properties.ReadOnly = true;
                    programSelList.Properties.DataSource = null;

                }
            }         
        }


        private void sourceSelList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (m_spec == null)
                return;

            var area = sourceSelList.EditValue as IArea;
            if (area == null)
                return;

            m_spec.SourceArea = area;

            if (m_spec.ReloadDestinationsOnSourceChange)
            {
                LoadDestinations(m_spec);
            }
        }

        private void sflSelList_SelectedValueChanged(object sender, EventArgs e)
        {
            m_shopfloorline = sflSelList.SelectedItem as Shopfloorline;
            transferTypeSelList.EditValue = null;
            sourceSelList.EditValue = null;
            destinationSelList.EditValue = null;
            sourceSelList.Properties.Items.Clear();
            destinationSelList.Properties.Items.Clear();
        }

        private void transferTypeSelList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (m_shopfloorline == null)
            {
                MessageBox.Show(
                    "Choose a shopfloorline before selecting the type of " +
                    "transaction",
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            m_transType = transferTypeSelList.EditValue as TransactionType;

            m_spec = Scout.Core.Service<ITransactionService>()
                .GetTransactionSpecificationFor(m_transType, m_shopfloorline);

            if (m_spec != null)
            {
                InitTransactionSpec(m_spec);
            }
        }

        private void InitTransactionSpec(TransactionSpecification ts)
        {
            sourceLayout.Text = ts.SourceName;
            destinationLayout.Text = ts.DestinationName;
            LoadSources(ts);
            LoadDestinations(ts);

            sourceSelList.EditValue = ts.SourceArea;
            destinationSelList.EditValue = ts.DestinationArea;

            transactionGrid.DataSource = Scout.Core.Service<ITransactionService>()
                .GetTransactionsByRef(m_session, m_transRef);

            lotIdText.Focus();
                       
        }

        private void LoadSources(TransactionSpecification transaction)
        {
            // Clear and load source areas
            sourceSelList.Properties.Items.Clear();
            sourceSelList.EditValue = null;
            if (transaction.SourceAreas != null)
            {
                sourceSelList.Properties.Items.AddRange(transaction.SourceAreas);
            }
        }

        private void LoadDestinations(TransactionSpecification transaction)
        {
            // Clear and load destination areas
            destinationSelList.Properties.Items.Clear();
            destinationSelList.EditValue = null;
            if (transaction.DestinationAreas != null)
            {
                destinationSelList.Properties.Items.AddRange(transaction.DestinationAreas);
            }
        }

        private void InitLists()
        {
            try
            {
                ICollection<TransactionType> transTypes =
                    Scout.Core.Service<ITransactionService>().GetTransactionTypes();

                ICollection<Shopfloorline> shopfloorlines =
                    Scout.Core.Service<IAreaService>().GetAllShopfloorlines(m_session);

                transferTypeSelList.Properties
                    .Items.AddRange(Collections.ToArray(transTypes));

                sflSelList.Properties
                    .Items.AddRange(Collections.ToArray(shopfloorlines));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lotIdText_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lotIdText.Text)) return;

            InventoryItem item =
                new InventoryLocator().LocateOrWarn(m_session, lotIdText.Text);


            if (item != null)
            {
                m_spec.Item = item;
                Transfer();
            }
        }

        private void EnableEditors(bool enable)
        {
            commentsText.Enabled = enable;
            lotIdText.Enabled = enable;
            lotDetailsText.Enabled = enable;
            //transferButton.Enabled = false;
        }

        private void EnableHeader(bool enable)
        {
            lockTransferButton.Enabled = enable;
            sflSelList.Enabled = enable;
            transferTypeSelList.Enabled = enable;
            sourceSelList.Enabled = enable;
            destinationSelList.Enabled = enable;
            programSelList.Enabled = enable;

        }

        private void lockTransferButton_Click(object sender, EventArgs e)
        {
            if (HeaderInfoIsValid())
            {
                EnableHeader(false);
                EnableEditors(true);
            }
            else
            {
                string msg =
                    string.Format(
                        "{0}, {1}, {2}, and {3} must be selected before locking the header",
                        "Shopfloorline", "Transaction type", "Source", "Destination");

                MessageBox.Show(
                    msg,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }


        private bool HeaderInfoIsValid()
        {
            bool rval = false;

            rval =  (transferTypeSelList.SelectedItem != null &&
                    sflSelList.SelectedItem != null &&
                    sourceSelList.SelectedItem != null &&
                    destinationSelList.SelectedItem != null &&
                    (ProgramIsRequired == false || programSelList.EditValue != null));

            return rval;
           
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            Transfer();
        }

        private void Transfer()
        {
            GatherTransaction();
            if (TransferIsValid())
            {
                if (Scout.Core.Service<ITransactionService>().SaveTransaction(m_spec))
                    Init();
            }
        }

        private void Init()
        {
            ClearFields();
            InitTransactionSpec(m_spec);
        }

        private void GatherTransaction()
        {
            m_spec.Comments = commentsText.Text;
            m_spec.DestinationArea = destinationSelList.EditValue as IArea;
            m_spec.SourceArea = sourceSelList.EditValue as IArea;
            m_spec.TransactionReference = m_transRef;

            if (ProgramIsRequired)
                m_spec.Item.ShopfloorProgram = programSelList.EditValue.ToString();

        }

        private void ClearFields()
        {
            lotDetailsText.Text = "";
            lotIdText.Text = "";
            lotIdText.Focus();
            sourceLayout.Text = ".";
            destinationLayout.Text = ".";
        }

        private void Setup()
        {
            m_transRef = Guid.NewGuid().ToString();
            EnableHeader(true);
            EnableEditors(false);
            transIdText.Text = m_transRef;
            programSelList.Properties.DataSource = null;
            ClearFields();
        }

        private void InitNewBatch()
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<InventoryTransactionForm>(true, null);
            Close();
        }

        private bool TransferIsValid()
        {
            string msg = "";

            if (lotIdText.Text.Length <= 0)
            {
                return false;
            }

            if (m_spec.DestinationArea == null)
            {
                msg = "Destination area is required.";
                ShowMessage(msg);
                return false;
            }

            if (m_spec.SourceArea == null)
            {
                msg = "Source area is required.";
                ShowMessage(msg);
                return false;
            }

            if (m_spec.SourceArea.Id == m_spec.DestinationArea.Id)
            {
                msg = "Source area and destination area cannot be the same.";
                ShowMessage(msg);
                return false;
            }

            if (m_spec.Item == null)
            {
                msg = "Transaction is missing a valid unit to transfer";
                ShowMessage(msg);
                return false;
            }

            if (m_spec.SourceArea.GetType() == typeof (Domain))
            {
                if ((m_spec.Item.Domain.Id != m_spec.SourceArea.Id))
                {
                    msg =
                        string.Format("LotId: {0} is not at domain: {1}", m_spec.Item.LotId,
                                      m_spec.SourceArea.Label);
                    ShowMessage(msg);
                    return false;
                }
            }
           
            if (m_spec.SourceArea.GetType() == typeof (Tote))
            {
                if (m_spec.Item.Tote == null || (!m_spec.Item.Tote.Equals(m_spec.SourceArea)))
                {
                    msg =
                        string.Format("LotId: {0} is not in tote: {1}", m_spec.Item.LotId,
                                      m_spec.SourceArea.Label);
                    ShowMessage(msg);
                    return false;
                }
            }

            if (m_spec.Item.Hold != null)
            {
                msg = "Unit is on hold and cannot be transacted.";
                ShowMessage(msg);
                return false;
            }

            msg = m_spec.GetErrors();
            if (!String.IsNullOrEmpty(msg))
            {
                ShowMessage(msg);
                return false;
            }
            
            return true;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(
                msg,
                Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void newBatchButton_Click(object sender, EventArgs e)
        {
            InitNewBatch();
        }

        private void printPreviewButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            transactionGrid.ShowPrintPreview();
        }
    }
}