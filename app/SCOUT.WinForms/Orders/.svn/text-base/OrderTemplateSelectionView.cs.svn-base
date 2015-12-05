using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Orders
{
    public partial class OrderTemplateSelectionView : Form
    {
        public event Action<Order> OnItemSelected;
        public event Action<Order> OnEditTemplateSelected;
        private IUnitOfWork m_uow;

        public OrderTemplateSelectionView()
        {
            InitializeComponent();
            m_uow = Scout.Core.Data.GetUnitOfWork();
            LoadTemplates();
            WireEvents();

        }

        private void WireEvents()
        {
            selectButton.Click += (s, e) => GetAndReturnTemplate();
            cancelButton.Click += (s, e) => Close();
            templatesView.DoubleClick += (s,e) => GetAndReturnTemplate();
        }

        private void GetAndReturnTemplate()
        {
            Order order = templatesView.GetFocusedRow() as Order;
            if (order != null)
                OnItemSelected(order);
            Close();
        }

        private void LoadTemplates()
        {
            templatesGrid.DataSource = OrderRepository.GetOrderTemplates(m_uow);
        }

        private void editTemplateLink_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            Order order = templatesView.GetFocusedRow() as Order;
            if (order != null)
                OnEditTemplateSelected(order);

            Close();
        }
    }
}
