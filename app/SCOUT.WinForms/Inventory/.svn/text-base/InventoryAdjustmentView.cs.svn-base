using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCOUT.Core.Modules.Warehouse.Inventory;

namespace SCOUT.WinForms.Inventory
{
    public partial class InventoryAdjustmentView : Form
    {
        public InventoryAdjustmentView()
        {
            InitializeComponent();
            LoadLists();
        }

        private void LoadLists()
        {

            sourceTypeLookUp.Properties.DataSource = AdjustmentTransactionType.AsList().Where(t => t.Direction=="OUT").ToList();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
