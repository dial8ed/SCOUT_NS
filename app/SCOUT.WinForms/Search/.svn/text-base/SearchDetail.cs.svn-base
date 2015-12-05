using System;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.Search
{
    public class SearchDetail<T>
    {                
        private FormWindowState m_windowState = FormWindowState.Normal;

        private Form m_mdiParent = ViewLoader.Instance().MdiParent;        
        
        public string SearchText{ get; set;}

        public string StoredProcedure { get; set; }
        
        public string IdColumn{ get; set; }
  
        public Type EditFormType { get; set; }

        public ISearchButtons SearchButtons { get; set; }

        public bool ShowModal { get; set; }

        public FormWindowState WindowState
        {
            get
            {
                return m_windowState;
            } 
            set
            {
                m_windowState = value;    
            }
        }
        
        public Form MdiParent 
        { 
            get { return m_mdiParent; } 
            set { m_mdiParent = value; } 
        }

        public Type SearchObjectType { get { return typeof (T); } }

        public bool OutputOnly { get; set; }

        public Action<T> OnSelection { get; set; }

        public IUnitOfWork Session{ get; set; }
    }
}