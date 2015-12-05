using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SCOUT.Core.Data;

namespace SCOUT.WinForms
{
    public partial class SalesWaybillForm : Form
    {
        #region Fields

        private DataGridViewRow currentRow;

        #endregion
        
        #region .ctor

        public SalesWaybillForm()
        {
            InitializeComponent();
            Clear();
        }

        #endregion

        #region Methods

        private void LoadDetails(string packlistId)
        {
            SqlParameter[] sqlParams;
            sqlParams = new SqlParameter[]{new SqlParameter("@PacklistID",packlistId)};
            DataTable dt = Tasks.CreateTableFromSproc("usp_GetPacklistIdDetails", sqlParams);

            BindResults(dt);
        }

        private void BindResults(DataTable table)
        {
            if ( table.Rows.Count==0 )
            {
		InfoBox ib = new InfoBox();

		ib.Show("No results found.");

                return;
            }

            waybillGrid.DataSource = table;
        }

        private void DisplayItem(DataGridViewRow dr)
        {
            packlistText.Text = dr.Cells["PACKLISTID"].Value.ToString();
            waybillText.Text = dr.Cells["WAYBILLID"].Value.ToString();

            UpdateBtn.Enabled = true;
            waybillText.Focus();
        }

        #endregion

        #region Form Events

        void packlistText_Validated(object sender, System.EventArgs e)
        {
            if ( packlistText.Text.Length > 0 )
            {
                LoadDetails(packlistText.Text);
            }
        }

        void waybillGrid_DoubleClick(object sender, System.EventArgs e)
        {
            currentRow = waybillGrid.SelectedRows[0];

            if (currentRow != null)
            {
                DisplayItem(currentRow);                
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            string oldAWB;
            string newAWB;
            string packlistID;

            oldAWB = currentRow.Cells["WAYBILLID"].Value.ToString();
            newAWB = waybillText.Text;
            packlistID = packlistText.Text;

            StoredProc proc = new StoredProc("usp_UpdatePacklistAWB");
            proc.Parameters.AddWithValue("@OldAWB", oldAWB);
            proc.Parameters.AddWithValue("@NewAWB", newAWB);
            proc.Parameters.AddWithValue("@PacklistID", packlistID);            
            proc.Execute();   

            LoadDetails(packlistText.Text);

            UpdateBtn.Enabled = false;
                                            
        }

        #endregion

        private void clearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            UpdateBtn.Enabled = false;
            packlistText.Text = "";
            waybillText.Text = "";
            waybillGrid.DataSource = null;
            packlistText.Focus();
        }
    }
}
