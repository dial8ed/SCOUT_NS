using System.Windows.Forms;
using SCOUT.Core.Mvc;

namespace SCOUT.WinForms.Core
{
    class ViewBase : Form, IView
    {
        private MvcEventsController m_events;

        public ViewBase()
        {
            m_events = new MvcEventsController(this);
        }

        public MvcEventsController EventsController
        {
            get { return m_events; }
        }
 
        public virtual void Show(bool mdiChild,params object[] args)
        {
            ViewLoader.Instance().ShowForm(this, mdiChild);
        }

    }
}
