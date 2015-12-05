using System;
using System.Windows.Forms;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Orders
{
    public partial class PacklistsContentsTransferView : Form
    {
        private Packlist m_packlist1;
        private Packlist m_packlist2;
        private IUnitOfWork m_uow;

        public PacklistsContentsTransferView(Packlist packlist1, Packlist packlist2)
        {
            InitializeComponent();

            m_packlist1 = packlist1;
            m_packlist2 = packlist2;

            Init();
            Bind();
            WireEvents();
        }

        private void Init()
        {
            persistenceWidget1.SetUnitOfWork(m_packlist1.Session);
        }

        private void Bind()
        {
            packlistContentsView1.Packlist = m_packlist1;
            packlistContentsView2.Packlist = m_packlist2;
            m_uow = m_packlist1.Session;
        }

        private void WireEvents()
        {
            moveLeftButton.Click += moveLeftButton_Click;
            moveRightButton.Click += moveRightButton_Click;

            persistenceWidget1.SaveChanges += (o,e) => Close();
            persistenceWidget1.CancelChanges += (o,e) => Close();

        }

        void moveRightButton_Click(object sender, EventArgs e)
        {
            if(packlistContentsView1.GetSelectedRows().Count > 0)
            {
                foreach (Shipment shipment in packlistContentsView1.GetSelectedRows())
                {
                    m_packlist2.AddShipment(shipment);
                }                                
            }
        }

        void moveLeftButton_Click(object sender, EventArgs e)
        {
            if (packlistContentsView2.GetSelectedRows().Count > 0)
            {
                foreach (Shipment shipment in packlistContentsView2.GetSelectedRows())
                {
                    m_packlist1.AddShipment(shipment);
                } 
            }                        
        }

    }
}
