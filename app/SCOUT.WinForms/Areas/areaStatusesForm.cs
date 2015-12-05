using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SCOUT.Core.Data;
using DevExpress.Xpo;

namespace SCOUT.WinForms
{
    public partial class areaStatusesForm : Form
    {
        private XPCollection<AreaStatus> m_statusList;
        private IUnitOfWork m_uow;

        public areaStatusesForm()
        {
            InitializeComponent();
            Init();
            LoadStatuses();
        }

        private void Init()
        {
            m_uow = Scout.Core.Data.GetUnitOfWork();
            persistenceWidget1.SetUnitOfWork(m_uow);

            WireEvents();
        }

        private void WireEvents()
        {
            persistenceWidget1.SaveChanges += (s,e) => DialogResult = DialogResult.OK;
            persistenceWidget1.CancelChanges += (s, e) => DialogResult = DialogResult.Cancel;            
        }

        private void LoadStatuses()
        {           
            m_statusList = 
                Scout.Core.Data
                .GetList<AreaStatus>(m_uow).All() as XPCollection<AreaStatus>;

            areaStatusesGrid.DataSource = m_statusList;           
        }
    }
}