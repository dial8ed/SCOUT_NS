using System;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Views
{
    public partial class DfileActionSearchView : Form
    {
        private IAreaService m_areas;
        private IDfileService m_dfile;
        private IUnitOfWork m_unitOfWork;

        public DfileActionSearchView()
        {
            InitializeComponent();

            m_areas = Scout.Core.Service<IAreaService>();
            m_dfile = Scout.Core.Service<IDfileService>();

            m_unitOfWork = Scout.Core.Data.GetUnitOfWork();

            LoadLists();
        }

        private void LoadLists()
        {
            shopfloorlineSelList.Properties.DataSource = m_areas.GetAllShopfloorlines(m_unitOfWork);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {

            Shopfloorline sfl = shopfloorlineSelList.EditValue as Shopfloorline;
            if (sfl != null)
            {
                dfileItemsGrid.DataSource =
                    m_dfile.Repository.GetResolvedItemsByShopfloorline(m_unitOfWork, sfl);
            }
            else
            {
                dfileItemsGrid.DataSource = null;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void runActionButton_Click(object sender, EventArgs e)
        {
            DfileItem item = dfileItemsView.GetFocusedRow() as DfileItem;
            if (item != null)
            {
                PurchaseOrder po = item.ActionOrder.GetContract<PurchaseOrder>() as PurchaseOrder;
                if(po != null)
                {
                    receivingForm form = new receivingForm(po);
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.ShowDialog();
                    Search();
                }                
            }
        }
    }
}
