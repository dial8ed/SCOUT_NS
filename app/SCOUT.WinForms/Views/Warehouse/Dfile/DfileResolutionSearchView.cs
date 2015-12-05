using System;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.Views
{
    public partial class DfileResolutionSearchView : Form
    {
        private IAreaService m_areas;
        private IDfileService m_dfile;
        private IUnitOfWork m_unitOfWork;

        public DfileResolutionSearchView()
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
                    m_dfile.Repository.GetOpenDfileItemsByShopfloorline(m_unitOfWork, sfl);
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

        private void OpenIncomingOrder()
        {
            DfileItem item = dfileItemsView.GetFocusedRow() as DfileItem;
            if(item != null)
            {
                ViewLoader.Instance().CreateFormWithArgs<mainOrderForm>(
                    false, new object[] {item.IncomingOrder});
            }                
        }

        private void ResolveDfile()
        {
            DfileItem item = dfileItemsView.GetFocusedRow() as DfileItem;
            if (item != null)
            {
                ResolveDfileItemView view = new ResolveDfileItemView(item);
                view.StartPosition = FormStartPosition.CenterParent;

                if (view.ShowDialog(this) == DialogResult.OK)
                    Search();
            }
        }

        private void openIncomingOrderButton_Click(object sender, EventArgs e)
        {
            OpenIncomingOrder();
        }

        private void resolveDfileButton_Click(object sender, EventArgs e)
        {
            ResolveDfile();
        }
    }
}
