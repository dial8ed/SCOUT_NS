using System;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core
{
    public class PersistenceController
    {
        #region Delegates

        public delegate void CancelChangesEventHandler(object sender, EventArgs args);

        public delegate void SaveChangesEventHandler(object sender, EventArgs args);

        #endregion

        private readonly IUnitOfWork m_uow;

        public PersistenceController(IUnitOfWork uow)
        {
            if (uow == null)
                throw new NullReferenceException("UnitOfWork cannot be null.");

            m_uow = uow;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return m_uow; }
        }

        private event CancelChangesEventHandler m_cancelChanges;

        private event SaveChangesEventHandler m_saveChanges;

        public event CancelChangesEventHandler CancelChanges
        {
            add { m_cancelChanges += value; }
            remove { m_cancelChanges -= value; }
        }

        public event SaveChangesEventHandler SaveChanges
        {
            add { m_saveChanges += value; }
            remove { m_saveChanges -= value; }
        }

        public bool Save()
        {
            if (m_uow != null)
            {
                if (Scout.Core.Data.Save(m_uow))
                {
                    Scout.Core.UserInteraction.Dialog.ShowMessage("Save Complete.", UserMessageType.Information);

                    if (m_saveChanges != null)
                        m_saveChanges(this, new EventArgs());
                    return true;
                }
            }

            return false;
        }

        public bool Cancel()
        {
            if (m_uow.HasChanges())
            {
                if (Scout.Core.UserInteraction.Dialog.AskQuestion
                        ("There are un-saved changes. Do you want to cancel these changes?") == DialogResult.No)
                    return false;
            }

            if (m_cancelChanges != null)
                m_cancelChanges(this, new EventArgs());

            return true;
        }

        public void Save(object sender, EventArgs e)
        {
            Save();
        }

        public void Cancel(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}