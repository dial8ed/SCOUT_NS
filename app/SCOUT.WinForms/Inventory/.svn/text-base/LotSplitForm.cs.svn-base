using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Inventory
{
    public partial class LotSplitForm : DevExpress.XtraEditors.XtraForm
    {
	#region Member Variables

	private LotSplitAction m_lotSplit = new LotSplitAction();

	#endregion

	#region Constructor

	public LotSplitForm()
	{
	    InitializeComponent();

	    InitBindings();
	    ClearLotDetails();
	}

	#endregion

	#region Utility

	private void InitBindings()
	{
	    reasonEdit.DataBindings.Add("EditValue", m_lotSplit, "Reason");
	    qtyEdit.DataBindings.Add("EditValue", m_lotSplit, "Quantity");
	}

	private void UpdateLotInfo()
	{
	    ClearLotDetails();

	    if (lotEdit.EditValue == null)
		return;

	    try
	    {
		m_lotSplit.StockLot =
		    StockLot.GetStockLot(lotEdit.EditValue.ToString());

		SetLotDetails();
	    }
	    catch (Exception ex)
	    {
		InfoBox ib = new InfoBox();

		ib.Icon = MessageBoxIcon.Error;
		ib.Show("Error updating Lot details:\r{0}",
		    ex.Message);
	    }
	}

	private void ClearLotDetails()
	{
	    qtyDisp.EditValue = null;
	    qtyEdit.Enabled = false;

	    m_lotSplit.StockLot = null;
	}

	private void SetLotDetails()
	{
	    if (m_lotSplit.StockLot != null)
	    {
		qtyDisp.EditValue = m_lotSplit.StockLot.Quantity;
		qtyEdit.Properties.MaxValue = m_lotSplit.StockLot.Quantity - 1;

		qtyEdit.Enabled = true;
	    }
	    else
	    {
		InfoBox ib = new InfoBox();

		ib.Icon = MessageBoxIcon.Error;
		ib.Show(
		    "Lot id \"{0}\" could not be found.",
		    lotEdit.Text);
	    }
	}

	private bool ValidSplit()
	{
	    SCOUT.Core.Data.BrokenRules br = m_lotSplit.GetBrokenRules();

	    if (br.Count > 0)
	    {
		InfoBox ib = new InfoBox();

		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < br.Count; ++i)
		{
		    sb.Append("- ");
		    sb.Append(br[i].Description);
		    sb.Append(Environment.NewLine);
		}

		ib.Show("Invalid split:\r{0}",
		    sb.ToString());

		return false;
	    }

	    return true;
	}

	private void SplitLot()
	{
	    InfoBox ib = new InfoBox();

	    m_lotSplit.Execute();

	    PrintLabel();
	    ClearLotDetails();

	    ib.Show("Lot split successful.");
	}

	private void PrintLabel()
	{	    
	    InventoryItem item = 
            Scout.Core.Service<IInventoryService>()
                .GetItemById(Scout.Core.Data.GetUnitOfWork(),m_lotSplit.NewLotId);

        Scout.Core.Service<IInventoryService>().PrintTravelerLabel(item);	    
	}

	#endregion

	#region Events

	private void lotEdit_ButtonClick(object sender,
	    DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
	{
	    GenericSearchDlg searchDlg = new GenericSearchDlg();

	    searchDlg.StoredProc = "srch_INVENTORY_SEARCH";
	    searchDlg.Text = "Inventory Search";
	    searchDlg.MultiSelect = false;
	    searchDlg.ShowOperations = false;

	    if (searchDlg.ShowDialog(this) == DialogResult.OK)
	    {
		if (searchDlg.SelectedRows.Count == 0)
		    return;

		DataRow dr = searchDlg.SelectedRows[0];

		lotEdit.EditValue = dr["Lot ID"];
	    }
	}

	private void splitBtn_Click(object sender, EventArgs e)
	{
	    if (!ValidSplit())
		return;

	    InfoBox ib = new InfoBox();
	    DialogResult ans;

	    ib.Buttons = MessageBoxButtons.YesNo;
	    ans = ib.Show("Are you sure you want to split this lot?");

	    if (ans == DialogResult.Yes)
	    {
		try
		{
		    SplitLot();
		    DialogResult = DialogResult.OK;
		}
		catch (Exception ex)
		{
		    ib = new InfoBox();

		    ib.Icon = MessageBoxIcon.Error;
		    ib.Show("Error spliting lot:\n{0}", ex.Message);
		}
	    }
	}

	private void lotEdit_Validated(object sender, EventArgs e)
	{
	    UpdateLotInfo();
	}

	#endregion

    }
}
