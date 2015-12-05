using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCOUT.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Widgets
{
    public partial class PersistenceWidget : UserControl
    {
        private PersistenceController m_persistenceController;

        public event PersistenceController.CancelChangesEventHandler CancelChanges;
        public event PersistenceController.SaveChangesEventHandler SaveChanges;

        public PersistenceWidget()
        {
            InitializeComponent();
        }

        public void SetUnitOfWork(IUnitOfWork uow)
        {
            m_persistenceController = new PersistenceController(uow);
            saveButton.Click += m_persistenceController.Save;
            cancelButton.Click += m_persistenceController.Cancel;
            m_persistenceController.CancelChanges += (o, t) => this.CancelChanges(o, t);
            m_persistenceController.SaveChanges += (o, t) => this.SaveChanges(o, t);           
        }
    }
}
