using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using SCOUT.WinForms.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Inventory
{
    public partial class ToteContentsSelectorForm : DevExpress.XtraEditors.XtraForm
    {
        private Tote m_tote;
        private ToteContentsTransferCommandArguments m_args;

        public ToteContentsSelectorForm(ToteContentsTransferCommandArguments args) 
        {
            m_args = args;
            m_tote = m_args.CurrentTote;
            InitializeComponent();
            Bind();
            WireEvents();
        }

        private void WireEvents()
        {
            contentsView.KeyPress += contentsView_KeyPress;
            lotIdText.Validated += lotIdText_Validated;
        }

        void lotIdText_Validated(object sender, EventArgs e)
        {
            lotIdText.Text = lotIdText.Text.ToUpper();
            LocateInventoryItem();
        }

        private void LocateInventoryItem()
        {
            if(string.IsNullOrEmpty(lotIdText.Text))
                return;

            ColumnView view = contentsGrid.MainView as ColumnView;

            int rowHandle = 0;
            GridColumn column = view.Columns["SerialNumber"];

            rowHandle = view.LocateByValue(rowHandle, column, lotIdText.Text);

            if (rowHandle == GridControl.InvalidRowHandle)
            {
                MessageBox.Show("SN not found", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AddItemToTransferBucket(rowHandle);
            lotIdText.SelectAll();
            lotIdText.Focus();
        }

        private void AddItemToTransferBucket(int handle)
        {
            InventoryItem item = contentsView.GetRow(handle) as InventoryItem;
            if(item != null)
            {
                AddItemToTransfer(item); 
            }
        }

        void contentsView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {                                
                InventoryItem item = contentsView.GetFocusedRow() as InventoryItem;
                if (item != null)
                {
                    AddItemToTransfer(item);
                }
            }
        }

        private void AddItemToTransfer(InventoryItem item)
        {
            m_args.AddItemToMove(item);
            bucketGrid.DataSource = m_args.ItemsToMove;
            bucketGrid.RefreshDataSource();
        }
      
        private void Bind()
        {
            contentsGrid.DataBindings.Add("DataSource", m_tote,"Contents");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            m_args.ItemsToMove.Clear();
            Close();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            LocateInventoryItem();
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            contentsView.SelectAll();
            int[] rowHandles = contentsView.GetSelectedRows();

            for (int i = 0; i < rowHandles.Length; i++)
            {
                AddItemToTransferBucket(i);                
            }
        }
    }
}