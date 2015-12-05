using System;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public partial class StationSelectForm : XtraForm
    {
        public StationSelectForm()
        {
            InitializeComponent();
            InitLists();
            WireEvents();
        }

        private void WireEvents()
        {
            sflLookup.EditValueChanged += sflLookup_EditValueChanged;
            stationGrid.DoubleClick += stationGrid_DoubleClick;
            stationGrid.KeyPress += stationGrid_KeyPress;
        }

        void stationGrid_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                LoadInputForm();
            }
        }

        void stationGrid_DoubleClick(object sender, EventArgs e)
        {
           LoadInputForm();
        }

        private void LoadInputForm()
        {
            ServiceStation station = stationsView.GetFocusedRow() as ServiceStation;
            if (station != null)
            {
                StationInputForm form = new StationInputForm();
                form.ShowDialog();
            }
        }
        private void sflLookup_EditValueChanged(object sender, EventArgs e)
        {
            Shopfloorline sfl = sflLookup.EditValue as Shopfloorline;
            if (sfl != null)
            {
                stationGrid.DataSource = sfl.ActiveServiceStations;
            }
        }

        private void InitLists()
        {
            sflLookup.Properties.DataSource = sflList;
            sflLookup.Properties.DisplayMember = "Label";
            sflLookup.Properties.ValueMember = "This";
        }
    }
}