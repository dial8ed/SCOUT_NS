using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using System.IO;

namespace SCOUT.Core.Data
{
    [Persistent("documents")]
    public class Document : VPLiteObject
    {
        private string m_filePath;
        private Guid m_id = Guid.NewGuid();
        private string m_name = "";

        public Document(Session session) : base(session)
        {
            
        }

        [Persistent("id")]
        [Key(AutoGenerate = false)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("file_path")]
        [Size(SizeAttribute.Unlimited)]
        public string FilePath
        {
            get { return m_filePath; }
            set { SetPropertyValue("FilePath", ref m_filePath, value); }
        }

        [Persistent("name")]
        public string Name
        {
            get { return m_name; }
            set { SetPropertyValue("Name", ref m_name, value); }
        }

        public void Open()
        {
            if(File.Exists(@m_filePath))
            {
                System.Diagnostics.Process.Start(@m_filePath);           
            }
            else
            {
                MessageBox.Show("Invalid file path.", Application.ProductName, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

            }                
        }
    }
}