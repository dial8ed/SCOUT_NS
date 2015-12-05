using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Controls
{
    public class AreaStatusComboObserver : RepositoryItemComboBox
    {        
        private XPCollection<AreaStatus> m_statusList;
        private IUnitOfWork m_uow;

        public AreaStatusComboObserver(IUnitOfWork uow)
        {
            m_uow = uow;
            Init();
        }

        public AreaStatusComboObserver()
        {
            m_uow = Scout.Core.Data.GetUnitOfWork();
            Init();
        }

        private void Init()
        {           
            AddButtons();
            LoadStatuses();                              
        }

        private void LoadStatuses()
        {
            m_statusList = (XPCollection<AreaStatus>)Scout.Core.Data.GetList<AreaStatus>(m_uow).All();
            foreach (AreaStatus status in m_statusList)
            {
                Items.Add(status);    
            }                        
        }

        private void AddButtons()
        {
            EditorButton btn = new EditorButton(ButtonPredefines.Ellipsis);
            btn.ToolTip = "Edit Statuses...";
            Buttons.Add(btn);
            ButtonClick += AreaStatusComboObserver_ButtonClick;
        }

        void AreaStatusComboObserver_ButtonClick(object sender, 
            ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                areaStatusesForm f = new areaStatusesForm();
                if(f.ShowDialog(null) == DialogResult.OK)
                {
                    LoadStatuses();
                }
            }        
        }
    }
}