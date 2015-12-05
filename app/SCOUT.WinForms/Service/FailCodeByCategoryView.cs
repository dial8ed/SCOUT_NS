using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using SCOUT.Core.Data;


namespace SCOUT.WinForms.Service
{
    public partial class FailCodeByCategoryView : Form
    {
        private XPCollection<ServiceCode> m_serviceCodes;
        public EventHandler<ServiceCodeEventArgs> m_callback;
    
        public FailCodeByCategoryView(XPCollection<ServiceCode> serviceCodes, EventHandler<ServiceCodeEventArgs> callback)
        {
            m_serviceCodes = serviceCodes;
            m_callback = callback;
            InitializeComponent();
            LoadGrid();
            WireEvents();
        }

        private void WireEvents()
        {            
            failCodeView.KeyPress += failCodeView_KeyPress;
            failCodeView.DoubleClick += failCodeView_DoubleClick;
        }

        void failCodeView_DoubleClick(object sender, EventArgs e)
        {
            AddFailure();
        }

        void failCodeView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Return)
            {
                AddFailure();
            }
        }

        private void LoadGrid()
        {
            failCodeGrid.DataSource = m_serviceCodes;            
        }

        private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            failCodeView.CollapseAllGroups();  
        }

        private void hyperLinkEdit2_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            failCodeView.ExpandAllGroups();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addFailureButton_Click(object sender, EventArgs e)
        {
            AddFailure();
        }

        private void AddFailure()
        {
            ServiceCode code = failCodeView.GetFocusedRow() as ServiceCode;

            if (code == null)
                return;

            m_callback(this, new ServiceCodeEventArgs(code, commentsText.Text));

            Close();
        }
    }

    public class ServiceCodeEventArgs: EventArgs
    {
        private ServiceCode m_code;
        private string m_comments;

        public ServiceCodeEventArgs(ServiceCode code, string comments)
        {
            m_code = code;
            m_comments = comments;
        }

        public ServiceCode Code
        {
            get { return m_code; }            
        }

        public string Comments
        {
            get { return m_comments; }           
        }
    }
}
