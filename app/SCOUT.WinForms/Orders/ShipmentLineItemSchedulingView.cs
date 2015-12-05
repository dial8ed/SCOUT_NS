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
    public partial class ShipmentLineItemSchedulingView : Form
    {
        private readonly SalesLineItem m_item;

        public ShipmentLineItemSchedulingView(SalesLineItem item)
        {
            m_item = item;
            InitializeComponent();
            Bind();
        }

        private void Bind()
        {
            pnInput.Text = m_item.PartNumber;
            qtyInput.Text = m_item.Quantity.ToString();
            scheduleGrid.DataSource = m_item.Schedules;

        }
    }
}
