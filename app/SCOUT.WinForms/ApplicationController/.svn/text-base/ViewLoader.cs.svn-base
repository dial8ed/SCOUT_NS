using System;
using System.Windows.Forms;

namespace SCOUT.WinForms.Core
{
    public class ViewLoader
    {
        private Form m_mdiParent;
        private static ViewLoader m_singleton;


        public static ViewLoader Instance()
        {
            if (m_singleton == null)
            {
                m_singleton = new ViewLoader();
            }
            return m_singleton;
        }


        public void SetMdiParent(Form mdiParent)
        {
            m_mdiParent = mdiParent;
        }


        public Form MdiParent
        {
            get { return m_mdiParent; }
        }


        public void ShowForm<T>(T form, bool mdiChild) where T : Form
        {
            form.StartPosition = FormStartPosition.CenterParent;
            form.MdiParent = mdiChild == true ? m_mdiParent : null;
            form.KeyPreview = true;

            if (mdiChild == false)
            {
                form.ShowDialog();
            }
            else
            {
                form.Show();
                form.Focus();
            }
        }


        public T CreateFormWithArgs<T>(bool mdiChild, params object[] args)
            where T : Form
        {
            T form = null;

            Type formType = typeof (T);
            form = (T) Activator.CreateInstance(formType, args);

            ShowForm(form, mdiChild);

            return form;
        }
    }
}