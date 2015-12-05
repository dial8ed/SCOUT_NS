using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Orders
{
    public partial class PacklistContentsView : UserControl
    {
        private Packlist m_packlist;
       
        public PacklistContentsView()
        {
            InitializeComponent();
        }

        [Category("Data")]
        public Packlist Packlist
        { 
            set
            {
                m_packlist = value;
                if (m_packlist != null)
                    BindData();
                else
                    ClearData();
            }        
        }

        private void BindData()
        {
            idText.Text = m_packlist.PacklistId;
            shipDateText.Text = 
                m_packlist.ShipDate == DateTime.MinValue ? "" : m_packlist.ShipDate.ToString();

            printDateText.Text = 
                m_packlist.PrintDate == DateTime.MinValue ? "" : m_packlist.PrintDate.ToString();

            waybillText.Text = m_packlist.Waybill;
            contentsGrid.DataSource = m_packlist.Shipments;
        }

        private void ClearData()
        {
            idText.Text = "";
            shipDateText.Text = "";
            printDateText.Text = "";
            waybillText.Text = "";
            contentsGrid.DataSource = null;
        }

        public List<Shipment> GetSelectedRows()
        {
            var selectedRows =
                (from i in contentsView.GetSelectedRows()
                 select m_packlist.Shipments[i]);

            return selectedRows.ToList();
            
        }
    }
}
