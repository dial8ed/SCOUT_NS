using System.Windows.Forms;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public partial class F9CommentsView : Form
    {
        private InventoryServiceProperties m_serviceProperties;

        public F9CommentsView(InventoryServiceProperties serviceProperties)
        {
            InitializeComponent();
            m_serviceProperties = serviceProperties;
            Bind();
        }

        private void Bind()
        {
            if (m_serviceProperties == null)
            {
                BindUnknown();
            } 
            else
            {
                BindReadOnly();
            }
        }

        private void BindUnknown()
        {
            string unknownMsg = "F9 Comments Not found.";
            serialText.Text = unknownMsg;
            partNumberText.Text = unknownMsg;
            f9CommentsMemo.Text = unknownMsg;            
        }

        private void BindReadOnly()
        {
            serialText.Text = m_serviceProperties.SerialNumber;
            partNumberText.Text = m_serviceProperties.PartNumber;
            f9CommentsMemo.Text = m_serviceProperties.F9Comments;                    
        }
    }
}